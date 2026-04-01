namespace Avans_DevOps.domain.WorkableState;

public class ReadyForTestingState : IWorkableState
{
    public void StartWork(IWorkable item)
        => Invalid("Already ReadyForTesting");

    public void MarkReadyForTesting(IWorkable item)
        => Invalid("Already ReadyForTesting");

    public void MarkTesting(IWorkable item)
        => item.SetState(item.TestingState);

    public void MarkTested(IWorkable item)
        => Invalid("Must be in Testing first");

    public void ApproveDone(IWorkable item)
        => Invalid("Must be Tested first");

    public void ReturnToTodo(IWorkable item)
        => item.SetState(item.TodoState);

    public string GetName() => nameof(ReadyForTestingState);

    private static void Invalid(string msg) => throw new InvalidOperationException(msg);
}