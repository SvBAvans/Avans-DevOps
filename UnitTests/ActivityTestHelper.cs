using Avans_DevOps.domain;
using Avans_DevOps.domain.Notifications.Strategy;
using Avans_DevOps.Infrastructure;

namespace UnitTests;

public static class ActivityTestHelper
{
    public static Activity CreateActivity()
    {
        var strategy = new EmailNotificationStrategy();
        var scm = new GitScm();

        var productOwner = new User("PO", "po@test.com", false, strategy);
        var member = new User("Alice", "alice@test.com", false, strategy);

        var project = new Project("Project X", "Description", "repo", scm)
        {
            ProductOwner = productOwner
        };

        var backlogItem = new BacklogItem("Feature A", "Description", member, project);

        return new Activity("Activity 1", member, backlogItem);
    }

    public static Activity CreateTestingActivity()
    {
        var activity = CreateActivity();
        activity.StartWork();
        activity.MarkReadyForTesting();
        activity.MarkTesting();
        return activity;
    }

    public static Activity CreateReadyForTestingActivity()
    {
        var activity = CreateActivity();
        activity.StartWork();
        activity.MarkReadyForTesting();
        return activity;
    }
}