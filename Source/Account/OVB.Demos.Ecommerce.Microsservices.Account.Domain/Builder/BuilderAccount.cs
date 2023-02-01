using FluentValidation;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.Builder.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.Entities;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.Entities.Base;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.ENUMs;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.ValueObjects;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Domain.Builder;

public sealed class BuilderAccount : IBuilderAccount
{
    private readonly AbstractValidator<Name> _nameValidator;
    private readonly AbstractValidator<LastName> _lastnameValidator;
    private readonly AbstractValidator<Username> _usernameValidator;
    private readonly AbstractValidator<Email> _emailValidator;
    private readonly AbstractValidator<Password> _passwordValidator;

    public BuilderAccount(
        AbstractValidator<Name> nameValidator, 
        AbstractValidator<LastName> lastnameValidator, 
        AbstractValidator<Username> usernameValidator, 
        AbstractValidator<Email> emailValidator,
        AbstractValidator<Password> passwordValidator)
    {
        _nameValidator = nameValidator;
        _lastnameValidator = lastnameValidator;
        _usernameValidator = usernameValidator;
        _emailValidator = emailValidator;
        _passwordValidator = passwordValidator;
    }

    public AccountBase CreateAccountAccordingToYourType(TypeAccount typeAccount)
    {
        return typeAccount switch
        {
            TypeAccount.Default => new AccountDefault(_nameValidator, _lastnameValidator, _usernameValidator, _emailValidator, _passwordValidator),
            _ => throw new Exception("Is not possible to create this account."),
        };
    }
}
