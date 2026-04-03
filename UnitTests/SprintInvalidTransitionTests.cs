using Xunit;

namespace UnitTests;

public class SprintInvalidTransitionTests
{
    [Fact]
    public void InExecution_MarkInExecution_Throws()
    {
        var sprint = SprintTestHelper.CreateInExecutionSprint();

        Assert.Throws<InvalidOperationException>(() => sprint.MarkInExecution());
    }

    [Fact]
    public void InReview_MarkInExecution_Throws()
    {
        var sprint = SprintTestHelper.CreateInReviewSprint();

        Assert.Throws<InvalidOperationException>(() => sprint.MarkInExecution());
    }

    [Fact]
    public void InReview_StartReview_Throws()
    {
        var sprint = SprintTestHelper.CreateInReviewSprint();

        Assert.Throws<InvalidOperationException>(() => sprint.StartReview());
    }

    [Fact]
    public void Finished_MarkInExecution_Throws()
    {
        var sprint = SprintTestHelper.CreateFinishedSprint();

        Assert.Throws<InvalidOperationException>(() => sprint.MarkInExecution());
    }

    [Fact]
    public void Finished_StartReview_Throws()
    {
        var sprint = SprintTestHelper.CreateFinishedSprint();

        Assert.Throws<InvalidOperationException>(() => sprint.StartReview());
    }

    [Fact]
    public void Finished_MarkFinished_Throws()
    {
        var sprint = SprintTestHelper.CreateFinishedSprint();

        Assert.Throws<InvalidOperationException>(() => sprint.MarkFinished());
    }
}