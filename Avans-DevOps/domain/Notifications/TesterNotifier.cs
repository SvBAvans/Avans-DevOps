namespace Avans_DevOps.domain.Notifications;

public class TesterNotifier(User tester) : IStateObserver
{
    public void OnStateChanged(IWorkable workable, IWorkableState oldState, IWorkableState newState)
    {
        if (newState.GetName() != "ReadyForTesting")
            return;

        Console.WriteLine($"[TESTER NOTIFY] {tester.Name}: '{workable.Title}' is ready for testing!");
    }
}