using FluentValidation;
using FluentValidation.Results;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.ENUMs;
using OVB.Demos.Ecommerce.Microsservices.Common.Domain;
using OVB.Demos.Ecommerce.Microsservices.Common.Domain.ValueObjects;
using System.Xml.Linq;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Domain.Entities.Base;

public abstract class AccountBase : DomainEntityBase
{
    public Name? Name { get; private set; }
    public Password? Password { get; private set; }
    public DateTime RegisteredOn { get; private set; }
    public TypeAccount TypeAccount { get; init; }

    // Value Objects Validators
    private readonly AbstractValidator<Name> _nameValidator;
    private readonly AbstractValidator<Password> _passwordValidator;

    // Entity Validator
    private readonly AbstractValidator<AccountBase> _accountValidator;

    protected AccountBase(
        TypeAccount typeAccount, 
        AbstractValidator<Name> nameValidator,
        AbstractValidator<AccountBase> accountValidator,
        AbstractValidator<Password> passwordValidator)
    {
        TypeAccount = typeAccount;
        _nameValidator = nameValidator;
        _accountValidator = accountValidator;
        _passwordValidator = passwordValidator;
    }

    protected List<ValidationFailure>? ChangeName(Name name)
    {
        List<ValidationFailure>? validationFailures;
        Name = ChangeValueObject<Name>(name, _nameValidator, out validationFailures);
        return validationFailures;
    }

    protected List<ValidationFailure>? ChangePassword(Password password)
    {
        List<ValidationFailure>? validationFailures;
        Password = ChangeValueObject<Password>(password, _passwordValidator, out validationFailures);
        return validationFailures;
    }

    public (List<ValidationFailure>?, AccountBase?) CreateNewAccount(Name name, Password password)
    {
        var validationFailures = new List<ValidationFailure>();

        var validationNameResult = ChangeName(name);
        if (validationNameResult is not null)
        {
            validationFailures.AddRange(validationNameResult);
        }

        var validationPasswordResult = ChangePassword(password);
        if (validationPasswordResult is not null)
        {
            validationFailures.AddRange(validationPasswordResult);
        }

        if (validationFailures.Any() == false)
        {
            Identifier = Guid.NewGuid();
            RegisteredOn = DateTime.UtcNow;
            return (null, this);
        }
        else
        {
            return (validationFailures, null);
        }
    }

    public bool VerifyEntityIsValid()
    {
        return _accountValidator.Validate(this).IsValid;
    }
}
