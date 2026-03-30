namespace Avans_DevOps.domain.Report;

public class SprintReportData
{
    public string SprintName { get; }
    public string ProjectName { get; }
    public DateTime ReportDate { get; }
    public List<User> TeamMembers { get; }
    public Dictionary<string, int> EffortPerDeveloper { get; }
    public string BurndownSummary { get; }

    public SprintReportData(string sprintName, string projectName, DateTime reportDate, List<User> teamMembers, Dictionary<string, int> effortPerDeveloper, string burndownSummary)
    {
        SprintName = sprintName;
        ProjectName = projectName;
        ReportDate = reportDate;
        TeamMembers = teamMembers;
        EffortPerDeveloper = effortPerDeveloper;
        BurndownSummary = burndownSummary;
    }
}