using FluentValidation;
using OVB.Demos.Ecommerce.Libraries.Domain.ValueObjects;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.Entities.Base;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.Entities;

public sealed class UserDefault : UserBase
{
    public UserDefault(
        AbstractValidator<Username> usernameValidator, 
        AbstractValidator<Email> emailValidator, 
        AbstractValidator<Password> passwordValidator, 
        AbstractValidator<Name> nameValidator, 
        AbstractValidator<LastName> lastNameValidator) 
        : base(usernameValidator, emailValidator, passwordValidator, nameValidator, lastNameValidator)
    {
    }
}
