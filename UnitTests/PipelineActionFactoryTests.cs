using Avans_DevOps.domain.Pipeline.Actions;
using Xunit;

namespace UnitTests;

public class PipelineActionFactoryTests
{
    [Fact]
    public void CreateAction_Checkout_ReturnsCheckoutSourceAction()
    {
        var action = PipelineActionFactory.CreateAction("checkout");

        Assert.IsType<CheckoutSourceAction>(action);
    }

    [Fact]
    public void CreateAction_Build_ReturnsBuildAction()
    {
        var action = PipelineActionFactory.CreateAction("build");

        Assert.IsType<BuildAction>(action);
    }

    [Fact]
    public void CreateAction_UnitTest_ReturnsRunUnitTestAction()
    {
        var action = PipelineActionFactory.CreateAction("unit-test");

        Assert.IsType<RunUnitTestAction>(action);
    }

    [Fact]
    public void CreateAction_Analysis_ReturnsRunAnalysisAction()
    {
        var action = PipelineActionFactory.CreateAction("analysis");

        Assert.IsType<RunAnalysisAction>(action);
    }

    [Fact]
    public void CreateAction_Deploy_ReturnsDeplayAction()
    {
        var action = PipelineActionFactory.CreateAction("deploy");

        Assert.IsType<DeployAction>(action);
    }

    [Fact]
    public void CreateAction_UnknownType_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
            PipelineActionFactory.CreateAction("unknown"));
    }
}