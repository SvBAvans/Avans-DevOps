namespace UnitTests;

public class BacklogItemStateFlowTests
{
    [Fact]
    public void FullFlow_ToDone_Works()
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
    public void Cannot_Skip_From_Todo_To_Testing()
    {
        var item = TestHelper.CreateItem();

        Assert.Throws<InvalidOperationException>(() =>
            item.MarkTesting());
    }
    
    [Fact]
    public void Cannot_Start_When_Doing()
    {
        var item = TestHelper.CreateItem();

        item.StartWork();

        Assert.Throws<InvalidOperationException>(() =>
            item.StartWork());
    }
    
    [Fact]
    public void Cannot_Approve_When_Not_Tested()
    {
        var item = TestHelper.CreateItem();

        item.StartWork();

        Assert.Throws<InvalidOperationException>(() =>
            item.ApproveDone());
    }
    
    [Fact]
    public void ReturnToTodo_From_AnyState_Works()
    {
        var item = TestHelper.CreateItem();

        item.StartWork();
        item.ReturnToTodo();

        Assert.Equal("TodoState", item.GetStateName());
    }
    
    [Fact]
    public void Done_Is_Protected()
    {
        var item = TestHelper.CreateItem();

        item.StartWork();
        item.MarkReadyForTesting();
        item.MarkTesting();
        item.MarkTested();
        item.ApproveDone();

        Assert.Throws<InvalidOperationException>(() =>
            item.StartWork());
    }
}