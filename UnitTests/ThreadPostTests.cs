using Avans_DevOps.domain;
using Avans_DevOps.domain.Discussions;
using Avans_DevOps.domain.Notifications.Strategy;
using Xunit;

namespace UnitTests;

public class ThreadPostTests
{
    [Fact]
    public void AddComment_AddsReplyToComments()
    {
        var author = new User("Alice", "alice@test.com", false, new EmailNotificationStrategy());
        var item = TestHelper.CreateItem();

        var parentPost = new ThreadPost("Original post", item)
        {
            Author = author
        };

        parentPost.AddComment("Reply message", author);

        var comments = parentPost.GetComments();

        Assert.Single(comments);
        Assert.Equal("Reply message", comments[0].Content);
    }

    [Fact]
    public void AddComment_SetsParentPostOnReply()
    {
        var author = new User("Alice", "alice@test.com", false, new EmailNotificationStrategy());
        var item = TestHelper.CreateItem();

        var parentPost = new ThreadPost("Original post", item)
        {
            Author = author
        };

        parentPost.AddComment("Reply message", author);

        var reply = parentPost.GetComments().Single();

        Assert.Same(parentPost, reply.ParentPost);
    }

    [Fact]
    public void AddComment_NotifiesSubscribedObservers()
    {
        var author = new User("Alice", "alice@test.com", false, new EmailNotificationStrategy());
        var item = TestHelper.CreateItem();

        var parentPost = new ThreadPost("Original post", item)
        {
            Author = author
        };

        var observer = new SpyDiscussionObserver();
        parentPost.Subscribe(observer);

        parentPost.AddComment("Reply message", author);

        Assert.Equal(1, observer.CallCount);
        Assert.NotNull(observer.LastPost);
        Assert.Equal("Reply message", observer.LastPost!.Content);
    }

    [Fact]
    public void AddComment_OnClosedBacklogItem_Throws()
    {
        var author = new User("Alice", "alice@test.com", false, new EmailNotificationStrategy());
        var item = TestHelper.CreateItem();
        item.IsClosed = true;

        var parentPost = new ThreadPost("Original post", item)
        {
            Author = author
        };

        Assert.Throws<InvalidOperationException>(() =>
            parentPost.AddComment("Reply message", author));
    }
}