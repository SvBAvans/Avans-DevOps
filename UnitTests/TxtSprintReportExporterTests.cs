using System.IO;
using Avans_DevOps.domain.Report;
using Xunit;

namespace UnitTests;

public class TxtSprintReportExporterTests
{
    [Fact]
    public void ExportReport_WritesReportToConsole()
    {
        var originalOut = Console.Out;

        try
        {
            var sprint = ReportTestHelper.CreateSprintForReport();
            var exporter = new TxtSprintReportExporter();

            using var writer = new StringWriter();
            Console.SetOut(writer);

            exporter.ExportReport(sprint);

            var output = writer.ToString();

            Assert.Contains("Project:", output);
            Assert.Contains("Sprint:", output);
            Assert.Contains("Generated for sprint:", output);
        }
        finally
        {
            Console.SetOut(originalOut);
        }
    }
}