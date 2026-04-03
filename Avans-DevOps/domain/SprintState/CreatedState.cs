using Avans_DevOps.domain.Notifications.Observer;
using Avans_DevOps.domain.WorkableState;

namespace Avans_DevOps.domain.SprintState;

public class CreatedState(Sprint sprint) : ISprintState
{
    public void AddBacklogItem(string name, string description, User member, Project project, int effortPoints)
    {
        var item = new BacklogItem(name, description, member, project, effortPoints);
        
        item.Subscribe(new ReturnedToTodoObserver(sprint));
        item.Subscribe(new ReadyForTestingObserver(project));
        
        sprint.Backlog.AddItem(item);
    }

    public void MarkInExecution()
    {
        sprint.SetState(sprint.InExecutionState);
    }

    public void MarkInReview()
    {
        sprint.SetState(sprint.InReviewState);
    }

    public void MarkFinished()
    {
        sprint.SetState(sprint.FinishedState);
    }

    public string GetStateName() => nameof(CreatedState);
}