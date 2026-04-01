using Avans_DevOps.domain;
using Avans_DevOps.domain.Notifications.Strategy;
using Xunit;

namespace UnitTests;

public class NotificationStrategyTests
{
    [Fact]
    public void EmailNotificationStrategy_WritesEmailOutput()
    {
        var strategy = new EmailNotificationStrategy();
        var user = new User("Alice", "alice@test.com", false, strategy);

        var output = ConsoleTestHelper.CaptureConsoleOutput(() =>
            strategy.Notify(user, "Hello email"));

        Assert.Contains("[EMAIL-NOTIFIER]", output);
        Assert.Contains("Alice", output);
        Assert.Contains("Hello email", output);
    }

    [Fact]
    public void SmsNotificationStrategy_WritesSmsOutput()
    {
        var strategy = new SmsNotificationStrategy();
        var user = new User("Bob", "bob@test.com", false, strategy);

        var output = ConsoleTestHelper.CaptureConsoleOutput(() =>
            strategy.Notify(user, "Hello sms"));

        Assert.Contains("[SMS-NOTIFIER]", output);
        Assert.Contains("Bob", output);
        Assert.Contains("Hello sms", output);
    }
}