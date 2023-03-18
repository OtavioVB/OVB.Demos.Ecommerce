using FluentValidation;
using OVB.Demos.Ecommerce.Libraries.Domain;
using OVB.Demos.Ecommerce.Libraries.Domain.ENUMs;
using OVB.Demos.Ecommerce.Libraries.Domain.ValueObjects;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.ENUMs;
using System.Data.Common;
using System.Diagnostics;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.Entities.Base;

public abstract class UserBase : DomainEntityBase
{
    public Username Username { get; private set; }
    public Email Email { get; private set; }
    public Name Name { get; private set; }
    public LastName LastName { get; private set; }
    public Password Password { get; private set; }
    public bool IsEmailConfirmed { get; private set; }
    public User? User { get; private set; }
    public DomainState State { get; private set; }

    private readonly AbstractValidator<Username> _usernameValidator;
    private readonly AbstractValidator<Email> _emailValidator;
    private readonly AbstractValidator<Password> _passwordValidator;
    private readonly AbstractValidator<Name> _nameValidator;
    private readonly AbstractValidator<LastName> _lastNameValidator;

    protected UserBase(
        AbstractValidator<Username> usernameValidator, 
        AbstractValidator<Email> emailValidator, 
        AbstractValidator<Password> passwordValidator, 
        AbstractValidator<Name> nameValidator, 
        AbstractValidator<LastName> lastNameValidator)
    {
        State = DomainState.IsNotAvailable;
        _usernameValidator = usernameValidator;
        _emailValidator = emailValidator;
        _passwordValidator = passwordValidator;
        _nameValidator = nameValidator;
        _lastNameValidator = lastNameValidator;
    }

    public virtual (bool HasDone, List<string> Notifications) CreateBasicCredentials(string username, string email, string lastName, 
        string name, string password, Guid tenantIdentifier, Guid correlationIdentifier, string sourcePlatform)
    {
        if (DomainState.IsNotAvailable != State)
            throw new Exception("Is not possible to create basic credentials for user with a available state.");

        var notifications = new List<string>();
        var hasAnyInvalid = false;

        var usernameValueObject = new Username(username);
        var emailValueObject = new Email(email);    
        var passwordValueObject = new Password(password);
        var nameValueObject = new Name(name);   
        var lastNameValueObject = new LastName(lastName);

        var usernameValidator = _usernameValidator.Validate(usernameValueObject);
        if (usernameValidator.IsValid == false)
        {
            hasAnyInvalid = true;
            notifications.AddRange(usernameValidator.Errors.Select(p => p.ErrorMessage));
        }

        var emailValidator = _emailValidator.Validate(emailValueObject);
        if (emailValidator.IsValid == false)
        {
            hasAnyInvalid = true;
            notifications.AddRange(emailValidator.Errors.Select(p => p.ErrorMessage));
        }

        var passwordValidator = _passwordValidator.Validate(passwordValueObject);
        if (passwordValidator.IsValid == false)
        {
            hasAnyInvalid = true;
            notifications.AddRange(passwordValidator.Errors.Select(p => p.ErrorMessage));
        }

        var nameValidator = _nameValidator.Validate(nameValueObject);
        if (nameValidator.IsValid == false)
        {
            hasAnyInvalid = true;
            notifications.AddRange(nameValidator.Errors.Select(p => p.ErrorMessage));
        }

        var lastNameValidator = _lastNameValidator.Validate(lastNameValueObject);
        if (lastNameValidator.IsValid == false)
        {
            hasAnyInvalid = true;
            notifications.AddRange(lastNameValidator.Errors.Select(p => p.ErrorMessage));
        }

        if (hasAnyInvalid == false)
        {
            SetBasicCredentials(usernameValueObject, passwordValueObject, emailValueObject, nameValueObject, lastNameValueObject,
                new SourcePlatform(sourcePlatform), correlationIdentifier, tenantIdentifier);
            return (true, notifications);
        }
        else
            return (false, notifications);
    }

    protected void SetBasicCredentialsByDataTransferObject(User user)
    {
        Identifier = user.Identifier;
        SourcePlatform = new SourcePlatform(user.SourcePlatform);
        TenantIdentifier = user.TenantIdentifier;
        CorrelationIdentifier = user.CorrelationIdentifier;
        CreatedOn = user.CreatedOn;
        Username = new Username(user.Username);
        Password = new Password(user.Password);
        Email = new Email(user.Email);
        Name = new Name(user.Name);
        LastName = new LastName(user.LastName);
        User = user;
        State = DomainState.Available;
    }

    protected void SetBasicCredentials(Username username, Password password, Email email, Name name, LastName lastName, 
        SourcePlatform sourcePlatform, Guid correlationIdentifier, Guid tenantIdentifier)
    {
        Identifier = Guid.NewGuid();
        SourcePlatform = sourcePlatform;
        TenantIdentifier = tenantIdentifier;
        CorrelationIdentifier = correlationIdentifier;
        CreatedOn = DateTime.UtcNow;
        Username = username;
        Password = password;
        Email = email;
        Name = name;
        LastName = lastName;
        User = new User(username.ToString(), name.ToString(), lastName.ToString(), email.ToString(), password.ToString(),
            false, (int)TypeUser.Default,Identifier, TenantIdentifier, CorrelationIdentifier, SourcePlatform.ToString(), CreatedOn);
        State = DomainState.Available;
    }
}