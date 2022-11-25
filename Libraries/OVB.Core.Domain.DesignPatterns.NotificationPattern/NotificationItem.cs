using OVB.Core.Domain.DesignPatterns.NotificationPattern.Abstractions.Item;

namespace OVB.Core.Domain.DesignPatterns.NotificationPattern;

public class NotificationItem : INotificationItem
{
    public string Message { get; }

    public NotificationItem(string message)
    {
        Message = message;
    }
}
