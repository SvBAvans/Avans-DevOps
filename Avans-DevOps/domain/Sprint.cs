using Avans_DevOps.domain.Pipeline;

namespace Avans_DevOps.domain;

public class Sprint(Project project, string name, DateTime startDate, DateTime endDate)
{
    public string Name { get; set; } = name;
    public DateTime StartDate { get; set; } = startDate;
    public DateTime EndDate { get; set; } = endDate;
    public Project Project { get; } = project;
    
    public Backlog Backlog { get; set; } = new();
    
    public IPipelineComponent DevelopmentPipeline { get; set; }
    
    //TODO:
    // Types:
    //  - Review Sprint
    //  - Release Sprint
    // States?:
    //  - Created?
}