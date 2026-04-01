namespace UnitTests.states;

public class ReadyForTestingStateTests
{
    [Fact]
    public void ReadyForTesting_MarkTesting_GoesToTesting()
    {
        var item = TestHelper.CreateReadyForTestingItem();

        item.MarkTesting();

        Assert.Equal("TestingState", item.GetStateName());
    }

    [Fact]
    public void ReadyForTesting_ReturnToTodo_GoesToTodo()
    {
        var item = TestHelper.CreateReadyForTestingItem();

        item.ReturnToTodo();

        Assert.Equal("TodoState", item.GetStateName());
    }

    [Fact]
    public void ReadyForTesting_StartWork_Throws()
    {
        var item = TestHelper.CreateReadyForTestingItem();

        Assert.Throws<InvalidOperationException>(() => item.StartWork());
    }

    [Fact]
    public void ReadyForTesting_MarkReadyForTesting_Throws()
    {
        var item = TestHelper.CreateReadyForTestingItem();

        Assert.Throws<InvalidOperationException>(() => item.MarkReadyForTesting());
    }

    [Fact]
    public void ReadyForTesting_MarkTested_Throws()
    {
        var item = TestHelper.CreateReadyForTestingItem();

        Assert.Throws<InvalidOperationException>(() => item.MarkTested());
    }

    [Fact]
    public void ReadyForTesting_ApproveDone_Throws()
    {
        var item = TestHelper.CreateReadyForTestingItem();

        Assert.Throws<InvalidOperationException>(() => item.ApproveDone());
    }
}