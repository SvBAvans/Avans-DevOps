namespace UnitTests.states;

public class TestedStateTests
{
    [Fact]
    public void Tested_ApproveDone_GoesToDone()
    {
        var item = TestHelper.CreateTestedItem();

        item.ApproveDone();

        Assert.Equal("DoneState", item.GetStateName());
    }

    [Fact]
    public void Tested_ReturnToTodo_GoesToTodo()
    {
        var item = TestHelper.CreateTestedItem();

        item.ReturnToTodo();

        Assert.Equal("TodoState", item.GetStateName());
    }

    [Fact]
    public void Tested_StartWork_Throws()
    {
        var item = TestHelper.CreateTestedItem();

        Assert.Throws<InvalidOperationException>(() => item.StartWork());
    }

    [Fact]
    public void Tested_MarkReadyForTesting_Throws()
    {
        var item = TestHelper.CreateTestedItem();

        Assert.Throws<InvalidOperationException>(() => item.MarkReadyForTesting());
    }

    [Fact]
    public void Tested_MarkTesting_Throws()
    {
        var item = TestHelper.CreateTestedItem();

        Assert.Throws<InvalidOperationException>(() => item.MarkTesting());
    }

    [Fact]
    public void Tested_MarkTested_Throws()
    {
        var item = TestHelper.CreateTestedItem();

        Assert.Throws<InvalidOperationException>(() => item.MarkTested());
    }
}