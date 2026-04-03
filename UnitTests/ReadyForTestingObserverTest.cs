using Avans_DevOps.domain;
using Avans_DevOps.domain.Notifications.Observer;
using Avans_DevOps.domain.Notifications.Strategy;
using Avans_DevOps.domain.WorkableState;
using Avans_DevOps.Infrastructure;
using Xunit;

namespace UnitTests;

public class ReadyForTestingObserverTests
{
    [Fact]
    public void OnStateChanged_ReadyForTesting_NotifiesOnlyTesters()
    {
        var strategy = new EmailNotificationStrategy();

        var tester = new User("Tester", "tester@test.com", true, strategy);
        var developer = new User("Developer", "dev@test.com", false, strategy);
        var productOwner = new User("PO", "po@test.com", false, strategy);

        var project = new Project("Project X", "Desc", "repo", new GitScm())
        {
            ProductOwner = productOwner
        };

        project.TeamMembers.Add(tester);
        project.TeamMembers.Add(developer);

        var item = new BacklogItem("Feature A", "Desc", developer, project);

        var observer = new ReadyForTestingObserver(project);

        var output = ConsoleTestHelper.CaptureConsoleOutput(() =>
            observer.OnStateChanged(item, new DoingState(), new ReadyForTestingState()));

        Assert.Contains("[TESTER NOTIFY]", output);
        Assert.Contains("Tester", output);
        Assert.Contains("Feature A", output);
        Assert.DoesNotContain("Developer", output);
    }

    [Fact]
    public void OnStateChanged_NotReadyForTesting_DoesNothing()
    {
        var strategy = new EmailNotificationStrategy();

        var tester = new User("Tester", "tester@test.com", true, strategy);
        var developer = new User("Developer", "dev@test.com", false, strategy);

        var user = new User("Test", "test@test.com", false, new EmailNotificationStrategy());

        var project = new Project("Project X", "Desc", "repo", new GitScm())
        {
            ProductOwner = user
        };

        project.TeamMembers.Add(tester);
        project.TeamMembers.Add(developer);

        var item = new BacklogItem("Feature A", "Desc", developer, project);
        var observer = new ReadyForTestingObserver(project);

        var output = ConsoleTestHelper.CaptureConsoleOutput(() =>
            observer.OnStateChanged(item, new TodoState(), new DoingState()));

        Assert.DoesNotContain("[TESTER NOTIFY]", output);
    }
}