using FluentValidation;
using FluentValidation.Results;
using OVB.Demos.Ecommerce.Libraries.DesignPatterns.Factory.Interfaces;
using OVB.Demos.Ecommerce.Libraries.Notification;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.ENUMs;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.ValueObjects;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.Entities.Base;

public abstract class AccountBase
{
    // Properties
    public Guid Identifier { get; private set; }
    public Username Username { get; private set; }
    public Password Password { get; private set; }
    public Email Email { get; private set; }
    public TypeAccount TypeAccount { get; init; }

    // Validators
    private readonly AbstractValidator<Username> _usernameValidator;
    private readonly AbstractValidator<Password> _passwordValidator;
    private readonly AbstractValidator<Email> _emailValidator;

    // Factories
    private readonly IFactory<List<ValidationFailure>, List<NotificationItem>> _factoryNotifications;

    // Messages
    public static class Messages
    {
        public static string PasswordConfirmIsNotValidMessage = "A confirmação de senha não corresponde com o esperado.";
        public static string AccountExistsInDatabaseMessage = "A conta já possui um cadastro no banco de dados com mesmas credenciais.";
    }

    protected AccountBase(TypeAccount typeAccount, 
        AbstractValidator<Username> usernameValidator, 
        AbstractValidator<Password> passwordValidator, 
        AbstractValidator<Email> emailValidator,
        IFactory<List<ValidationFailure>, List<NotificationItem>> factoryNotifications)
    {
        TypeAccount = typeAccount;
        _usernameValidator = usernameValidator;
        _passwordValidator = passwordValidator;
        _emailValidator = emailValidator;
        _factoryNotifications = factoryNotifications;
    }

    public virtual (bool HasDone, List<NotificationItem> Notifications) CreateAccount(Username username, Password password, Email email)
    {
        bool hasAnyPropertyInvalid = false;
        var notifications = new List<NotificationItem>();

        var usernameValidation = _usernameValidator.Validate(username);
        if (usernameValidation.IsValid == false)
        {
            notifications.AddRange(_factoryNotifications.FactoryAdapt(usernameValidation.Errors));
            hasAnyPropertyInvalid = true;
        }

        var passwordValidation = _passwordValidator.Validate(password);
        if (passwordValidation.IsValid == false)
        {
            notifications.AddRange(_factoryNotifications.FactoryAdapt(passwordValidation.Errors));
            hasAnyPropertyInvalid = true;
        }

        var emailValidation = _emailValidator.Validate(email);
        if (emailValidation.IsValid == false)
        {
            notifications.AddRange(_factoryNotifications.FactoryAdapt(emailValidation.Errors));
            hasAnyPropertyInvalid = true;
        }

        if (hasAnyPropertyInvalid == false)
        {
            SetAccountCredentials(username, password, email);
            return (true, notifications);
        }
        else
        {
            return (false, notifications);
        }
    }

    private void SetAccountCredentials(Username username, Password password, Email email)
    {
        Identifier = Guid.NewGuid();
        Username = username;
        Password = password;
        Email = email;
    }
}
