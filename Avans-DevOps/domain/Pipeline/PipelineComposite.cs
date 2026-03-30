namespace Avans_DevOps.domain.Pipeline;

public class PipelineComposite(string name) : IPipelineComponent
{
    public string Name { get; } = name;

    private readonly List<IPipelineComponent> _children = [];

    public void Add(IPipelineComponent component) => _children.Add(component);
    
    public void Remove(IPipelineComponent component) => _children.Remove(component);

    public IReadOnlyList<IPipelineComponent> Children => _children.AsReadOnly();
    
    public void Execute()
    {
        Console.WriteLine($"[Start Stage] {Name}");

        foreach (var child in _children)
        {
            child.Execute();
        }
        
        Console.WriteLine($"[End Stage] {Name}");
    }
}