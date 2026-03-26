namespace Avans_DevOps.domain.BacklogItemState;

public class TestingState : IBacklogItemState
{
    public void StartWork()
    {
        throw new NotImplementedException();
    }

    public void MarkReadyForTesting()
    {
        throw new NotImplementedException();
    }

    public void MarkTested()
    {
        throw new NotImplementedException();
    }

    public void ApproveDone()
    {
        throw new NotImplementedException();
    }

    public void ReturnToTodo()
    {
        throw new NotImplementedException();
    }

    public string GetName()
    {
        return GetType().ToString().Split(".").Last();
    }
}