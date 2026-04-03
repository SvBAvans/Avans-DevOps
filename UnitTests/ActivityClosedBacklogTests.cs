using Avans_DevOps.domain;
using Xunit;

namespace UnitTests;

public class ActivityClosedBacklogTests
{
    private static Activity CreateClosedParentActivity()
    {
        var activity = ActivityTestHelper.CreateActivity();
        activity.Parent.IsClosed = true;
        return activity;
    }

    [Fact]
    public void StartWork_WhenParentBacklogItemIsClosed_Throws()
    {
        var activity = CreateClosedParentActivity();

        var ex = Assert.Throws<InvalidOperationException>(() => activity.StartWork());

        Assert.Equal("BacklogItem is closed", ex.Message);
    }

    [Fact]
    public void MarkReadyForTesting_WhenParentBacklogItemIsClosed_Throws()
    {
        var activity = CreateClosedParentActivity();

        var ex = Assert.Throws<InvalidOperationException>(() => activity.MarkReadyForTesting());

        Assert.Equal("BacklogItem is closed", ex.Message);
    }

    [Fact]
    public void MarkTesting_WhenParentBacklogItemIsClosed_Throws()
    {
        var activity = CreateClosedParentActivity();

        var ex = Assert.Throws<InvalidOperationException>(() => activity.MarkTesting());

        Assert.Equal("BacklogItem is closed", ex.Message);
    }

    [Fact]
    public void MarkTested_WhenParentBacklogItemIsClosed_Throws()
    {
        var activity = CreateClosedParentActivity();

        var ex = Assert.Throws<InvalidOperationException>(() => activity.MarkTested());

        Assert.Equal("BacklogItem is closed", ex.Message);
    }

    [Fact]
    public void ApproveDone_WhenParentBacklogItemIsClosed_Throws()
    {
        var activity = CreateClosedParentActivity();

        var ex = Assert.Throws<InvalidOperationException>(() => activity.ApproveDone());

        Assert.Equal("BacklogItem is closed", ex.Message);
    }

    [Fact]
    public void ReturnToTodo_WhenParentBacklogItemIsClosed_Throws()
    {
        var activity = CreateClosedParentActivity();

        var ex = Assert.Throws<InvalidOperationException>(() => activity.ReturnToTodo());

        Assert.Equal("BacklogItem is closed", ex.Message);
    }
}