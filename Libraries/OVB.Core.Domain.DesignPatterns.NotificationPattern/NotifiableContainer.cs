using OVB.Core.Domain.DesignPatterns.NotificationPattern.Abstractions.Container;

namespace OVB.Core.Domain.DesignPatterns.NotificationPattern;

public class NotifiableContainer : INotifiableContainer<NotificationItem>
{
    private List<NotificationItem> NotificationsItemAbstractions { get; set; }

    public NotifiableContainer()
    {
        NotificationsItemAbstractions = new List<NotificationItem>();
    }

    public void AddNotification(NotificationItem item)
    {
        NotificationsItemAbstractions.Add(item);
    }

    public void AddNotifications(List<NotificationItem> items)
    {
        NotificationsItemAbstractions.AddRange(items);
    }

    public List<NotificationItem> GetNotificationItems()
    {
        return NotificationsItemAbstractions;
    }
}
