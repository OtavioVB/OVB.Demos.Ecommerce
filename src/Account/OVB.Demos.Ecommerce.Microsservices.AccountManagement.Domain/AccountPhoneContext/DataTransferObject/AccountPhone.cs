using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.AccountContext.DataTransferObject;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.AccountPhoneContext.DataTransferObject;

public sealed class AccountPhone
{
    public AccountPhone(Guid identifier, string phone)
    {
        Identifier = identifier;
        Phone = phone;
    }

    public Guid Identifier { get; set; }
    public string Phone { get; set; }
    public Account? Account { get; set; }
}
