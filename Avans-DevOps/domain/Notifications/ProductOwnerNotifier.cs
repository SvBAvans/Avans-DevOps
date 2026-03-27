namespace Avans_DevOps.domain.Notifications;

public class ProductOwnerNotifier(User productOwner) : IStateObserver
{
    public void OnStateChanged(IWorkable workable, IWorkableState oldState, IWorkableState newState)
    {
        Console.WriteLine($"[PO NOTIFY] {productOwner.Name}: '{workable.Title}' changed from {oldState.GetName()} to {newState.GetName()}");
    }
}