namespace Avans_DevOps.domain;

public class User(string name, string email)
{
    public string Name { get; } = name;
    public string Email { get; } = email;

    public bool IsSameUser(User user)
    {
        return Email == user.Email;
    }
}