using System.Diagnostics.Metrics;

namespace Avans_DevOps.domain.Notifications;

public class ReadyForTestingObserver(Project project) : IStateObserver
{
    public void OnStateChanged(IWorkable workable, IWorkableState oldState, IWorkableState newState)
    {
        if (newState.GetName() != "ReadyForTestingState")
            return;

        foreach (var user in project.TeamMembers)
        {
            if (user.IsTester)
            {
                user.SendNotification($"[TESTER NOTIFY] {user.Name}: '{workable.Title}' is ready for testing!");
            }
        }
    }
}