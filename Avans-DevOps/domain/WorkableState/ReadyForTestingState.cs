namespace Avans_DevOps.domain.WorkableState;

public class ReadyForTestingState : IWorkableState
{
    public void StartWork(IWorkable item)
    {
        Console.WriteLine("ERROR: Item is already marked as ReadyForTesting");
    }

    public void MarkReadyForTesting(IWorkable item)
    {
        Console.WriteLine("ERROR: Item is already marked as ReadyForTesting");
    }

    public void MarkTesting(IWorkable item)
    {
        item.SetState(item.TestingState);
    }

    public void MarkTested(IWorkable item)
    {
        Console.WriteLine("ERROR: Item has to be tested first");
    }

    public void ApproveDone(IWorkable item)
    {
        Console.WriteLine("ERROR: Item is already marked as ReadyForTesting");
    }

    public void ReturnToTodo(IWorkable item)
    {
        item.SetState(item.TodoState);
    }

    public string GetName()
    {
        return GetType().ToString().Split(".").Last();
    }
}