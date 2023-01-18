namespace OVB.Demos.Ecommerce.Libraries.Notification;

public sealed class NotificationItem
{
    public NotificationItem(string message, TypeNotification typeNotification)
    {
        Message = message;
        TypeNotification = typeNotification;
    }

    public string Message { get; set; }
    public TypeNotification TypeNotification { get; set; }
}
