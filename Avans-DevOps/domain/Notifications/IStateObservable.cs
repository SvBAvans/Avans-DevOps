namespace Avans_DevOps.domain.Notifications;

public interface IStateObservable
{
    void Subscribe(IStateObserver observer);
    void Unsubscribe(IStateObserver observer);
    void NotifyStateChanged(IWorkable workable, IWorkableState oldState, IWorkableState newState);
}