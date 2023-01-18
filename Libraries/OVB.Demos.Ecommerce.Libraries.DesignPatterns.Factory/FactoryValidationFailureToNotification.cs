using FluentValidation.Results;
using OVB.Demos.Ecommerce.Libraries.DesignPatterns.Factory.Interfaces;
using OVB.Demos.Ecommerce.Libraries.Notification;

namespace OVB.Demos.Ecommerce.Libraries.DesignPatterns.Factory;

public class FactoryValidationFailureToNotification : IFactory<ValidationFailure, NotificationItem>
{
    public NotificationItem FactoryAdapt(ValidationFailure adaptee)
    {
        return new NotificationItem(adaptee.ErrorMessage, TypeNotification.Warning);
    }
}
