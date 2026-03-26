namespace Avans_DevOps.domain;

public class Activity(string name, User member)
{
    public string name { get; set; } = name;
    public User member {get; set;} = member;
}