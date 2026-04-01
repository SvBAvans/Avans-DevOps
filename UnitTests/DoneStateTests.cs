namespace UnitTests;

public class DoneStateTests
{
    [Fact]
    public void Done_ReturnToTodo_GoesToTodo()
    {
        var item = TestHelper.CreateDoneItem();

        item.ReturnToTodo();

        Assert.Equal("TodoState", item.GetStateName());
    }

    [Fact]
    public void Done_StartWork_Throws()
    {
        var item = TestHelper.CreateDoneItem();

        Assert.Throws<InvalidOperationException>(() => item.StartWork());
    }

    [Fact]
    public void Done_MarkReadyForTesting_Throws()
    {
        var item = TestHelper.CreateDoneItem();

        Assert.Throws<InvalidOperationException>(() => item.MarkReadyForTesting());
    }

    [Fact]
    public void Done_MarkTesting_Throws()
    {
        var item = TestHelper.CreateDoneItem();

        Assert.Throws<InvalidOperationException>(() => item.MarkTesting());
    }

    [Fact]
    public void Done_MarkTested_Throws()
    {
        var item = TestHelper.CreateDoneItem();

        Assert.Throws<InvalidOperationException>(() => item.MarkTested());
    }

    [Fact]
    public void Done_ApproveDone_Throws()
    {
        var item = TestHelper.CreateDoneItem();

        Assert.Throws<InvalidOperationException>(() => item.ApproveDone());
    }
}