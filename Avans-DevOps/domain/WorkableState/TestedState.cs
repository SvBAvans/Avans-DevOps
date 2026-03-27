namespace Avans_DevOps.domain.WorkableState;

public class TestedState : IWorkableState
{
    public void StartWork(IWorkable item)
    {
        Console.WriteLine("ERROR: Item is already marked as Tested");
    }

    public void MarkReadyForTesting(IWorkable item)
    {
        Console.WriteLine("ERROR: Item is already marked as Tested");
    }

    public void MarkTesting(IWorkable item)
    {
        Console.WriteLine("ERROR: Item is already marked as Tested");
    }

    public void MarkTested(IWorkable item)
    {
        Console.WriteLine("ERROR: Item is already marked as Tested");
    }

    public void ApproveDone(IWorkable item)
    {
        item.SetState(item.DoneState);
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