using Avans_DevOps.Infrastructure;
using Avans_DevOps.domain.SCM;

namespace UnitTests;

public class ScmTests
{
    [Fact]
    public void GetCommits_ForUnknownRepository_ReturnsEmptyCollection()
    {
        var scm = new GitScm();

        var commits = scm.GetCommits("repo-1");

        Assert.Empty(commits);
    }

    [Fact]
    public void Commit_AddsCommitToRepository()
    {
        var scm = new GitScm();

        scm.Commit("repo-1", "Initial commit");

        var commits = scm.GetCommits("repo-1");

        Assert.Single(commits);
        Assert.Equal("Initial commit", commits.First().Message);
    }

    [Fact]
    public void Commit_GeneratesHashForCommit()
    {
        var scm = new GitScm();

        scm.Commit("repo-1", "Initial commit");

        var commit = scm.GetCommits("repo-1").First();

        Assert.False(string.IsNullOrWhiteSpace(commit.Hash));
        Assert.Equal(7, commit.Hash.Length);
    }

    [Fact]
    public void Commit_AddsMultipleCommitsInOrder()
    {
        var scm = new GitScm();

        scm.Commit("repo-1", "First commit");
        scm.Commit("repo-1", "Second commit");

        var commits = scm.GetCommits("repo-1").ToList();

        Assert.Equal(2, commits.Count);
        Assert.Equal("First commit", commits[0].Message);
        Assert.Equal("Second commit", commits[1].Message);
    }

    [Fact]
    public void Commits_AreStoredPerRepository()
    {
        var scm = new GitScm();

        scm.Commit("repo-1", "Commit repo 1");
        scm.Commit("repo-2", "Commit repo 2");

        var repo1Commits = scm.GetCommits("repo-1").ToList();
        var repo2Commits = scm.GetCommits("repo-2").ToList();

        Assert.Single(repo1Commits);
        Assert.Single(repo2Commits);
        Assert.Equal("Commit repo 1", repo1Commits[0].Message);
        Assert.Equal("Commit repo 2", repo2Commits[0].Message);
    }

    [Fact]
    public void GetCommits_ReturnsReadOnlyCollection()
    {
        var scm = new GitScm();

        scm.Commit("repo-1", "Initial commit");

        var commits = scm.GetCommits("repo-1");

        Assert.IsAssignableFrom<IReadOnlyCollection<CommitInfo>>(commits);
    }

    [Fact]
    public void CreateBranch_DoesNotThrow()
    {
        var scm = new GitScm();

        var exception = Record.Exception(() => scm.CreateBranch("repo-1", "feature/test"));

        Assert.Null(exception);
    }

    [Fact]
    public void Commit_DifferentRepositories_DoNotShareState()
    {
        var scm = new GitScm();

        scm.Commit("repo-a", "A1");
        scm.Commit("repo-a", "A2");
        scm.Commit("repo-b", "B1");

        Assert.Equal(2, scm.GetCommits("repo-a").Count);
        Assert.Equal(1, scm.GetCommits("repo-b").Count);
    }

    [Fact]
    public void Commit_TwoCommits_HaveDifferentHashes()
    {
        var scm = new GitScm();

        scm.Commit("repo-1", "Commit 1");
        scm.Commit("repo-1", "Commit 2");

        var commits = scm.GetCommits("repo-1").ToList();

        Assert.NotEqual(commits[0].Hash, commits[1].Hash);
    }

    [Fact]
    public void Commit_ViaAdapterInterface_AddsCommit()
    {
        IScmAdapter scm = new GitScm();

        scm.Commit("repo-1", "Interface commit");

        var commits = scm.GetCommits("repo-1");

        Assert.Single(commits);
        Assert.Equal("Interface commit", commits.First().Message);
    }
}