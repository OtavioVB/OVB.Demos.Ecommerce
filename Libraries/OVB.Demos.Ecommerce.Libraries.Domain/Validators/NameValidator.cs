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
        RuleFor(p => p.GetValue()).Custom((information, context) =>
        {
            bool hasAnyInvalid = false;

            if (information.Contains("  ") == true)
            {
                context.AddFailure("O nome não pode conter espaços em branco inválidos.");
            }

            foreach (var character in information.ToArray())
            {
                if (char.IsLetter(character) == false && char.IsWhiteSpace(character) == false)
                {
                    hasAnyInvalid = true;
                    break;
                }
            }

            if (hasAnyInvalid == true)
            {
                context.AddFailure("O nome deve conter apenas letras e espaços em branco.");
            }
        });
    }
}
