

namespace Todo.Domain.Notifications
{
    public class Notifiable
    {
        private readonly List<Notification> _notifications;

        public Notifiable() => _notifications = [];

        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotification()
        {
            return _notifications.Count > 0;
        }
    }
}
