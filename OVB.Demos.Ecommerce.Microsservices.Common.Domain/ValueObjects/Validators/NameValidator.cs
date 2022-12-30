using FluentValidation;

namespace OVB.Demos.Ecommerce.Microsservices.Common.Domain.ValueObjects.Validators;

public class NameValidator : AbstractValidator<Name>
{
    public NameValidator()
    {
        RuleFor(p => p.ToString()).NotEmpty().WithMessage("O nome não pode ser vazio.");

        // Adicione mensagens
    }
}
