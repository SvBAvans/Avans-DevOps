using Avans_DevOps.domain;
using Xunit;

namespace UnitTests;

public class SprintStateFlowTests
{
    [Fact]
    public void NewSprint_StartsInCreatedState()
    {
        var sprint = SprintTestHelper.CreateSprint();

        Assert.Equal("CreatedState", sprint.GetStateName());
    }

    [Fact]
    public void Created_MarkInExecution_GoesToInExecution()
    {
        var sprint = SprintTestHelper.CreateSprint();

        sprint.MarkInExecution();

        Assert.Equal("InExecutionState", sprint.GetStateName());
    }

    [Fact]
    public void Created_StartReview_GoesToInReview()
    {
        var sprint = SprintTestHelper.CreateSprint();

        sprint.StartReview();

        Assert.Equal("InReviewState", sprint.GetStateName());
    }

    [Fact]
    public void Created_MarkFinished_GoesToFinished()
    {
        var sprint = SprintTestHelper.CreateSprint();

        sprint.MarkFinished();

        Assert.Equal("FinishedState", sprint.GetStateName());
    }

    [Fact]
    public void InExecution_StartReview_GoesToInReview()
    {
        var sprint = SprintTestHelper.CreateInExecutionSprint();

        sprint.StartReview();

        Assert.Equal("InReviewState", sprint.GetStateName());
    }

    [Fact]
    public void InExecution_MarkFinished_GoesToFinished()
    {
        var sprint = SprintTestHelper.CreateInExecutionSprint();

        sprint.MarkFinished();

        Assert.Equal("FinishedState", sprint.GetStateName());
    }

    [Fact]
    public void InReview_MarkFinished_GoesToFinished()
    {
        var sprint = SprintTestHelper.CreateInReviewSprint();

        sprint.MarkFinished();

        Assert.Equal("FinishedState", sprint.GetStateName());
    }
}