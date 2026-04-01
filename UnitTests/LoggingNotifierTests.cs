using Avans_DevOps.domain;
using Avans_DevOps.domain.Notifications.Observer;
using Avans_DevOps.domain.Notifications.Strategy;
using Avans_DevOps.domain.WorkableState;
using Avans_DevOps.Infrastructure;
using Xunit;

namespace UnitTests;

public class LoggingNotifierTests
{
    [Fact]
    public void OnStateChanged_WritesCorrectLogMessage()
    {
        var user = new User("Dev", "dev@test.com", false, new EmailNotificationStrategy());

        var po = new User("Test", "test@test.com", false, new EmailNotificationStrategy());

        var project = new Project("Project X", "Desc", "repo", new GitScm())
        {
            ProductOwner = po
        };

        var item = new BacklogItem("Feature C", "Desc", user, project);

        var notifier = new LoggingNotifier();

        var output = ConsoleTestHelper.CaptureConsoleOutput(() =>
            notifier.OnStateChanged(item, new TodoState(), new DoingState()));

        Assert.Contains("[Logging-notifier]", output);
        Assert.Contains("TodoState", output);
        Assert.Contains("DoingState", output);
    }
}