using FluentValidation.Results;
using OVB.Demos.Ecommerce.Libraries.DesignPatterns.Factory.Interfaces;
using OVB.Demos.Ecommerce.Libraries.Notification;

namespace OVB.Demos.Ecommerce.Libraries.DesignPatterns.Factory;

public class FactoryRangeValidationFailureToRangeNotification : IFactory<List<ValidationFailure>, List<NotificationItem>>
{
    private readonly IFactory<ValidationFailure, NotificationItem> _factory;

    public FactoryRangeValidationFailureToRangeNotification(IFactory<ValidationFailure, NotificationItem> factory)
    {
        _factory = factory;
    }

    public List<NotificationItem> FactoryAdapt(List<ValidationFailure> adaptee)
    {
        var notifications = new List<NotificationItem>();

        foreach (var validation in adaptee)
        {
            notifications.Add(_factory.FactoryAdapt(validation));
        }

        return notifications;
    }
}
