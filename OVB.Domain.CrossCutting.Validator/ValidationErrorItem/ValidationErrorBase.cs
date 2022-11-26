namespace OVB.Core.CrossCutting.Validator.Abstractions.ValidationErrorItem;

public class ValidationErrorBase : IValidationErrorItem
{
    public string Message { get; private set; }

    protected ValidationErrorBase(string message)
    {
        Message = message;
    }

    public virtual void ChangeMessage(string message)
    {
        Message = message;
    }
}
