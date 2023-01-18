using FluentValidation;
using FluentValidation.Results;
using OVB.Demos.Ecommerce.Libraries.DesignPatterns.Factory.Interfaces;
using OVB.Demos.Ecommerce.Libraries.Notification;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.Entities.Base;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.ENUMs;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.ValueObjects;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.Entities;

public sealed class AccountDefault : AccountBase
{
    public AccountDefault( 
        AbstractValidator<Username> usernameValidator, 
        AbstractValidator<Password> passwordValidator, 
        AbstractValidator<Email> emailValidator, 
        IFactory<List<ValidationFailure>, 
            List<NotificationItem>> factoryNotifications) 
        : base(TypeAccount.Default, usernameValidator, passwordValidator, emailValidator, factoryNotifications)
    {
    }
}
