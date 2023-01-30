using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Item.ENUMs;

namespace OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Item;

public class NotificationItem
{
    public NotificationItem(string message, TypeNotification typeNotification)
    {
        Message = message;
        TypeNotification = typeNotification;
    }

    public string Message { get; set; }
    public TypeNotification TypeNotification { get; set; }
}
