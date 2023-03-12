using FluentValidation;
using OVB.Demos.Ecommerce.Libraries.Domain.ValueObjects;

namespace OVB.Demos.Ecommerce.Libraries.Domain.Validators;

public sealed class EmailValidator : AbstractValidator<Email>
{
    public EmailValidator()
    {
        RuleFor(p => p.GetValue()).NotEmpty().WithMessage("O email não pode ser vazio.");
        RuleFor(p => p.GetValue().Length).LessThanOrEqualTo(Email.MaxLength).WithMessage($"O email pode conter até {Email.MaxLength} caracteres.");
        RuleFor(p => p.GetValue().Length).GreaterThanOrEqualTo(Email.MinLength).WithMessage($"O email precisa conter pelo menos {Email.MinLength} caracteres");
    }
}
