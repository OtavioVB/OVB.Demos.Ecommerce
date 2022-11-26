namespace OVB.Core.CrossCutting.Validator.Abstractions.ValidationErrorItem;

internal interface IValidationErrorItem
{
    public string Message { get; }

    public void ChangeMessage(string message);
}
