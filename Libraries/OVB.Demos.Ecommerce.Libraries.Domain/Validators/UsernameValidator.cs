using FluentValidation;
using OVB.Demos.Ecommerce.Libraries.Domain.ValueObjects;

namespace OVB.Demos.Ecommerce.Libraries.Domain.Validators;

public sealed class UsernameValidator : AbstractValidator<Username>
{
    public UsernameValidator()
    {
        RuleFor(p => p.GetValue()).NotEmpty().WithMessage("O nome de usuário não pode ser vazio.");
        RuleFor(p => p.GetValue().Length).LessThanOrEqualTo(Username.MaxLength).WithMessage($"O nome de usuário pode conter até {Username.MaxLength} caracteres.");
        RuleFor(p => p.GetValue().Length).GreaterThanOrEqualTo(Username.MinLength).WithMessage($"O nome de usuário deve conter pelo menos {Username.MinLength} caracteres.");
    }
}
