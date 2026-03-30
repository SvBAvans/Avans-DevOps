namespace Avans_DevOps.domain.Pipeline.Actions;

public class RunAnalysisAction : PipelineAction
{
    
    public RunAnalysisAction() : base("Run static analysis") {}

    public override void Execute()
    {
        Console.WriteLine($"[Action] {Name}");
    }
}