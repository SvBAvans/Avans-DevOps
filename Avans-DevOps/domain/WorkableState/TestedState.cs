namespace Avans_DevOps.domain.WorkableState;

public class TestedState : IWorkableState
{
    public void StartWork(IWorkable item)
        => Invalid("Already Tested");

    public void MarkReadyForTesting(IWorkable item)
        => Invalid("Already Tested");

    public void MarkTesting(IWorkable item)
        => Invalid("Already Tested");

    public void MarkTested(IWorkable item)
        => Invalid("Already Tested");

    public void ApproveDone(IWorkable item)
        => item.SetState(item.DoneState);

    public void ReturnToTodo(IWorkable item)
        => item.SetState(item.TodoState);

    public string GetName() => nameof(TestedState);

    private static void Invalid(string msg) => throw new InvalidOperationException(msg);
}