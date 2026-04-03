namespace Avans_DevOps.domain.SprintState;

public class InExecutionState(Sprint sprint) : ISprintState
{
    public void AddBacklogItem(string name, string description, User member, Project project)
    {
        throw new InvalidOperationException("Sprint can not be modified while in execution");
    }

    public void MarkInExecution()
    {
        throw new InvalidOperationException("Sprint cannot be modified while in execution");
    }

    public void MarkFinished()
    {
        sprint.SetState(sprint.FinishedState);
    }
}