namespace Avans_DevOps.domain.SprintState;

public interface ISprintState
{
    void AddBacklogItem(string name, string description, User member, Project project);

    void MarkInExecution();
    
    void MarkFinished();
}