using OVB.Demos.Ecommerce.Microsservices.Account.Domain.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data.Repositories.Base;
using OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data.Repositories.Extensions;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data.Repositories;

public sealed class AccountRepository : BaseRepository<AccountDataTransfer>, IExtensionAccountRepository
{
    public AccountRepository(DataContext dataContext) : base(dataContext)
    {
    }

    public Task<bool> VerifyAccountExistsByUsernameOrEmail(Guid tenantIdentifier, string email, string username)
    {
        return Task.FromResult(_dataContext.Accounts
            .Where(p => (p.TenantIdentifier == tenantIdentifier && p.Email == email) == true 
            || (p.TenantIdentifier == tenantIdentifier && p.Username == username) == true).Any());
    }
}
