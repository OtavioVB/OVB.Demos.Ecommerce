using FluentValidation;
using FluentValidation.Results;
using OVB.Demos.Ecommerce.Libraries.DesignPatterns.Builder;
using OVB.Demos.Ecommerce.Libraries.DesignPatterns.Factory.Interfaces;
using OVB.Demos.Ecommerce.Libraries.Notification;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.Entities;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.Entities.Base;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.ENUMs;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.ValueObjects;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.Builder;

public sealed class AccountBuilder : IBuilder<AccountBase, TypeAccount>
{
    private readonly AbstractValidator<Username> _usernameValidator;
    private readonly AbstractValidator<Password> _passwordValidator;
    private readonly AbstractValidator<Email> _emailValidator;

    private readonly IFactory<List<ValidationFailure>, List<NotificationItem>> _factoryNotifications;

    public AccountBuilder(
        AbstractValidator<Username> usernameValidator, 
        AbstractValidator<Password> passwordValidator,
        AbstractValidator<Email> emailValidator,
        IFactory<List<ValidationFailure>, List<NotificationItem>> factoryNotifications)
    {
        _usernameValidator = usernameValidator;
        _passwordValidator = passwordValidator;
        _emailValidator = emailValidator;
        _factoryNotifications = factoryNotifications;
    }

    public AccountBase BuildEntityByType(TypeAccount type)
    {
        if (TypeAccount.Default == type)
        {
            return new AccountDefault(_usernameValidator, _passwordValidator, _emailValidator, _factoryNotifications);
        }
        else
        {
            throw new Exception("AccountBuilder:CreateAccountByType:=O enumerador identificador do tipo da conta não é válido!");
        }
    }
}
