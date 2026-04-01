namespace Avans_DevOps.domain.WorkableState;

public class TestingState : IWorkableState
{
    public void StartWork(IWorkable item)
        => Invalid("Already in Testing");

    public void MarkReadyForTesting(IWorkable item)
        => Invalid("Already in Testing");

    public void MarkTesting(IWorkable item)
        => Invalid("Already in Testing");

    public void MarkTested(IWorkable item)
        => item.SetState(item.TestedState);

    public void ApproveDone(IWorkable item)
        => Invalid("Must be Tested first");

    public void ReturnToTodo(IWorkable item)
        => item.SetState(item.TodoState);

    public string GetName() => nameof(TestingState);

    private void Invalid(string msg) => throw new InvalidOperationException(msg);
}