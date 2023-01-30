using OVB.Demos.Ecommerce.Microsservices.Account.Domain.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data.Repositories.Base;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data.Repositories;

public sealed class AccountRepository : BaseRepository<AccountDataTransfer>
{
    public AccountRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
