using OVB.Core.CrossCutting.Validator.Abstractions.ValidationErrorItem;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Domain.Validators;

public class ValidationErrorItemStandard : ValidationErrorBase
{
    public ValidationErrorItemStandard(string message) : base(message)
    {
    }
}
