using Avans_DevOps.domain;
using Avans_DevOps.domain.Notifications.Strategy;
using Avans_DevOps.Infrastructure;

namespace UnitTests;

public static class TestHelper
{
    public static BacklogItem CreateItem()
    {
        var user = new User("Test", "test@test.com", false, new EmailNotificationStrategy());
        var project = new Project("Test", "Desc", "repo", new GitScm())
        {
            ProductOwner = user
        };

        return new BacklogItem("Title", "Desc", user, project, 10);
    }

    public static BacklogItem CreateDoingItem()
    {
        var item = CreateItem();
        item.StartWork();
        return item;
    }

    public static BacklogItem CreateReadyForTestingItem()
    {
        var item = CreateDoingItem();
        item.MarkReadyForTesting();
        return item;
    }

    public static BacklogItem CreateTestingItem()
    {
        var item = CreateReadyForTestingItem();
        item.MarkTesting();
        return item;
    }

    public static BacklogItem CreateTestedItem()
    {
        var item = CreateTestingItem();
        item.MarkTested();
        return item;
    }

    public static BacklogItem CreateDoneItem()
    {
        var item = CreateTestedItem();
        item.ApproveDone();
        return item;
    }
}