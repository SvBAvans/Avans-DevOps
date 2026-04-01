namespace Avans_DevOps.domain.Pipeline.Actions;

public class DeployAction : PipelineAction
{
    
    public DeployAction() : base("Deploy Application") {}

    public override void Execute()
    {
        Console.WriteLine($"[Action] {Name}");
    }
}