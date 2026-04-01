using Xunit;

namespace UnitTests;

public class SprintReportExporterTemplateTests
{
    [Fact]
    public void ExportReport_ExecutesTemplateStepsInCorrectOrder()
    {
        var sprint = ReportTestHelper.CreateSprintForReport();
        var exporter = new TestSprintReportExporter();

        exporter.ExportReport(sprint);

        Assert.Equal(
            new[]
            {
                "CollectData",
                "BuildHeader",
                "BuildBody",
                "BuildFooter",
                "RenderOutput"
            },
            exporter.Steps
        );
    }

    [Fact]
    public void ExportReport_BuildsHeaderWithProjectAndSprintName()
    {
        var sprint = ReportTestHelper.CreateSprintForReport();
        var exporter = new TestSprintReportExporter();

        exporter.ExportReport(sprint);

        Assert.NotNull(exporter.RenderedHeader);
        Assert.Contains(sprint.Name, exporter.RenderedHeader);
        Assert.Contains(sprint.Project.Name, exporter.RenderedHeader);
        Assert.Contains("Project:", exporter.RenderedHeader);
        Assert.Contains("Sprint:", exporter.RenderedHeader);
    }

    [Fact]
    public void ExportReport_BuildsFooterWithSprintName()
    {
        var sprint = ReportTestHelper.CreateSprintForReport();
        var exporter = new TestSprintReportExporter();

        exporter.ExportReport(sprint);

        Assert.NotNull(exporter.RenderedFooter);
        Assert.Contains(sprint.Name, exporter.RenderedFooter);
    }

    [Fact]
    public void ExportReport_BuildsBodyWithTeamMembers()
    {
        var sprint = ReportTestHelper.CreateSprintForReport();
        var exporter = new TestSprintReportExporter();

        exporter.ExportReport(sprint);

        Assert.NotNull(exporter.RenderedBody);

        foreach (var member in sprint.Project.TeamMembers)
        {
            Assert.Contains(member.Name, exporter.RenderedBody);
        }
    }

    [Fact]
    public void ExportReport_BuildsBodyWithEffortPerDeveloper()
    {
        var sprint = ReportTestHelper.CreateSprintForReportWithCompletedWork();
        var exporter = new TestSprintReportExporter();

        exporter.ExportReport(sprint);

        Assert.NotNull(exporter.RenderedBody);
        Assert.Contains("Effort per developer:", exporter.RenderedBody);
        Assert.Contains("Alice", exporter.RenderedBody);
    }
}