using FluentValidation;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.ValueObjects;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.Validators.ValueObjects;

public sealed class UsernameValidator : AbstractValidator<Username>
{
    public UsernameValidator()
    {
    }
}
