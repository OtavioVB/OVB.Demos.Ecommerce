using FluentValidation;
using OVB.Demos.Ecommerce.Libraries.Domain.ValueObjects;

namespace OVB.Demos.Ecommerce.Libraries.Domain.Validators;

public sealed class LastNameValidator : AbstractValidator<LastName>
{
    public LastNameValidator()
    {
        RuleFor(p => p.GetValue()).NotEmpty().WithMessage("O sobrenome não pode ser vazio.");
        RuleFor(p => p.GetValue().Length).LessThanOrEqualTo(LastName.MaxLength).WithMessage($"O sobrenome pode conter até {LastName.MaxLength} caracteres.");
        RuleFor(p => p.GetValue().Length).GreaterThanOrEqualTo(LastName.MinLength).WithMessage($"O sobrenome deve conter pelo menos {LastName.MinLength} caracteres.");
    }
}
