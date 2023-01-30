using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Item.ENUMs;

namespace OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Item.Interfaces;

public interface INotificationItem
{
    public TypeNotification TypeNotification { get; }
    public string Message { get; }
}
