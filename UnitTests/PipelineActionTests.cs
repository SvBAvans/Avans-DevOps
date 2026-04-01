using System.IO;
using Avans_DevOps.domain.Pipeline.Actions;
using Xunit;

namespace UnitTests;

public class PipelineActionTests
{
    [Fact]
    public void BuildAction_HasCorrectName()
    {
        var action = new BuildAction();

        Assert.Equal("Build project", action.Name);
    }

    [Fact]
    public void CheckoutSourceAction_HasCorrectName()
    {
        var action = new CheckoutSourceAction();

        Assert.Equal("Checkout source", action.Name);
    }

    [Fact]
    public void RunUnitTestAction_HasCorrectName()
    {
        var action = new RunUnitTestAction();

        Assert.Equal("Run Unit tests", action.Name);
    }

    [Fact]
    public void RunAnalysisAction_HasCorrectName()
    {
        var action = new RunAnalysisAction();

        Assert.Equal("Run static analysis", action.Name);
    }

    [Fact]
    public void DeplayAction_HasCorrectName()
    {
        var action = new DeployAction();

        Assert.Equal("Deploy Application", action.Name);
    }

    [Fact]
    public void BuildAction_Execute_WritesToConsole()
    {
        var action = new BuildAction();

        var originalOut = Console.Out;
        try
        {
            using var writer = new StringWriter();
            Console.SetOut(writer);

            action.Execute();

            var output = writer.ToString();

            Assert.Contains("[Action] Build project", output);
        }
        finally
        {
            Console.SetOut(originalOut);
        }
    }
}