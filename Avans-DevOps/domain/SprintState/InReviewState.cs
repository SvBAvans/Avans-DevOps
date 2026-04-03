namespace Avans_DevOps.domain.SprintState;

public class InReviewState(Sprint sprint) : ISprintState
{
    public void AddBacklogItem(string name, string description, User member, Project project, int effortPoints)
    {
        throw new InvalidOperationException("Sprint is in review");
    }

    public void MarkInExecution()
    {
        throw new InvalidOperationException("Sprint is in review");
    }

    public void MarkInReview()
    {
        throw new InvalidOperationException("Sprint is in review");
    }

    public void MarkFinished()
    {
        sprint.SetState(sprint.FinishedState);
    }
}