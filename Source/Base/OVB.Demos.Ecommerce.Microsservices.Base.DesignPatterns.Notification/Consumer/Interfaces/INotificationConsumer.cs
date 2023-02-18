using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Item.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Consumer.Interfaces;

public interface INotificationConsumer
{
    public Task<IList<INotificationItem>> GetNotifications();
}
