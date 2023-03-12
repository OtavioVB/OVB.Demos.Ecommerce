using FluentValidation;
using OVB.Demos.Ecommerce.Libraries.Domain.ValueObjects;

namespace OVB.Demos.Ecommerce.Libraries.Domain.Validators;

public sealed class PasswordValidator : AbstractValidator<Password>
{
    public PasswordValidator()
    {
        RuleFor(p => p.GetValue()).NotEmpty().WithMessage("A senha não pode ser vazia.");
        RuleFor(p => p.GetValue().Length).LessThanOrEqualTo(Password.MaxLength).WithMessage($"A senha pode conter até {Password.MaxLength} caracteres.");
        RuleFor(p => p.GetValue().Length).GreaterThanOrEqualTo(Password.MinLength).WithMessage($"A senha deve conter pelo menos {Password.MinLength} caracteres.");
        RuleFor(p => p.ToString()).Custom((information, context) =>
        {
            var hasNumber = false;
            var hasUppercase = false;
            var hasLowercase = false;
            var hasSymbol = false;

            var informationCharacters = information.ToArray();

            foreach (var character in informationCharacters)
            {
                if (char.IsNumber(character) == true)
                    hasNumber = true;

                if (char.IsUpper(character) == true)
                    hasUppercase = true;

                if (char.IsLower(character) == true)
                    hasLowercase = true;
            }

            if (information.Contains("*") || information.Contains("%") || information.Contains("$") || information.Contains("#") ||
                information.Contains("@") || information.Contains("(") || information.Contains(")"))
                hasSymbol = true;

            if (hasNumber is false || hasLowercase == false || hasUppercase == false || hasSymbol == false)
                context.AddFailure("É necessário que a senha contenha pelo menos um número, uma letra maiúscula, uma letra minúscula e um símbolo (*, $, %, #, @).");
        });
    }
}
