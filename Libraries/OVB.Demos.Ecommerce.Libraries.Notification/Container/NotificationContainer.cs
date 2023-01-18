using OVB.Demos.Ecommerce.Libraries.Notification.Container.Interfaces;

namespace OVB.Demos.Ecommerce.Libraries.Notification.Container;

public class NotificationContainer : INotificationPublisher, INotificationConsumer
{
    private List<NotificationItem> _notifications;

    public NotificationContainer()
    {
        _notifications = new List<NotificationItem>();
    }

    public void AddNotification(NotificationItem notification)
    {
        _notifications.Add(notification);
    }

    public void AddRangeNotification(List<NotificationItem> notifications)
    {
        _notifications.AddRange(notifications);
    }

    public List<NotificationItem> GetNotifications()
    {
        return _notifications;
    }
}
