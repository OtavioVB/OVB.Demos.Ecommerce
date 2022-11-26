using OVB.Core.CrossCutting.Validator.Abstractions.ValidationErrorItem;

namespace OVB.Core.CrossCutting.Validator.Abstractions;

public abstract class EcommerceOwnValidatorBase<Property, ValidationError>
    where Property : class
    where ValidationError : ValidationErrorBase
{
    private List<ValidationError> ValidationErrorItems;

    protected EcommerceOwnValidatorBase()
    {
        ValidationErrorItems = new List<ValidationError>();
    }

    public virtual void ValidationWorkflow(Property property)
    {
        if (property is null)
        {
            AddValidationErrorItemMessage(InvalidNullInput());
        }
    }

    protected abstract ValidationError InvalidNullInput();

    protected virtual void AddValidationErrorItemMessage(ValidationError validationError)
    {
        ValidationErrorItems.Add(validationError);
    }

    protected virtual void AddRangeValidationErrorItemMessage(IReadOnlyCollection<ValidationError> validationErrors)
    {
        ValidationErrorItems.AddRange(validationErrors);
    }
}