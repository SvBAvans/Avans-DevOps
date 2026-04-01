namespace Avans_DevOps.domain.Pipeline.Actions;

public class CheckoutSourceAction : PipelineAction
{
    public CheckoutSourceAction() : base("Checkout source") { }

    public override void Execute()
    {
        Console.WriteLine($"[Action] {Name}");
    }
}