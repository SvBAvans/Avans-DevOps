namespace Avans_DevOps.domain;

public class Sprint(string name, DateOnly startDate, DateOnly endDate)
{
    public string Name { get; set; } = name;
    public DateOnly StartDate { get; set; } = startDate;
    public DateOnly EndDate { get; set; } = endDate;
    
    public Backlog Backlog { get; set; } = new();
    
    //TODO:
    // Types:
    //  - Review Sprint
    //  - Release Sprint
    // States?:
    //  - Created?
}