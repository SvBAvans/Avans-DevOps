namespace Avans_DevOps.domain.WorkableState;

public class TestingState : IWorkableState
{
    public void StartWork(IWorkable item)
    {
        Console.WriteLine("ERROR: Item is already marked as Testing");
    }

    public void MarkReadyForTesting(IWorkable item)
    {
        Console.WriteLine("ERROR: Item is already marked as Testing");
    }

    public void MarkTesting(IWorkable item)
    {
        Console.WriteLine("ERROR: Item is already marked as Testing");
    }

    public void MarkTested(IWorkable item)
    {
        item.SetState(item.TestedState);
    }

    public void ApproveDone(IWorkable item)
    {
        Console.WriteLine("ERROR: Item has to be tested first");
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