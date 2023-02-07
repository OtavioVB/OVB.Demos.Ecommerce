using Microsoft.EntityFrameworkCore.Storage;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.UnitOfWork.Interfaces;

public interface IUnitOfWork
{
    public Task<bool> ExecuteUnitOfWorkAsync(Func<IDbContextTransaction, CancellationToken, Task<bool>> handler, IDbContextTransaction transaction, CancellationToken cancellationToken);
}
