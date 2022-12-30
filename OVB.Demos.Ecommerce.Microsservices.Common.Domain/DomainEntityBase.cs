using FluentValidation;
using FluentValidation.Results;

namespace OVB.Demos.Ecommerce.Microsservices.Common.Domain;

public abstract class DomainEntityBase
{
    public Guid Identifier { get; protected set; }

    protected TEntity? ChangeValueObject<TEntity>(TEntity entityValue, AbstractValidator<TEntity> validator, out List<ValidationFailure>? validationFailures)
    {
        var validation = validator.Validate(entityValue);

        if (validation.IsValid == false)
        {
            validationFailures = validation.Errors;
            return default;
        }

        validationFailures = null;
        return entityValue;
    }
}
