namespace Avans_DevOps.domain.Pipeline.Actions;

public class BuildAction : PipelineAction
{
    
    public BuildAction() : base("Build project") {}

    public override void Execute()
    {
        Console.WriteLine($"[Action] {Name}");
    }
}