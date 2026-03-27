namespace Avans_DevOps.domain.Notifications;

public interface IStateObserver
{
    void OnStateChanged(IWorkable workable, IWorkableState oldState, IWorkableState newState);
}