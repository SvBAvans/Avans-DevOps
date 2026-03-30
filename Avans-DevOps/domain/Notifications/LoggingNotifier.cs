namespace Avans_DevOps.domain.Notifications;

public class LoggingNotifier : IStateObserver
{
    public void OnStateChanged(IWorkable workable, IWorkableState oldState, IWorkableState newState)
    {
        Console.WriteLine($"[Logging-notifier]: Workable state updated from {oldState.GetName()} to {newState.GetName()}");
    }
}