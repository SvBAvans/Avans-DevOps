namespace Avans_DevOps.domain.WorkableState;

public class DoingState : IWorkableState
{
    public void StartWork(IWorkable item)
    {
        Console.WriteLine("ERROR: Item already started");
    }

    public void MarkReadyForTesting(IWorkable item)
    {
        item.SetState(item.ReadyForTestingState);
    }
 
    public void MarkTesting(IWorkable item)
    {
        Console.WriteLine("ERROR: cannot ReadyForTesting states.");
    }
     
    public void MarkTested(IWorkable item)
    {
        Console.WriteLine("ERROR: cannot Testing states.");
    }

    public void ApproveDone(IWorkable item)
    {
        Console.WriteLine("ERROR: cannot Testing states.");
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