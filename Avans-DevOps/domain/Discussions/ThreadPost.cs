using Avans_DevOps.domain.Notifications.Observable;
using Avans_DevOps.domain.Notifications.Observer;

namespace Avans_DevOps.domain.Discussions;

public class ThreadPost(string content, BacklogItem backlogItem) : IDiscussionObservable
{
    public string Content { get; } = content;
    public required User Author;
    private readonly List<ThreadPost> _comments = [];
    public BacklogItem BacklogItem { get; } = backlogItem;
    public ThreadPost? ParentPost;
    
    private readonly List<IDiscussionObserver> _observers = [];

    public IReadOnlyList<ThreadPost> GetComments() => _comments.AsReadOnly();
    
    public void AddComment(string content, User user)
    {
        if (BacklogItem.IsClosed)
        {
            throw new InvalidOperationException("Cannot comment on closed backlog item");
        }

        var post = new ThreadPost(content, BacklogItem)
        {
            Author = user,
            ParentPost = this,
        };
        _comments.Add(post);
        NotifyPostAdded(post);
    }

    public void Subscribe(IDiscussionObserver observer)
    {
        if (!_observers.Contains(observer))
            _observers.Add(observer);
    }

    public void Unsubscribe(IDiscussionObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyPostAdded(ThreadPost threadPost)
    {
        foreach (var observer in _observers.ToList())
        {
            observer.OnPostAdded(threadPost);
        }
    }
}