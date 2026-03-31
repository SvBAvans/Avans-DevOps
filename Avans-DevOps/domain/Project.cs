using Avans_DevOps.domain.Pipeline;
using Avans_DevOps.domain.SCM;
using Avans_DevOps.Infrastructure;
using Avans_DevOps.domain.Notifications.Observer;

namespace Avans_DevOps.domain;

public class Project(string name, string description, string repositoryPath, IScmAdapter scmAdapter)
{
    public string Name { get; } = name;
    public string Description { get; } = description;
    public bool IsActive { get; private set; } = true;
    
    public User ProductOwner { get; set; }
    public List<User> TeamMembers { get; } = [];
    
    public Backlog ProductBacklog { get; } = new();
    public List<Sprint> Sprints { get; } = [];

    public string RepositoryPath { get; } = repositoryPath;
    private readonly IScmAdapter scmAdapter = scmAdapter;
    
    //TODO: 
    // - Add "Sprint overzicht"
    // - SCM koppeling
    // - Pipeline config

    public void AddTeamMember(User member)
    {
        if (TeamMembers.Exists(member.IsSameUser) || ProductOwner.IsSameUser(member))
        {
            Console.WriteLine("TeamMember is already added to project");
            return;
        }
        TeamMembers.Add(member);
    }

    public void AddSprint(string name, DateTime startDate, DateTime endDate)
    {
        Sprints.Add(new Sprint(this, name, startDate, endDate));
    }
    
    public void SetInactive()
    {
        IsActive = false;
    }
    
    public void AddBacklogItem(string title, string description, User member)
    {
        var item = new BacklogItem(title, description, member, this);
        
        item.Subscribe(new ReturnedToTodoObserver(this));
        item.Subscribe(new ReadyForTestingObserver(this));
        
        ProductBacklog.AddItem(item);
    }

    public void CreateBranchForBacklogItem(BacklogItem item)
    {
        var branchName = $"feature/{item.Title}";
        scmAdapter.CreateBranch(RepositoryPath, branchName);
        item.LinkBranch(branchName);
    }

    public void CommitForBacklogItem(BacklogItem item, string commitDescription)
    {
        var message = $"{item.Title}: {commitDescription}";
        scmAdapter.Commit(RepositoryPath, message);
    }

    public IReadOnlyCollection<CommitInfo> GetCommitHistory()
    {
        return scmAdapter.GetCommits(RepositoryPath);
    }
}