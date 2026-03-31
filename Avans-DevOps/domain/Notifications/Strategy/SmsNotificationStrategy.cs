namespace Avans_DevOps.domain.Notifications.Strategy
{
    public class SmsNotificationStrategy : INotificationStrategy
    {
        public void Notify(User user, string message)
        {
            Console.WriteLine($"[SMS-NOTIFIER] for {user.Name} - {message}");
        }
    }
}
