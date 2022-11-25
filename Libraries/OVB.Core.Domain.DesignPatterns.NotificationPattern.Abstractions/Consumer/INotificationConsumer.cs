using OVB.Core.Domain.DesignPatterns.NotificationPattern.Abstractions.Item;

namespace OVB.Core.Domain.DesignPatterns.NotificationPattern.Abstractions.Consumer;

public interface INotificationConsumer<NotificationItemAbstraction>
    where NotificationItemAbstraction : INotificationItem
{
    public List<NotificationItemAbstraction> GetNotificationItems();
}
