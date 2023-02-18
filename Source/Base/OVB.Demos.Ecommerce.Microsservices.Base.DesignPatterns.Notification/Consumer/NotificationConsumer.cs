using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Consumer.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Container.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Item.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Consumer;

public sealed class NotificationConsumer : INotificationConsumer
{
    private INotificationContainer<INotificationItem> _notificationContainer;

    public NotificationConsumer(INotificationContainer<INotificationItem> notificationContainer)
    {
        _notificationContainer = notificationContainer;
    }
    
    public Task<IList<INotificationItem>> GetNotifications()
    {
        return _notificationContainer.GetNotifications();
    }
}
