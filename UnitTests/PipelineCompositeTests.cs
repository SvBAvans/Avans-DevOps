using System.IO;
using Avans_DevOps.domain.Pipeline;
using Avans_DevOps.domain.Pipeline.Actions;
using Xunit;

namespace UnitTests;

public class PipelineCompositeTests
{
    [Fact]
    public void Add_AddsChildToComposite()
    {
        var pipeline = new PipelineComposite("Pipeline");
        var action = new BuildAction();

        pipeline.Add(action);

        Assert.Single(pipeline.Children);
        Assert.Contains(action, pipeline.Children);
    }

    [Fact]
    public void Remove_RemovesChildFromComposite()
    {
        var pipeline = new PipelineComposite("Pipeline");
        var action = new BuildAction();
        pipeline.Add(action);

        pipeline.Remove(action);

        Assert.Empty(pipeline.Children);
    }

    [Fact]
    public void Execute_WritesStartAndEndStage()
    {
        var pipeline = new PipelineComposite("Build stage");

        var originalOut = Console.Out;
        try
        {
            using var writer = new StringWriter();
            Console.SetOut(writer);

            pipeline.Execute();

            var output = writer.ToString();

            Assert.Contains("[Start Stage] Build stage", output);
            Assert.Contains("[End Stage] Build stage", output);
        }
        finally
        {
            Console.SetOut(originalOut);
        }
    }

    [Fact]
    public void Execute_ExecutesAllChildActions()
    {
        var pipeline = new PipelineComposite("Pipeline");
        pipeline.Add(new CheckoutSourceAction());
        pipeline.Add(new BuildAction());
        pipeline.Add(new RunUnitTestAction());

        var originalOut = Console.Out;
        try
        {
            using var writer = new StringWriter();
            Console.SetOut(writer);

            pipeline.Execute();

            var output = writer.ToString();

            Assert.Contains("[Start Stage] Pipeline", output);
            Assert.Contains("Checkout source", output);
            Assert.Contains("Build project", output);
            Assert.Contains("Run Unit tests", output);
            Assert.Contains("[End Stage] Pipeline", output);
        }
        finally
        {
            Console.SetOut(originalOut);
        }
    }

    [Fact]
    public void Execute_ExecutesNestedComposites()
    {
        var root = new PipelineComposite("Deployment pipeline");

        var sourceStage = new PipelineComposite("Source stage");
        sourceStage.Add(new CheckoutSourceAction());

        var buildStage = new PipelineComposite("Build stage");
        buildStage.Add(new BuildAction());

        root.Add(sourceStage);
        root.Add(buildStage);

        var originalOut = Console.Out;
        try
        {
            using var writer = new StringWriter();
            Console.SetOut(writer);

            root.Execute();

            var output = writer.ToString();

            Assert.Contains("[Start Stage] Deployment pipeline", output);
            Assert.Contains("[Start Stage] Source stage", output);
            Assert.Contains("Checkout source", output);
            Assert.Contains("[End Stage] Source stage", output);
            Assert.Contains("[Start Stage] Build stage", output);
            Assert.Contains("Build project", output);
            Assert.Contains("[End Stage] Build stage", output);
            Assert.Contains("[End Stage] Deployment pipeline", output);
        }
        finally
        {
            Console.SetOut(originalOut);
        }
    }

    [Fact]
    public void Children_IsReadOnlyView()
    {
        var pipeline = new PipelineComposite("Pipeline");
        pipeline.Add(new BuildAction());

        var children = pipeline.Children;

        Assert.IsAssignableFrom<IReadOnlyList<IPipelineComponent>>(children);
        Assert.Single(children);
    }
}