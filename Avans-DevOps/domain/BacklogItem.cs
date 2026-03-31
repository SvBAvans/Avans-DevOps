using Avans_DevOps.domain.Discussions;
using Avans_DevOps.domain.Notifications.Observable;
using Avans_DevOps.domain.Notifications.Observer;
using Avans_DevOps.domain.WorkableState;

namespace Avans_DevOps.domain;

public class BacklogItem : IWorkable, IStateObservable
{
    public IWorkableState TodoState { get; } = new TodoState();
    public IWorkableState DoingState { get; } = new DoingState();
    public IWorkableState ReadyForTestingState { get; } = new ReadyForTestingState();
    public IWorkableState TestingState { get; } = new TestingState();
    public IWorkableState TestedState { get; } = new TestedState();
    public IWorkableState DoneState { get; } = new DoneState();

    public string Title { get; set; }
    public string Description { get; set; }
    private IWorkableState _state;
    public User Member { get; }
    public bool IsClosed { get; set; } = false;
    public Project Project;
    
    public List<Activity> Activities { get; } = [];
    private readonly List<ThreadPost> _comments = [];

    private readonly List<IStateObserver> _observers = [];

    public BacklogItem(string title, string description, User member, Project project)
    {
        Title = title;
        Description = description;
        _state = TodoState;
        Member = member;
        Project = project;
        
        Subscribe(new LoggingNotifier());
    }

    public void AddActivity(string title, User member)
    {
        var activity = new Activity(title, member, this);
        
        //TODO: subscribe observers

        Activities.Add(activity);
    }

    public void AddComment(string content, User author)
    {
        if (IsClosed)
        {
            throw new InvalidOperationException("Cannot comment on closed backlog item");
        }
        
        var post = new ThreadPost(content, this)
        {
            Author = author
        };
        
        post.Subscribe(new CommentNotificationObserver());
        post.NotifyPostAdded(post);
        
        _comments.Add(post);
    }

    public IReadOnlyList<ThreadPost> GetComments => _comments.AsReadOnly();
    
    public void SetState(IWorkableState state)
    {
        var oldState = _state;

        _state = state;

        NotifyStateChanged(this, oldState, _state);
    }
    

    public void StartWork()
    {        
        _state.StartWork(this);
    }

    public void MarkReadyForTesting()
    {
        _state.MarkReadyForTesting(this);
    }

    public void MarkTesting()
    {
        _state.MarkTesting(this);
    }

    public void MarkTested()
    {
        _state.MarkTested(this);
    }

    public void ApproveDone()
    {
        _state.ApproveDone(this);
    }

    public void ReturnToTodo()
    {
        _state.ReturnToTodo(this);
    }

    public string GetStateName()
    {
        return _state.GetName();
    }

    public void Subscribe(IStateObserver observer)
    {
        if (!_observers.Contains(observer))
            _observers.Add(observer);
    }

    public void Unsubscribe(IStateObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyStateChanged(IWorkable workable, IWorkableState oldState, IWorkableState newState)
    {
        foreach (var observer in _observers.ToList())
        {
            observer.OnStateChanged(workable, oldState, newState);
        }
    }
}