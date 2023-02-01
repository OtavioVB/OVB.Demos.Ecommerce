using FluentValidation;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.ENUMs;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.ValueObjects;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Item;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Item.ENUMs;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Notification.Item.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.Domain.Entities;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Domain.Entities.Base;

public abstract class AccountBase : DomainEntityBase
{
    public Name? Name { get; private set; }
    public LastName? LastName { get; private set; }
    public Username? Username { get; private set; }
    public Email? Email { get; private set; }
    public Password? Password { get; private set; }
    public TypeAccount TypeAccount { get; init; }

    private readonly AbstractValidator<Name> _nameValidator;
    private readonly AbstractValidator<LastName> _lastnameValidator;
    private readonly AbstractValidator<Username> _usernameValidator;
    private readonly AbstractValidator<Email> _emailValidator;
    private readonly AbstractValidator<Password> _passwordValidator;

    protected AccountBase(
        AbstractValidator<Name> nameValidator,
        AbstractValidator<LastName> lastnameValidator,
        AbstractValidator<Username> usernameValidator,
        AbstractValidator<Email> emailValidator,
        AbstractValidator<Password> passwordValidator,
        TypeAccount typeAccount)
    {
        _nameValidator = nameValidator;
        _lastnameValidator = lastnameValidator;
        _usernameValidator = usernameValidator;
        _emailValidator = emailValidator;
        _passwordValidator = passwordValidator;
        TypeAccount = typeAccount;
    }

    public virtual (bool HasDone, List<NotificationItem> Notifications) CreateAccount(Guid tenantIdentifier,
        Guid correlationIdentifier, string sourcePlatform, string executionUser, Name name, LastName lastName, Username username, Email email, Password password)
    {
        var hasAnyInvalid = false;
        var notifications = new List<NotificationItem>();

        var nameValidation = _nameValidator.Validate(name);
        if (nameValidation.IsValid == false)
        {
            notifications.AddRange(nameValidation.Errors.Select(p => new NotificationItem(p.ErrorMessage, TypeNotification.Information)));
            hasAnyInvalid = true;
        }

        var lastNameValidation = _lastnameValidator.Validate(lastName);
        if (lastNameValidation.IsValid == false)
        {
            notifications.AddRange(lastNameValidation.Errors.Select(p => new NotificationItem(p.ErrorMessage, TypeNotification.Information)));
            hasAnyInvalid = true;
        }

        var usernameValidation = _usernameValidator.Validate(username);
        if (usernameValidation.IsValid == false)
        {
            notifications.AddRange(usernameValidation.Errors.Select(p => new NotificationItem(p.ErrorMessage, TypeNotification.Information)));
            hasAnyInvalid = true;
        }

        var emailValidation = _emailValidator.Validate(email);
        if (emailValidation.IsValid == false)
        {
            notifications.AddRange(emailValidation.Errors.Select(p => new NotificationItem(p.ErrorMessage, TypeNotification.Information)));
            hasAnyInvalid = true;
        }

        var passwordValidation = _passwordValidator.Validate(password);
        if (passwordValidation.IsValid == false)
        {
            notifications.AddRange(passwordValidation.Errors.Select(p => new NotificationItem(p.ErrorMessage, TypeNotification.Information)));
            hasAnyInvalid = true;
        }

        if (hasAnyInvalid == false)
        {
            ChangeTracingOfEntity(Guid.NewGuid(), tenantIdentifier, correlationIdentifier, sourcePlatform, executionUser);
            ChangeAccountCredentials(name, lastName, username, email, password);
            return (true, notifications);
        }
        else
            return (false, notifications);
    }

    private void ChangeAccountCredentials(Name name, LastName lastName, Username username, Email email, Password password)
    {
        Name = name;
        LastName = lastName;
        Username = username;
        Email = email;
        Password = password;
    }
}
