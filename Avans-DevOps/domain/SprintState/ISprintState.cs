namespace Avans_DevOps.domain.SprintState;

public interface ISprintState
{
    void AddBacklogItem(string name, string description, User member, Project project, int effortPoints);

    void MarkInExecution();

    void MarkInReview();
    
    void MarkFinished();

    string GetStateName();
}