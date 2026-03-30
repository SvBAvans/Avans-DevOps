using Avans_DevOps.domain.WorkableState;

namespace Avans_DevOps.domain.Notifications;

public class ReturnedToTodoObserver(Project project) : IStateObserver
{
    public void OnStateChanged(IWorkable workable, IWorkableState oldState, IWorkableState newState)
    {
        if (newState is not TodoState)
            return;

        project.ProductOwner.SendNotification($"[PO NOTIFY] {project.ProductOwner.Name}: '{workable.Title}' changed from {oldState.GetName()} to {newState.GetName()}");
    }
}