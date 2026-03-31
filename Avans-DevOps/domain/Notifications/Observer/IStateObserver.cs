namespace Avans_DevOps.domain.Notifications.Observer;

public interface IStateObserver
{
    void OnStateChanged(IWorkable workable, IWorkableState oldState, IWorkableState newState);
}