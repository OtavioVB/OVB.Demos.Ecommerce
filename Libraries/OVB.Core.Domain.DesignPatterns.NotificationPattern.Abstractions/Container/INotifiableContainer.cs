using OVB.Core.Domain.DesignPatterns.NotificationPattern.Abstractions.Consumer;
using OVB.Core.Domain.DesignPatterns.NotificationPattern.Abstractions.Item;
using OVB.Core.Domain.DesignPatterns.NotificationPattern.Abstractions.Publisher;

namespace OVB.Core.Domain.DesignPatterns.NotificationPattern.Abstractions.Container;

public interface INotifiableContainer<NotificationItemAbstraction> : INotificationConsumer<NotificationItemAbstraction>, INotificationPublisher<NotificationItemAbstraction>
    where NotificationItemAbstraction : INotificationItem
{

}
