namespace Avans_DevOps.domain.WorkableState;

public class TodoState : IWorkableState
{
    public void StartWork(IWorkable item)
    {
        item.SetState(item.DoingState);
    }

    public void MarkReadyForTesting(IWorkable item)
        => Invalid("Cannot skip from Todo to ReadyForTesting");

    public void MarkTesting(IWorkable item)
        => Invalid("Cannot skip from Todo to Testing");

    public void MarkTested(IWorkable item)
        => Invalid("Cannot skip from Todo to Tested");

    public void ApproveDone(IWorkable item)
        => Invalid("Cannot skip from Todo to Done");

    public void ReturnToTodo(IWorkable item)
        => Invalid("Item is already in Todo");

    public string GetName() => nameof(TodoState);

    private void Invalid(string msg) => throw new InvalidOperationException(msg);
}