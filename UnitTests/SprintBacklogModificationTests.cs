using Xunit;

namespace UnitTests;

public class SprintBacklogModificationTests
{
    [Fact]
    public void Created_AddBacklogItem_AddsItem()
    {
        var sprint = SprintTestHelper.CreateSprint();
        var member = SprintTestHelper.CreateMember();

        sprint.AddBacklogItem("Feature A", "Description", member, sprint.Project, 5);

        Assert.Single(sprint.Backlog.BacklogItems);
        Assert.Equal("Feature A", sprint.Backlog.BacklogItems[0].Title);
    }

    [Fact]
    public void InExecution_AddBacklogItem_Throws()
    {
        var sprint = SprintTestHelper.CreateInExecutionSprint();
        var member = SprintTestHelper.CreateMember();

        Assert.Throws<InvalidOperationException>(() =>
            sprint.AddBacklogItem("Feature A", "Description", member, sprint.Project, 5));
    }

    [Fact]
    public void InReview_AddBacklogItem_Throws()
    {
        var sprint = SprintTestHelper.CreateInReviewSprint();
        var member = SprintTestHelper.CreateMember();

        Assert.Throws<InvalidOperationException>(() =>
            sprint.AddBacklogItem("Feature A", "Description", member, sprint.Project, 5));
    }

    [Fact]
    public void Finished_AddBacklogItem_Throws()
    {
        var sprint = SprintTestHelper.CreateFinishedSprint();
        var member = SprintTestHelper.CreateMember();

        Assert.Throws<InvalidOperationException>(() =>
            sprint.AddBacklogItem("Feature A", "Description", member, sprint.Project, 5));
    }
}