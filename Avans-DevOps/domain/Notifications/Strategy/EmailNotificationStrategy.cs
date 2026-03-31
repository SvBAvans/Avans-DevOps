namespace Avans_DevOps.domain.Notifications.Strategy
{
    public class EmailNotificationStrategy : INotificationStrategy
    {
        public void Notify(User user, string message)
        {
            Console.WriteLine("[EMAIL-NOTIFIER] - " + message);
        }
    }
}
