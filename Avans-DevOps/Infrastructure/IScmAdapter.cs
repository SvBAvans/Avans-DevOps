using Avans_DevOps.domain.SCM;

namespace Avans_DevOps.Infrastructure
{
    public interface IScmAdapter
    {
        void CreateBranch(string repositoryPath, string branchName);
        void Commit(string repositoryPath, string message);
        IReadOnlyCollection<CommitInfo> GetCommits(string repositoryPath);
    }
}
