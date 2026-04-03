using Avans_DevOps.domain.WorkableState;

namespace Avans_DevOps.domain.Notifications.Observer;

public class ReturnedToTodoObserver(Sprint sprint) : IStateObserver
{
    public void OnStateChanged(IWorkable workable, IWorkableState oldState, IWorkableState newState)
    {
        if (newState is not TodoState)
            return;

        sprint.ScrumMaster.SendNotification($"[SM NOTIFY] {sprint.ScrumMaster.Name}: '{workable.Title}' changed from {oldState.GetName()} to {newState.GetName()}");
    }
}