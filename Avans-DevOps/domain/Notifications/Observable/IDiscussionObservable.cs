using Avans_DevOps.domain.Discussions;
using Avans_DevOps.domain.Notifications.Observer;

namespace Avans_DevOps.domain.Notifications.Observable;

public interface IDiscussionObservable
{
    void Subscribe(IDiscussionObserver observer);
    void Unsubscribe(IDiscussionObserver observer);
    void NotifyPostAdded(ThreadPost threadPost);
}