using FluentValidation;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.Entities.Base;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.ENUMs;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.ValueObjects;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Domain.Entities;

public sealed class AccountDefault : AccountBase
{
    public AccountDefault(
        AbstractValidator<Name> nameValidator, 
        AbstractValidator<LastName> lastnameValidator, 
        AbstractValidator<Username> usernameValidator, 
        AbstractValidator<Email> emailValidator, 
        AbstractValidator<Password> passwordValidator) 
        : base(nameValidator, lastnameValidator, usernameValidator, emailValidator, passwordValidator, TypeAccount.Default)
    {
    }
}
