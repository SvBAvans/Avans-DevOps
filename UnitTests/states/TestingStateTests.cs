namespace UnitTests;

public class TestingStateTests
{
    [Fact]
    public void Testing_MarkTested_GoesToTested()
    {
        var item = TestHelper.CreateTestingItem();

        item.MarkTested();

        Assert.Equal("TestedState", item.GetStateName());
    }

    [Fact]
    public void Testing_ReturnToTodo_GoesToTodo()
    {
        var item = TestHelper.CreateTestingItem();

        item.ReturnToTodo();

        Assert.Equal("TodoState", item.GetStateName());
    }

    [Fact]
    public void Testing_StartWork_Throws()
    {
        var item = TestHelper.CreateTestingItem();

        Assert.Throws<InvalidOperationException>(() => item.StartWork());
    }

    [Fact]
    public void Testing_MarkReadyForTesting_Throws()
    {
        var item = TestHelper.CreateTestingItem();

        Assert.Throws<InvalidOperationException>(() => item.MarkReadyForTesting());
    }

    [Fact]
    public void Testing_MarkTesting_Throws()
    {
        var item = TestHelper.CreateTestingItem();

        Assert.Throws<InvalidOperationException>(() => item.MarkTesting());
    }

    [Fact]
    public void Testing_ApproveDone_Throws()
    {
        var item = TestHelper.CreateTestingItem();

        Assert.Throws<InvalidOperationException>(() => item.ApproveDone());
    }
}