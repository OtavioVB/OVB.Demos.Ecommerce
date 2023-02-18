using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Container.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Item.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Publisher.Interfaces;

public interface INotificationPublisher
{
    public Task AddNotifications(IEnumerable<INotificationItem> notifications);
    public Task AddNotification(INotificationItem notification);
}
