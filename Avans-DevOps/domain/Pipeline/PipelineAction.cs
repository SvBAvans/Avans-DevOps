namespace Avans_DevOps.domain.Pipeline;

public abstract class PipelineAction : IPipelineComponent
{
    public string Name { get; }

    protected PipelineAction(string name)
    {
        Name = name;
    }

    public abstract void Execute();
}