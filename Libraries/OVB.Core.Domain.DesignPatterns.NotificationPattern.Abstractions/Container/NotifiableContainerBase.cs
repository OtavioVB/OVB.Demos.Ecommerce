using OVB.Core.Domain.DesignPatterns.NotificationPattern.Abstractions.Item;

namespace OVB.Core.Domain.DesignPatterns.NotificationPattern.Abstractions.Container;

public abstract class NotifiableContainerBase<T> : INotifiableContainer<T>
    where T : INotificationItem
{
    protected List<T> NotificationsItems;

    protected NotifiableContainerBase()
    {
        NotificationsItems = new List<T>();
    }

    public virtual void AddNotification(T item)
    {
        NotificationsItems.Add(item);
    }

    public virtual void AddNotifications(List<T> items)
    {
        NotificationsItems.AddRange(items);
    }

    public virtual List<T> GetNotificationItems()
    {
        return NotificationsItems;
    }
}
