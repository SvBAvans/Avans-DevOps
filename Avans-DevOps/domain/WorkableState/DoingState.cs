namespace Avans_DevOps.domain.WorkableState;

public class DoingState : IWorkableState
{
    public void StartWork(IWorkable item)
        => Invalid("Item is already in Doing");

    public void MarkReadyForTesting(IWorkable item)
        => item.SetState(item.ReadyForTestingState);

    public void MarkTesting(IWorkable item)
        => Invalid("Must go via ReadyForTesting first");

    public void MarkTested(IWorkable item)
        => Invalid("Must go via Testing first");

    public void ApproveDone(IWorkable item)
        => Invalid("Must be Tested first");

    public void ReturnToTodo(IWorkable item)
        => item.SetState(item.TodoState);

    public string GetName() => nameof(DoingState);

    private static void Invalid(string msg) => throw new InvalidOperationException(msg);
}