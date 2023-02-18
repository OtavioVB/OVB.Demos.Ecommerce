using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Container.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Item.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Container.Base;

public abstract class NotificationContainerBase : INotificationContainerBase<INotificationItem>
{
    private List<INotificationItem> _notifications;

    protected NotificationContainerBase()
    {
        _notifications = new List<INotificationItem>();
    }

    public Task AddNotification(INotificationItem notification)
    {
        return Task.Run(() =>
        {
            _notifications.Add(notification);
        });
    }

    public Task AddNotifications(IEnumerable<INotificationItem> notifications)
    {
        return Task.Run(() =>
        {
            _notifications.AddRange(notifications);
        });
    }

    public async Task<IList<INotificationItem>> GetNotifications()
    {
        return await Task.FromResult(_notifications);
    }
}
