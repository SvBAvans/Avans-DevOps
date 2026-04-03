using Avans_DevOps.domain.Pipeline;
using Avans_DevOps.domain.SprintState;

namespace Avans_DevOps.domain;

public class Sprint
{
    public ISprintState CreatedState { get; }
    public ISprintState InExecutionState { get; }
    public ISprintState FinishedState { get; }
    
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Project Project { get; }
    public SprintType Type { get; }
    public required User ScrumMaster { get; init; }

    private ISprintState _state;
    
    public Backlog Backlog { get; set; } = new();
    
    public IPipelineComponent? DevelopmentPipeline { get; set; }

    public Sprint(Project project, string name, DateTime startDate, DateTime endDate, SprintType sprintType)
    {
        Project = project;
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
        Type = sprintType;

        CreatedState = new CreatedState(this);
        InExecutionState = new InExecutionState(this);
        FinishedState = new FinishedState(this);
        
        _state = CreatedState;
    }

    internal void SetState(ISprintState state)
    {
        _state = state;
    }

    public void AddBacklogItem(string name, string description, User member, Project project)
    {
        _state.AddBacklogItem(name, description, member, project);
    }

    public void MarkInExecution()
    {
        _state.MarkInExecution();
    }

    public void MarkFinished()
    {
        _state.MarkFinished();
    }

    public enum SprintType
    {
        REVIEW,
        DEVELOPMENT,
    }
    
    //TODO:
    // Types:
    //  - Review Sprint
    //  - Release Sprint
    // States?:
    //  - Created?
}