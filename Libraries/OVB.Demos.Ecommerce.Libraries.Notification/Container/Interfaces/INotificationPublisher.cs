namespace OVB.Demos.Ecommerce.Libraries.Notification.Container.Interfaces;

public interface INotificationPublisher
{
    public void AddNotification(NotificationItem notification);
    public void AddRangeNotification(List<NotificationItem> notifications);
}
