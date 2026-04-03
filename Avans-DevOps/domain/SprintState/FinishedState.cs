namespace Avans_DevOps.domain.SprintState;

public class FinishedState(Sprint sprint) : ISprintState
{
    public void AddBacklogItem(string name, string description, User member, Project project, int effortPoints)
    {
        throw new InvalidOperationException("Finished sprint cannot be modified anymore.");
    }

    public void MarkInExecution()
    {
        throw new InvalidOperationException("Finished sprint cannot be modified anymore.");
    }

    public void MarkInReview()
    {
        throw new InvalidOperationException("Finished sprint cannot be modified anymore.");
    }

    public void MarkFinished()
    {
        throw new InvalidOperationException("Sprint is already finished.");
    }
}