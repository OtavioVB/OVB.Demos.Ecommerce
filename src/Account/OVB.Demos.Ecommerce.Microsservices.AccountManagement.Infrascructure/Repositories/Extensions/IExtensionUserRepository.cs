namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.Repositories.Extensions;

public interface IExtensionUserRepository
{
    public Task<bool> VerifyUserExistsByUsernameOrEmail(string username, string email, CancellationToken cancellationToken);
}
