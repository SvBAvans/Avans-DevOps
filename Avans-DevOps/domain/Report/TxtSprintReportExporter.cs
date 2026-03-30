namespace Avans_DevOps.domain.Report;

public class TxtSprintReportExporter : SprintReportExporter
{
    protected override void RenderOutput(string header, string body, string footer)
    {
        Console.WriteLine(header);
        Console.WriteLine("----");
        Console.WriteLine(body);
        Console.WriteLine("----");
        Console.WriteLine(footer);
    }
}