using Avans_DevOps.domain.Pipeline;
using Avans_DevOps.domain.Pipeline.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class PipelineIntegrationTests
    {
        [Fact]
        public void FullPipeline_ExecutesAllStagesAndActions()
        {
            var pipeline = new PipelineComposite("Deployment pipeline");

            var sourceStage = new PipelineComposite("Source stage");
            sourceStage.Add(PipelineActionFactory.CreateAction("checkout"));

            var buildStage = new PipelineComposite("Build stage");
            buildStage.Add(PipelineActionFactory.CreateAction("build"));

            var testStage = new PipelineComposite("Test stage");
            testStage.Add(PipelineActionFactory.CreateAction("unit-test"));
            testStage.Add(PipelineActionFactory.CreateAction("analysis"));

            var deployStage = new PipelineComposite("Deploy stage");
            deployStage.Add(PipelineActionFactory.CreateAction("deploy"));

            pipeline.Add(sourceStage);
            pipeline.Add(buildStage);
            pipeline.Add(testStage);
            pipeline.Add(deployStage);

            var originalOut = Console.Out;
            try
            {
                using var writer = new StringWriter();
                Console.SetOut(writer);

                pipeline.Execute();

                var output = writer.ToString();

                Assert.Contains("Deployment pipeline", output);
                Assert.Contains("Source stage", output);
                Assert.Contains("Build stage", output);
                Assert.Contains("Test stage", output);
                Assert.Contains("Deploy stage", output);
                Assert.Contains("Checkout source", output);
                Assert.Contains("Build project", output);
                Assert.Contains("Run Unit tests", output);
                Assert.Contains("Run static analysis", output);
                Assert.Contains("Deploy Application", output);
            }
            finally
            {
                Console.SetOut(originalOut);
            }
        }
    }
}
