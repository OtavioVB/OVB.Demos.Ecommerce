using Microsoft.EntityFrameworkCore.Storage;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Infrascructure.UnitOfWork.Interfaces;

public interface IUnitOfWork
{
    public Task<bool> ExecuteAsync(Func<IDbContextTransaction, Task<bool>> handler, IDbContextTransaction Transaction, CancellationToken cancellationToken);
}
