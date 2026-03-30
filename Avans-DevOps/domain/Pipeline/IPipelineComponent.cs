namespace Avans_DevOps.domain.Pipeline;

public interface IPipelineComponent
{
    string Name { get; }
    void Execute();
}