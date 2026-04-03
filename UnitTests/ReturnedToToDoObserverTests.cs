using Avans_DevOps.domain;
using Avans_DevOps.domain.Notifications.Observer;
using Avans_DevOps.domain.Notifications.Strategy;
using Avans_DevOps.domain.WorkableState;
using Avans_DevOps.Infrastructure;
using Xunit;

namespace UnitTests;

public class ReturnedToTodoObserverTests
{
    [Fact]
    public void OnStateChanged_ToTodo_NotifiesScrumMaster()
    {
        var strategy = new EmailNotificationStrategy();

        var productOwner = new User("PO", "po@test.com", false, strategy);
        var developer = new User("Dev", "dev@test.com", false, strategy);
        var scrumMaster = new User("ScrumMaster", "amaster@test.com", false, strategy);

        var project = new Project("Project X", "Desc", "repo", new GitScm())
        {
            ProductOwner = productOwner
        };
        
        project.TeamMembers.Add(developer);
        project.AddSprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(7), Sprint.SprintType.DEVELOPMENT, scrumMaster);
        var sprint = project.Sprints.First();
        
        var item = new BacklogItem("Feature B", "Desc", developer, project);
        var observer = new ReturnedToTodoObserver(sprint);

        var output = ConsoleTestHelper.CaptureConsoleOutput(() =>
            observer.OnStateChanged(item, new TestingState(), new TodoState()));

        Assert.Contains("[SM NOTIFY]", output);
        Assert.Contains("SM", output);
        Assert.Contains("Feature B", output);
        Assert.Contains("TestingState", output);
        Assert.Contains("TodoState", output);
    }

    [Fact]
    public void OnStateChanged_NotToTodo_DoesNothing()
    {
        var strategy = new EmailNotificationStrategy();

        var productOwner = new User("PO", "po@test.com", false, strategy);
        var developer = new User("Dev", "dev@test.com", false, strategy);
        var scrumMaster = new User("ScrumMaster", "amaster@test.com", false, strategy);

        var project = new Project("Project X", "Desc", "repo", new GitScm())
        {
            ProductOwner = productOwner
        };
        
        project.TeamMembers.Add(developer);
        project.AddSprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(7), Sprint.SprintType.DEVELOPMENT, scrumMaster);
        var sprint = project.Sprints.First();


        var item = new BacklogItem("Feature B", "Desc", developer, project);
        var observer = new ReturnedToTodoObserver(sprint);

        var output = ConsoleTestHelper.CaptureConsoleOutput(() =>
            observer.OnStateChanged(item, new DoingState(), new ReadyForTestingState()));

        Assert.DoesNotContain("[PO NOTIFY]", output);
    }
}