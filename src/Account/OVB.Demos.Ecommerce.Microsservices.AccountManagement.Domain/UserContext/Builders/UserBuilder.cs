using FluentValidation;
using OVB.Demos.Ecommerce.Libraries.Domain.ValueObjects;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.Builders.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.Entities;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.Entities.Base;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.ENUMs;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.Builders;

public sealed class UserBuilder : IUserBuilder
{
    private readonly AbstractValidator<Username> _usernameValidator;
    private readonly AbstractValidator<Email> _emailValidator;
    private readonly AbstractValidator<Password> _passwordValidator;
    private readonly AbstractValidator<Name> _nameValidator;
    private readonly AbstractValidator<LastName> _lastNameValidator;

    public UserBuilder(
        AbstractValidator<Username> usernameValidator, 
        AbstractValidator<Email> emailValidator, 
        AbstractValidator<Password> passwordValidator, 
        AbstractValidator<Name> nameValidator, 
        AbstractValidator<LastName> lastNameValidator)
    {
        _usernameValidator = usernameValidator;
        _emailValidator = emailValidator;
        _passwordValidator = passwordValidator;
        _nameValidator = nameValidator;
        _lastNameValidator = lastNameValidator;
    }

    public UserBase CreateUserDomainEntityByHisType(TypeUser typeUser)
    {
        switch (typeUser)
        {
            case TypeUser.Default:
                return new UserDefault(_usernameValidator, _emailValidator, _passwordValidator, _nameValidator, _lastNameValidator);
            default:
                throw new NotImplementedException();
        }
    }
}
