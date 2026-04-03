using Avans_DevOps.domain;
using Xunit;

namespace UnitTests;

public class BacklogItemApproveDoneTests
{
    [Fact]
    public void ApproveDone_WhenNotAllActivitiesAreDone_Throws()
    {
        var item = TestHelper.CreateItem();

        item.AddActivity("Activity 1", item.Member);
        item.AddActivity("Activity 2", item.Member);

        var first = item.Activities[0];
        first.StartWork();
        first.MarkReadyForTesting();
        first.MarkTesting();
        first.MarkTested();
        first.ApproveDone();

        item.StartWork();
        item.MarkReadyForTesting();
        item.MarkTesting();
        item.MarkTested();

        var ex = Assert.Throws<InvalidOperationException>(() => item.ApproveDone());

        Assert.Equal("Not all activities are marked as 'Done'", ex.Message);
    }

    [Fact]
    public void ApproveDone_WhenAllActivitiesAreDone_GoesToDone()
    {
        var item = TestHelper.CreateItem();

        item.AddActivity("Activity 1", item.Member);
        item.AddActivity("Activity 2", item.Member);

        foreach (var activity in item.Activities)
        {
            activity.StartWork();
            activity.MarkReadyForTesting();
            activity.MarkTesting();
            activity.MarkTested();
            activity.ApproveDone();
        }

        item.StartWork();
        item.MarkReadyForTesting();
        item.MarkTesting();
        item.MarkTested();
        item.ApproveDone();

        Assert.Equal("DoneState", item.GetStateName());
    }

    [Fact]
    public void ApproveDone_WhenThereAreNoActivities_UsesNormalStateFlow()
    {
        var item = TestHelper.CreateItem();

        item.StartWork();
        item.MarkReadyForTesting();
        item.MarkTesting();
        item.MarkTested();
        item.ApproveDone();

        Assert.Equal("DoneState", item.GetStateName());
    }

    [Fact]
    public void ApproveDone_WhenActivityIsStillTodo_Throws()
    {
        var item = TestHelper.CreateItem();

        item.AddActivity("Activity 1", item.Member);

        item.StartWork();
        item.MarkReadyForTesting();
        item.MarkTesting();
        item.MarkTested();

        var ex = Assert.Throws<InvalidOperationException>(() => item.ApproveDone());

        Assert.Equal("Not all activities are marked as 'Done'", ex.Message);
    }
}