namespace Avans_DevOps.domain.Pipeline.Actions;

public static class PipelineActionFactory
{
    public static IPipelineComponent CreateAction(string actionType)
    {
        return actionType switch
        {
            "checkout" => new CheckoutSourceAction(),
            "build" => new BuildAction(),
            "unit-test" => new RunUnitTestAction(),
            "analysis" => new RunAnalysisAction(),
            "deploy" => new DeployAction(),
            _ => throw new ArgumentException($"Unknown action type: {actionType}")
        };
    }
}