using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Container.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Item.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Publisher.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Publisher;

public sealed class NotificationPublisher : INotificationPublisher
{
    private INotificationContainer<INotificationItem> _notificationContainer;

    public NotificationPublisher(INotificationContainer<INotificationItem> notificationContainer)
    {
        _notificationContainer = notificationContainer;
    }

    public Task AddNotification(INotificationItem notification)
    {
        return _notificationContainer.AddNotification(notification);
    }

    public Task AddNotifications(IEnumerable<INotificationItem> notifications)
    {
        return _notificationContainer.AddNotifications(notifications);
    }
}
