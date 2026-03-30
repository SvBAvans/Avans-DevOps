namespace Avans_DevOps.domain.Pipeline.Actions;

public class DeplayAction : PipelineAction
{
    
    public DeplayAction() : base("Deploy Application") {}

    public override void Execute()
    {
        Console.WriteLine($"[Action] {Name}");
    }
}