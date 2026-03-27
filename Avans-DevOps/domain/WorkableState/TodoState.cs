namespace Avans_DevOps.domain.WorkableState;

public class TodoState : IWorkableState
{
    public void StartWork(IWorkable item)
    {
        item.SetState(item.DoingState);
    }

    public void MarkReadyForTesting(IWorkable item)
    {
        Console.WriteLine("ERROR: Cannot skip states");
    }

    public void MarkTesting(IWorkable item)
    {
        Console.WriteLine("ERROR: Cannot skip states");
    }

    public void MarkTested(IWorkable item)
    {
        Console.WriteLine("ERROR: Cannot skip states");
    }

    public void ApproveDone(IWorkable item)
    {
        Console.WriteLine("ERROR: Cannot skip states");
    }

    public void ReturnToTodo(IWorkable item)
    {
        Console.WriteLine("ERROR: Item is already marked as TODO");
    }

    public string GetName()
    {
        return GetType().ToString().Split(".").Last();
    }
}