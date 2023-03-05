using Microsoft.Extensions.DependencyInjection;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Consumer;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Consumer.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Container;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Container.Base;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Container.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Item.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Publisher;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Publisher.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.DependencyInjection;

public static class Injection
{
    public static IServiceCollection AddOvbNotificationConfigurationDependencies(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<INotificationContainer<INotificationItem>, NotificationContainer>();
        serviceCollection.AddScoped<NotificationContainerBase, NotificationContainer>();

        serviceCollection.AddTransient<INotificationPublisher, NotificationPublisher>();
        serviceCollection.AddTransient<INotificationConsumer, NotificationConsumer>();

        return serviceCollection;
    }
}
