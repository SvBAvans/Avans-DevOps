namespace Avans_DevOps.domain.Report;

public abstract class SprintReportExporter
{
    public void ExportReport(Sprint sprint)
    {
        var reportData = CollectData(sprint);
        var header = BuildHeader(reportData);
        var body = BuildBody(reportData);
        var footer = BuildFooter(reportData);
        RenderOutput(header, body, footer);
    }

    protected virtual SprintReportData CollectData(Sprint sprint)
    {
        var effortPerDeveloper = new Dictionary<string, int>();
        
        Console.WriteLine($"[TEST]: {sprint.Backlog.BacklogItems.Count}");
        
        foreach (var backlogBacklogItem in sprint.Backlog.BacklogItems.FindAll(item => item.GetStateName() == item.DoneState.GetName()))
        {
        Console.WriteLine($"[TEST]: {backlogBacklogItem.Member.Name}");
            
            
            foreach (var activity in backlogBacklogItem.Activities.Where(activity => !effortPerDeveloper.TryAdd(activity.Member.Name, 1)))
            {
                effortPerDeveloper.Add(activity.Member.Name, 1);
            }

            if (!effortPerDeveloper.TryAdd(backlogBacklogItem.Member.Name, 1))
            {
                effortPerDeveloper.Add(backlogBacklogItem.Member.Name, 1);
            }
        }
        
        // Console.WriteLine($"[TEST]: {}");
        
        var data = new SprintReportData(
            sprint.Name,
            sprint.Project.Name,
            DateTime.Now,
            sprint.Project.TeamMembers,
            effortPerDeveloper,
            null
            );

        return data;
    }

    protected virtual string BuildHeader(SprintReportData data)
    {
        return $"Project: {data.ProjectName}\nSprint: {data.SprintName}\nDate: {data.ReportDate}";
    }

    protected virtual string BuildBody(SprintReportData data)
    {
        var team = string.Join(", ", data.TeamMembers.Select(member => member.Name));
        var effort = string.Join(", ", data.EffortPerDeveloper.Select(e => $"{e.Key}: {e.Value}"));
        return $"Team: {team}\nEffort per developer: {effort}";
    }

    protected virtual string BuildFooter(SprintReportData data)
    {
        return $"Generated for sprint: {data.SprintName}";
    }

    protected abstract void RenderOutput(string header, string body, string footer);
}