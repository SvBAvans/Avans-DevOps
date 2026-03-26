namespace Avans_DevOps.domain.BacklogItemState;

public class DoneState : IBacklogItemState
{
    public void StartWork(BacklogItem backlogItem)
    {
        throw new NotImplementedException();
    }

    public void MarkReadyForTesting(BacklogItem backlogItem)
    {
        throw new NotImplementedException();
    }

    public void MarkTested(BacklogItem backlogItem)
    {
        throw new NotImplementedException();
    }

    public void ApproveDone(BacklogItem backlogItem)
    {
        throw new NotImplementedException();
    }

    public void ReturnToTodo(BacklogItem backlogItem)
    {
        throw new NotImplementedException();
    }

    public string GetName()
    {
        return GetType().ToString().Split(".").Last();
    }
}