namespace UnitTests.states;

public class TodoStateTests
{
    [Fact]
    public void Todo_StartWork_GoesToDoing()
    {
        var item = TestHelper.CreateItem();

        item.StartWork();

        Assert.Equal("DoingState", item.GetStateName());
    }

    [Fact]
    public void Todo_MarkReadyForTesting_Throws()
    {
        var item = TestHelper.CreateItem();

        Assert.Throws<InvalidOperationException>(() => item.MarkReadyForTesting());
    }

    [Fact]
    public void Todo_MarkTesting_Throws()
    {
        var item = TestHelper.CreateItem();

        Assert.Throws<InvalidOperationException>(() => item.MarkTesting());
    }

    [Fact]
    public void Todo_MarkTested_Throws()
    {
        var item = TestHelper.CreateItem();

        Assert.Throws<InvalidOperationException>(() => item.MarkTested());
    }

    [Fact]
    public void Todo_ApproveDone_Throws()
    {
        var item = TestHelper.CreateItem();

        Assert.Throws<InvalidOperationException>(() => item.ApproveDone());
    }

    [Fact]
    public void Todo_ReturnToTodo_StaysTodo()
    {
        var item = TestHelper.CreateItem();

        Assert.Throws<InvalidOperationException>(() => item.ReturnToTodo());
    }
}