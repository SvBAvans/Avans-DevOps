namespace Avans_DevOps.domain.Notifications
{
    public class SmsNotificationStrategy : INotificationStrategy
    {
        public void Notify(User user, string message)
        {
            Console.WriteLine("[SMS-NOTIFIER] - " + message);
        }
    }
}
