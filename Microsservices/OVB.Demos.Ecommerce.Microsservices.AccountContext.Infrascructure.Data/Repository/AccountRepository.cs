using Microsoft.EntityFrameworkCore;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Infrascructure.Data.Repository.Base;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Infrascructure.Data.Repository.Extension;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Infrascructure.Data.Repository;

public class AccountRepository : BaseRepository<Account>, IExtensionAccountRepository
{
    public AccountRepository(DataContext dataContext) : base(dataContext)
    {
    }

    public async Task<bool> VerifyAccountExistsByUsernameOrEmail(string username, string email)
    {
        return await _dataContext.Set<Account>().Where(p => p.Username == username || p.Email == email).AnyAsync();
    }
}
