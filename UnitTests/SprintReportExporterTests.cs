namespace UnitTests;

public class SprintReportExporterTests
{
    [Fact]
    public void CollectData_CalculatesEffortPerDeveloper_FromDoneItemsOnly()
    {
        var sprint = ReportTestHelper.CreateSprintForReportWithCompletedWork();
        var exporter = new TestSprintReportExporter();

        exporter.ExportReport(sprint);

        Assert.NotNull(exporter.RenderedBody);
        Assert.Contains("Alice: 11", exporter.RenderedBody);
        Assert.Contains("Bob: 12", exporter.RenderedBody);
    }
}