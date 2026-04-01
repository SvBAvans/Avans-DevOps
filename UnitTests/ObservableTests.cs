using Avans_DevOps.domain;
using Xunit;

namespace UnitTests;

public class ObservableTests
{
    [Fact]
    public void Subscribe_StateChange_CallsObserver()
    {
        var item = TestHelper.CreateItem();
        var observer = new SpyStateObserver();

        item.Subscribe(observer);

        item.StartWork();

        Assert.Equal(1, observer.CallCount);
    }

    [Fact]
    public void Unsubscribe_StateChange_DoesNotCallObserver()
    {
        var item = TestHelper.CreateItem();
        var observer = new SpyStateObserver();

        item.Subscribe(observer);
        item.Unsubscribe(observer);

        item.StartWork();

        Assert.Equal(0, observer.CallCount);
    }
}