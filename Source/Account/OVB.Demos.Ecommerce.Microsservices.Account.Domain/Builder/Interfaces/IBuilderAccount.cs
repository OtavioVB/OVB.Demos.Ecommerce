using OVB.Demos.Ecommerce.Microsservices.Account.Domain.Entities.Base;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.ENUMs;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Domain.Builder.Interfaces;

public interface IBuilderAccount
{
    public AccountBase CreateAccountAccordingToYourType(TypeAccount typeAccount);
}
