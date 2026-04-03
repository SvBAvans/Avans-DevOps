using Avans_DevOps.domain;
using Avans_DevOps.domain.Notifications.Strategy;
using Avans_DevOps.Infrastructure;

namespace UnitTests;

public class BacklogItemTests
{
    [Fact]
    public void AddComment_OpenBacklogItem_AddsComment()
    {
        var author = new User("Alice", "alice@test.com", false, new EmailNotificationStrategy());
        var project = new Project("Project X", "Description", "repo", new GitScm())
        {
            ProductOwner = new User("PO", "po@test.com", false, new EmailNotificationStrategy())
        };

        project.AddTeamMember(author);

        var item = new BacklogItem("Feature A", "Description", author, project, 10);

        item.AddComment("This needs clarification", author);

        Assert.Single(item.GetComments);

        var comment = item.GetComments[0];
        Assert.Equal("This needs clarification", comment.Content);
        Assert.Equal(author, comment.Author);
        Assert.Equal(item, comment.BacklogItem);
        Assert.Null(comment.ParentPost);
    }

    [Fact]
    public void AddComment_ClosedBacklogItem_ThrowsInvalidOperationException()
    {
        var author = new User("Alice", "alice@test.com", false, new EmailNotificationStrategy());
        var project = new Project("Project X", "Description", "repo", new GitScm())
        {
            ProductOwner = new User("PO", "po@test.com", false, new EmailNotificationStrategy())
        };

        var item = new BacklogItem("Feature A", "Description", author, project, 10)
        {
            IsClosed = true
        };

        var ex = Assert.Throws<InvalidOperationException>(() =>
            item.AddComment("This should fail", author));

        Assert.Equal("Cannot comment on closed backlog item", ex.Message);
        Assert.Empty(item.GetComments);
    }

    [Fact]
    public void AddComment_OpenBacklogItem_TriggersDiscussionNotification()
    {
        var strategy = new EmailNotificationStrategy();

        var author = new User("Alice", "alice@test.com", false, strategy);
        var teammate = new User("Bob", "bob@test.com", false, strategy);
        var productOwner = new User("PO", "po@test.com", false, strategy);

        var project = new Project("Project X", "Description", "repo", new GitScm())
        {
            ProductOwner = productOwner
        };

        project.AddTeamMember(author);
        project.AddTeamMember(teammate);

        var item = new BacklogItem("Feature A", "Description", author, project, 10);

        var output = ConsoleTestHelper.CaptureConsoleOutput(() =>
            item.AddComment("This needs clarification", author));

        Assert.Contains("[Discussion Notify]", output);
        Assert.Contains("This needs clarification", output);
    }
}