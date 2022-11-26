using OVB.Core.CrossCutting.Validator.Abstractions;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.Common.Models.Properties;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Domain.Validators.Account;

public class AccountValidator : EcommerceOwnValidatorBase<IAccountGettersProperties, ValidationErrorItemStandard>
{
    protected override ValidationErrorItemStandard InvalidNullInput()
    {
        return new ValidationErrorItemStandard("Os dados inseridos são inválidos!");
    }

    public override void ValidationWorkflow(IAccountGettersProperties property)
    {
        base.ValidationWorkflow(property);
    }
}
