using Avans_DevOps.domain.Notifications.Strategy;

namespace Avans_DevOps.domain;

public class User(string name, string email, bool isTester, INotificationStrategy notificationStrategy)
{
    public string Name { get; } = name;
    public string Email { get; } = email;
    public bool IsTester { get; } = isTester;

    public bool IsSameUser(User user)
    {
        return Email == user.Email;
    }

    private INotificationStrategy notificationStrategy = notificationStrategy;
    public void SendNotification(string message)
    {
        notificationStrategy.Notify(this, message);
    }
}