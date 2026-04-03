using Avans_DevOps.domain;
using Avans_DevOps.domain.Discussions;
using Avans_DevOps.domain.Notifications.Observer;
using Avans_DevOps.domain.Notifications.Strategy;
using Avans_DevOps.Infrastructure;
using Xunit;

namespace UnitTests;

public class CommentNotificationObserverTests
{
    [Fact]
    public void OnPostAdded_TopLevelComment_NotifiesProductOwnerAndTeamExceptAuthor()
    {
        var strategy = new EmailNotificationStrategy();

        var author = new User("Alice", "alice@test.com", false, strategy);
        var teammate = new User("Bob", "bob@test.com", false, strategy);
        var productOwner = new User("PO", "po@test.com", false, strategy);

        var project = new Project("Project X", "Desc", "repo", new GitScm())
        { ProductOwner = productOwner };

        project.TeamMembers.Add(author);
        project.TeamMembers.Add(teammate);

        var item = new BacklogItem("Feature D", "Desc", author, project, 10);

        var post = new ThreadPost("This needs clarification", item)
        {
            Author = author
        };

        var observer = new CommentNotificationObserver();

        var output = ConsoleTestHelper.CaptureConsoleOutput(() =>
            observer.OnPostAdded(post));

        Assert.Contains("[Discussion Notify]", output);
        Assert.Contains("Alice commented on BacklogItem", output);
        Assert.Contains("PO", output);
        Assert.Contains("Bob", output);
        Assert.DoesNotContain("for Alice", output);
    }

    [Fact]
    public void OnPostAdded_WhenAuthorIsProductOwner_DoesNotNotifyProductOwnerAgain()
    {
        var strategy = new EmailNotificationStrategy();

        var teammate = new User("Bob", "bob@test.com", false, strategy);
        var productOwner = new User("PO", "po@test.com", false, strategy);

        var project = new Project("Project X", "Desc", "repo", new GitScm())
        { ProductOwner = productOwner };

        project.TeamMembers.Add(teammate);

        var item = new BacklogItem("Feature E", "Desc", teammate, project, 10);

        var post = new ThreadPost("PO feedback", item)
        {
            Author = productOwner
        };

        var observer = new CommentNotificationObserver();

        var output = ConsoleTestHelper.CaptureConsoleOutput(() =>
            observer.OnPostAdded(post));

        Assert.Contains("Bob", output);
        Assert.DoesNotContain("for PO", output);
    }

    [Fact]
    public void OnPostAdded_Reply_UsesReplyMessageFormat()
    {
        var strategy = new EmailNotificationStrategy();

        var author = new User("Alice", "alice@test.com", false, strategy);
        var teammate = new User("Bob", "bob@test.com", false, strategy);
        var productOwner = new User("PO", "po@test.com", false, strategy);

        var project = new Project("Project X", "Desc", "repo", new GitScm())
        {
            ProductOwner = productOwner
        };

        project.TeamMembers.Add(author);
        project.TeamMembers.Add(teammate);

        var item = new BacklogItem("Feature F", "Desc", author, project, 10);

        var parentPost = new ThreadPost("Original post", item)
        {
            Author = teammate
        };

        var observer = new CommentNotificationObserver();
        parentPost.Subscribe(observer);

        var output = ConsoleTestHelper.CaptureConsoleOutput(() =>
            parentPost.AddComment("Reply message", author));

        Assert.Contains("commented a post", output);
        Assert.Contains("Reply message", output);
    }
}