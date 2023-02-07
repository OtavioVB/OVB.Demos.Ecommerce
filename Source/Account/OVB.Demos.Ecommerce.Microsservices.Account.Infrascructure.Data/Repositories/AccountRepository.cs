using Microsoft.EntityFrameworkCore;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data.Repositories.Base;
using OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data.Repositories.Extensions;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Management.Interfaces;
using System.Diagnostics;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data.Repositories;

public sealed class AccountRepository : BaseRepository<AccountDataTransfer>, IExtensionAccountRepository
{
    public AccountRepository(DataContext dataContext, ITraceManager traceManager) : base(dataContext, traceManager)
    {
    }

    public async Task<bool> VerifyAccountExistsByUsernameOrEmail(Guid tenantIdentifier, string email, string username)
    {
        return await _traceManager.StartTracing("Repository VerifyAccountExistsByUsernameOrEmail Async", ActivityKind.Internal, async (activity) =>
        {
            return await _dataContext.Accounts.Where(p => (p.TenantIdentifier == tenantIdentifier && p.Email == email) == true 
            || (p.TenantIdentifier == tenantIdentifier && p.Username == username) == true).AnyAsync();
        }, new Dictionary<string, string>());
    }
}
