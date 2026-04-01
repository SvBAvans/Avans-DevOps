using Avans_DevOps.domain;
using Avans_DevOps.domain.Notifications.Strategy;
using Avans_DevOps.domain.SCM;
using Avans_DevOps.Infrastructure;

namespace UnitTests;

public class DummyNotificationStrategy : INotificationStrategy
{
    public void Notify(User user, string message) { }
}

public class DummyScm : IScmAdapter
{
    public void CreateBranch(string repo, string branch) { }
    public void Commit(string repo, string message) { }
    public IReadOnlyCollection<CommitInfo> GetCommits(string repo) => [];
}

public static class TestHelper
{
    public static BacklogItem CreateItem()
    {
        var user = new User("Test", "test@test.com", false, new DummyNotificationStrategy());
        var project = new Project("Test", "Desc", "repo", new DummyScm());

        return new BacklogItem("Title", "Desc", user, project);
    }
}