using Avans_DevOps.domain.Notifications.Observer;

namespace Avans_DevOps.domain.Notifications.Observable;

public interface IStateObservable
{
    void Subscribe(IStateObserver observer);
    void Unsubscribe(IStateObserver observer);
    void NotifyStateChanged(IWorkable workable, IWorkableState oldState, IWorkableState newState);
}