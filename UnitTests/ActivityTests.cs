using Xunit;

namespace UnitTests;

public class ActivityTests
{
    [Fact]
    public void MarkTested_FromTesting_GoesToTested()
    {
        var activity = ActivityTestHelper.CreateTestingActivity();

        activity.MarkTested();

        Assert.Equal("TestedState", activity.GetStateName());
    }

    [Fact]
    public void ReturnToTodo_FromReadyForTesting_GoesToTodo()
    {
        var activity = ActivityTestHelper.CreateReadyForTestingActivity();

        activity.ReturnToTodo();

        Assert.Equal("TodoState", activity.GetStateName());
    }

    [Fact]
    public void Unsubscribe_RemovesObserver_SoItIsNotCalledOnStateChange()
    {
        var activity = ActivityTestHelper.CreateActivity();
        var observer = new SpyStateObserver();

        activity.Subscribe(observer);
        activity.Unsubscribe(observer);

        activity.StartWork();

        Assert.Equal(0, observer.CallCount);
    }

    [Fact]
    public void ReturnToTodo_FromDoing_GoesToTodo()
    {
        var activity = ActivityTestHelper.CreateActivity();
        activity.StartWork();

        activity.ReturnToTodo();

        Assert.Equal("TodoState", activity.GetStateName());
    }

    [Fact]
    public void MarkTested_FromTodo_ThrowsInvalidOperationException()
    {
        var activity = ActivityTestHelper.CreateActivity();

        Assert.Throws<InvalidOperationException>(() => activity.MarkTested());
    }
}