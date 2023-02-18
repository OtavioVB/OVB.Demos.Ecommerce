using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Item.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Container.Interfaces;

public interface INotificationContainer<TNotification>
    where TNotification : INotificationItem
{
    public Task AddNotification(TNotification notification);
    public Task AddNotifications(IEnumerable<TNotification> notifications);
    public Task<IList<TNotification>> GetNotifications();
}
