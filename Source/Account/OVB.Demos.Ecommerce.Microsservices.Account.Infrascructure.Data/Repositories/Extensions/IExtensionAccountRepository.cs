namespace OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data.Repositories.Extensions;

public interface IExtensionAccountRepository
{
    public Task<bool> VerifyAccountExistsByUsernameOrEmail(Guid tenantIdentifier, string email, string username);
}
