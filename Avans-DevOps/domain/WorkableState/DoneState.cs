namespace Avans_DevOps.domain.WorkableState;

public class DoneState : IWorkableState
{
    public void StartWork(IWorkable item)
        => Invalid("Item is Done");

    public void MarkReadyForTesting(IWorkable item)
        => Invalid("Item is Done");

    public void MarkTesting(IWorkable item)
        => Invalid("Item is Done");

    public void MarkTested(IWorkable item)
        => Invalid("Item is Done");

    public void ApproveDone(IWorkable item)
        => Invalid("Item is already Done");

    public void ReturnToTodo(IWorkable item)
        => item.SetState(item.TodoState);

    public string GetName() => nameof(DoneState);

    private void Invalid(string msg) => throw new InvalidOperationException(msg);
}