namespace Avans_DevOps.domain.Notifications;

public interface INotificationStrategy
{
    void Notify(string message);
}