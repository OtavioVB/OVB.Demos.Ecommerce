namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Infrascructure.Data.Repository.Extension;

public interface IExtensionAccountRepository
{
    public Task<bool> VerifyAccountExistsByUsernameOrEmail(string username, string email);
}
