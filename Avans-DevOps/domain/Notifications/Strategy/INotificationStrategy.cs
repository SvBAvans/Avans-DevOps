namespace Avans_DevOps.domain.Notifications.Strategy;

public interface INotificationStrategy
{
    void Notify(User user, string message);
}