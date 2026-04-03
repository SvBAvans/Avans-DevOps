namespace Avans_DevOps.domain.Report;

public class SprintReportData(
    string sprintName,
    string projectName,
    DateTime reportDate,
    List<User> teamMembers,
    Dictionary<string, int> effortPerDeveloper)
{
    public string SprintName { get; } = sprintName;
    public string ProjectName { get; } = projectName;
    public DateTime ReportDate { get; } = reportDate;
    public List<User> TeamMembers { get; } = teamMembers;
    public Dictionary<string, int> EffortPerDeveloper { get; } = effortPerDeveloper;
}