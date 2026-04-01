using Avans_DevOps.domain;
using Avans_DevOps.domain.Report;

namespace UnitTests;

public class TestSprintReportExporter : SprintReportExporter
{
    public List<string> Steps { get; } = new();

    public string? RenderedHeader { get; private set; }
    public string? RenderedBody { get; private set; }
    public string? RenderedFooter { get; private set; }

    protected override SprintReportData CollectData(Sprint sprint)
    {
        Steps.Add("CollectData");
        return base.CollectData(sprint);
    }

    protected override string BuildHeader(SprintReportData data)
    {
        Steps.Add("BuildHeader");
        return base.BuildHeader(data);
    }

    protected override string BuildBody(SprintReportData data)
    {
        Steps.Add("BuildBody");
        return base.BuildBody(data);
    }

    protected override string BuildFooter(SprintReportData data)
    {
        Steps.Add("BuildFooter");
        return base.BuildFooter(data);
    }

    protected override void RenderOutput(string header, string body, string footer)
    {
        Steps.Add("RenderOutput");
        RenderedHeader = header;
        RenderedBody = body;
        RenderedFooter = footer;
    }
}