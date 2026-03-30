namespace Avans_DevOps.domain.Pipeline.Actions;

public class RunUnitTestAction : PipelineAction
{
    
    public RunUnitTestAction() : base("Run Unit tests") {}

    public override void Execute()
    {
        Console.WriteLine($"[Action] {Name}");
    }
}