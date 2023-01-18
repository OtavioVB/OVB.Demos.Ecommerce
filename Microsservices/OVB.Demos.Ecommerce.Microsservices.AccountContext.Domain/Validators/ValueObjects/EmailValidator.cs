using FluentValidation;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.ValueObjects;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.Validators.ValueObjects;

public class EmailValidator : AbstractValidator<Email>
{
    public EmailValidator()
    {
        RuleFor(p => p.ToString()).NotEmpty().WithMessage("O email não pode ser vazio.");
        RuleFor(p => p.ToString().Length).LessThanOrEqualTo(256).WithMessage("O email precisa conter até 256 caracteres.");
    }
}
