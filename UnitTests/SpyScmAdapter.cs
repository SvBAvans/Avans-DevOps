using Avans_DevOps.domain.SCM;
using Avans_DevOps.Infrastructure;

namespace UnitTests;

public class SpyScmAdapter : IScmAdapter
{
    public string? LastCreatedBranchRepositoryPath { get; private set; }
    public string? LastCreatedBranchName { get; private set; }

    public string? LastCommitRepositoryPath { get; private set; }
    public string? LastCommitMessage { get; private set; }

    public List<CommitInfo> Commits { get; } = new();

    public void CreateBranch(string repositoryPath, string branchName)
    {
        LastCreatedBranchRepositoryPath = repositoryPath;
        LastCreatedBranchName = branchName;
    }

    public void Commit(string repositoryPath, string message)
    {
        LastCommitRepositoryPath = repositoryPath;
        LastCommitMessage = message;
        Commits.Add(new CommitInfo("abc1234", message));
    }

    public IReadOnlyCollection<CommitInfo> GetCommits(string repositoryPath)
    {
        return Commits.AsReadOnly();
    }
}