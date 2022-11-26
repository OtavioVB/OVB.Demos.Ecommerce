using OVB.Demos.Ecommerce.Microsservices.Account.Domain.ENUMs;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Domain.Entities;

public class AccountStandard : AccountBase
{
    protected AccountStandard(Guid identifier, DateTime registeredOn, Guid registeredByIdentifier, DateTime lastModificationOn, Guid lastModificationByIdentifier, 
        string username, string name, string surname, string password, string email, string cargo, string cpf, TypeAccount typeAccount) 
        : base(identifier, registeredOn, registeredByIdentifier, lastModificationOn, lastModificationByIdentifier, username, name, surname, password, email, cargo, 
            cpf, typeAccount)
    {
    }
}
