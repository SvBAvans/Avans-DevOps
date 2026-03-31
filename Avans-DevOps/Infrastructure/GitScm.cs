using Avans_DevOps.domain.SCM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_DevOps.Infrastructure
{
    public class GitScm : IScmAdapter
    {
        private readonly Dictionary<string, List<CommitInfo>> _commitsByRepo = [];

        public void Commit(string repositoryPath, string message)
        {
            if (!_commitsByRepo.TryGetValue(repositoryPath, out var commits))
            {
                commits = [];
                _commitsByRepo[repositoryPath] = commits;
            }

            var fakeHash = Guid.NewGuid().ToString("N")[..7];
            _commitsByRepo[repositoryPath].Add(new CommitInfo(fakeHash, message));

            Console.WriteLine($"[StubGit] Commit '{message}' added to repo '{repositoryPath}'");
        }

        public void CreateBranch(string repositoryPath, string branchName)
        {
            Console.WriteLine($"[StubGit] Created branch '{branchName}' in repo '{repositoryPath}'");
        }

        public IReadOnlyCollection<CommitInfo> GetCommits(string repositoryPath)
        {
            if (!_commitsByRepo.TryGetValue(repositoryPath, out var commits))
            {
                return [];
            }

            return commits.AsReadOnly();
        }
    }
}
