using Avans_DevOps.domain.Notifications;

namespace Avans_DevOps.domain;

public class Project(string name, string description)
{
    public string Name { get; } = name;
    public string Description { get; } = description;
    public bool IsActive { get; private set; } = true;
    
    public User ProductOwner { get; set; }
    public List<User> TeamMembers { get; } = [];
    
    public Backlog ProductBacklog { get; } = new();
    public List<Sprint> Sprints { get; } = [];
    
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

    public void AddSprint(Sprint sprint)
    {
        Sprints.Add(sprint);
    }
    
    public void SetInactive()
    {
        IsActive = false;
    }
    
    public void AddBacklogItem(BacklogItem item)
    {
        item.Subscribe(new ReturnedToTodoObserver(this));
        item.Subscribe(new ReadyForTestingObserver(this));
    }
}