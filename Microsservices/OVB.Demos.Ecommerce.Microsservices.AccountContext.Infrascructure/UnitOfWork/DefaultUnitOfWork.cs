using Microsoft.EntityFrameworkCore.Storage;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Infrascructure.UnitOfWork.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Infrascructure.UnitOfWork;

public sealed class DefaultUnitOfWork : IUnitOfWork
{
    public async Task<bool> ExecuteAsync(Func<IDbContextTransaction, Task<bool>> handler, IDbContextTransaction Transaction)
    {
        if (await handler(Transaction) == false)
        {
            await Transaction.RollbackAsync();
            await Transaction.DisposeAsync();
            return false;
        }
        else
        {
            await Transaction.CommitAsync();
            await Transaction.DisposeAsync();
            return true;
        }
    }
}
