namespace UnitTests;

public class DoingStateTests
{
    [Fact]
    public void Doing_MarkReadyForTesting_GoesToReadyForTesting()
    {
        var item = TestHelper.CreateDoingItem();

        item.MarkReadyForTesting();

        Assert.Equal("ReadyForTestingState", item.GetStateName());
    }

    [Fact]
    public void Doing_StartWork_Throws()
    {
        var item = TestHelper.CreateDoingItem();

        Assert.Throws<InvalidOperationException>(() => item.StartWork());
    }

    [Fact]
    public void Doing_MarkTesting_Throws()
    {
        var item = TestHelper.CreateDoingItem();

        Assert.Throws<InvalidOperationException>(() => item.MarkTesting());
    }

    [Fact]
    public void Doing_MarkTested_Throws()
    {
        var item = TestHelper.CreateDoingItem();

        Assert.Throws<InvalidOperationException>(() => item.MarkTested());
    }

    [Fact]
    public void Doing_ApproveDone_Throws()
    {
        var item = TestHelper.CreateDoingItem();

        Assert.Throws<InvalidOperationException>(() => item.ApproveDone());
    }

    [Fact]
    public void Doing_ReturnToTodo_GoesToTodo()
    {
        var item = TestHelper.CreateDoingItem();

        item.ReturnToTodo();

        Assert.Equal("TodoState", item.GetStateName());
    }
}