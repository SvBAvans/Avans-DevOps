namespace Avans_DevOps.domain;

public class Activity(string name, User member, BacklogItem parent)
{
    public string Name { get; set; } = name;
    public User Member {get; set;} = member;
    public BacklogItem Parent { get; set; } = parent;
    
    //TODO: Same states as BackLogItem. 😭
}