using FluentValidation;
using OVB.Demos.Ecommerce.Libraries.Domain.ValueObjects;

namespace OVB.Demos.Ecommerce.Libraries.Domain.Validators;

public sealed class NameValidator : AbstractValidator<Name>
{
    public NameValidator()
    {
        RuleFor(p => p.GetValue()).NotEmpty().WithMessage("O nome não pode ser vazio.");
        RuleFor(p => p.GetValue().Length).LessThanOrEqualTo(Name.MaxLength).WithMessage($"O nome pode conter até {Name.MaxLength} caracteres.");
        RuleFor(p => p.GetValue().Length).GreaterThanOrEqualTo(Name.MinLength).WithMessage($"O nome deve conter pelo menos {Name.MinLength} caracteres.");
    }
}
