using Avans_DevOps.domain;
using Avans_DevOps.domain.Notifications.Strategy;
using Xunit;

namespace UnitTests;

public class ProjectTests
{
    private static User CreateUser(string name, bool isTester = false)
    {
        return new User(name, $"{name.ToLower()}@test.com", isTester, new EmailNotificationStrategy());
    }

    private static Project CreateProject(SpyScmAdapter? scm = null)
    {
        scm ??= new SpyScmAdapter();

        var project = new Project("Project X", "Description", "repo-path", scm)
        {
            ProductOwner = CreateUser("ProductOwner")
        };

        return project;
    }

    [Fact]
    public void AddTeamMember_AddsNewMember()
    {
        var project = CreateProject();
        var member = CreateUser("Alice");

        project.AddTeamMember(member);

        Assert.Single(project.TeamMembers);
        Assert.Contains(member, project.TeamMembers);
    }

    [Fact]
    public void AddTeamMember_DoesNotAddDuplicateMember()
    {
        var project = CreateProject();
        var member = CreateUser("Alice");

        project.AddTeamMember(member);
        project.AddTeamMember(member);

        Assert.Single(project.TeamMembers);
    }

    [Fact]
    public void AddTeamMember_DoesNotAddProductOwnerAsTeamMember()
    {
        var project = CreateProject();

        project.AddTeamMember(project.ProductOwner);

        Assert.Empty(project.TeamMembers);
    }

    [Fact]
    public void AddSprint_AddsSprintToProject()
    {
        var project = CreateProject();

        project.AddSprint("Sprint 1", new DateTime(2025, 1, 1), new DateTime(2025, 1, 14), Sprint.SprintType.DEVELOPMENT);

        Assert.Single(project.Sprints);
        Assert.Equal("Sprint 1", project.Sprints[0].Name);
    }

    [Fact]
    public void SetInactive_SetsProjectInactive()
    {
        var project = CreateProject();

        project.SetInactive();

        Assert.False(project.IsActive);
    }

    [Fact]
    public void AddBacklogItem_AddsItemToProductBacklog()
    {
        var project = CreateProject();
        var member = CreateUser("Alice");
        project.AddTeamMember(member);

        project.AddBacklogItem("Feature A", "Implement feature A", member);

        Assert.Single(project.ProductBacklog.BacklogItems);
        Assert.Equal("Feature A", project.ProductBacklog.BacklogItems[0].Title);
        Assert.Equal("Implement feature A", project.ProductBacklog.BacklogItems[0].Description);
        Assert.Equal(member, project.ProductBacklog.BacklogItems[0].Member);
    }

    [Fact]
    public void CreateBranchForBacklogItem_CallsScmAdapterAndLinksBranch()
    {
        var scm = new SpyScmAdapter();
        var project = CreateProject(scm);
        var member = CreateUser("Alice");

        var item = new BacklogItem("LoginFeature", "Implement login", member, project);

        project.CreateBranchForBacklogItem(item);

        Assert.Equal("repo-path", scm.LastCreatedBranchRepositoryPath);
        Assert.Equal("feature/LoginFeature", scm.LastCreatedBranchName);
        Assert.Equal("feature/LoginFeature", item.BranchName);
    }

    [Fact]
    public void CommitForBacklogItem_CallsScmAdapterWithFormattedMessage()
    {
        var scm = new SpyScmAdapter();
        var project = CreateProject(scm);
        var member = CreateUser("Alice");

        var item = new BacklogItem("LoginFeature", "Implement login", member, project);

        project.CommitForBacklogItem(item, "Added validation");

        Assert.Equal("repo-path", scm.LastCommitRepositoryPath);
        Assert.Equal("LoginFeature: Added validation", scm.LastCommitMessage);
    }

    [Fact]
    public void GetCommitHistory_ReturnsCommitsFromScmAdapter()
    {
        var scm = new SpyScmAdapter();
        var project = CreateProject(scm);

        scm.Commit("repo-path", "First commit");
        scm.Commit("repo-path", "Second commit");

        var history = project.GetCommitHistory();

        Assert.Equal(2, history.Count);
        Assert.Contains(history, c => c.Message == "First commit");
        Assert.Contains(history, c => c.Message == "Second commit");
    }
}