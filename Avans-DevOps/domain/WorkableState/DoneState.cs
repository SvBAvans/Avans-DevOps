namespace Avans_DevOps.domain.WorkableState;

public class DoneState : IWorkableState
{
    public void StartWork(IWorkable item)
    {
        Console.WriteLine("ERROR: Item is already marked as Done");
    }

    public void MarkReadyForTesting(IWorkable item)
    {
        Console.WriteLine("ERROR: Item is already marked as Done");
    }

    public void MarkTesting(IWorkable item)
    {
        Console.WriteLine("ERROR: Item is already marked as Done");
    }

    public void MarkTested(IWorkable item)
    {
        Console.WriteLine("ERROR: Item is already marked as Done");
    }

    public void ApproveDone(IWorkable item)
    {
        Console.WriteLine("ERROR: Item is already marked as Done");
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