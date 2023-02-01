using Microsoft.EntityFrameworkCore.Storage;
using OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data;
using OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.UnitOfWork.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.UnitOfWork;

public sealed class DefaultUnitOfWork : IUnitOfWork
{
    private readonly DataContext _dataContext;

    public DefaultUnitOfWork(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<bool> ExecuteUnitOfWorkAsync(Func<IDbContextTransaction, CancellationToken, Task<bool>> handler, IDbContextTransaction transaction, CancellationToken cancellationToken)
    {
        var handlerResponse = await handler(transaction, cancellationToken);

        if (handlerResponse == true)
        {
            await _dataContext.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            await transaction.DisposeAsync();
            return true;
        }
        else
        {
            await transaction.RollbackAsync(cancellationToken);
            await transaction.DisposeAsync();
            return false;
        }
    }
}
