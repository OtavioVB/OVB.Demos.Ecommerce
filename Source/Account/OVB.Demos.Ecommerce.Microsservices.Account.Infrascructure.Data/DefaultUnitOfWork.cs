using Microsoft.EntityFrameworkCore.Storage;
using OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data;
using OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.UnitOfWork.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Management.Interfaces;
using System.Diagnostics;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.UnitOfWork;

public sealed class DefaultUnitOfWork : IUnitOfWork
{
    private readonly ITraceManager _traceManager;
    private readonly DataContext _dataContext;

    public DefaultUnitOfWork(DataContext dataContext, ITraceManager traceManager)
    {
        _traceManager = traceManager;
        _dataContext = dataContext;
    }

    public async Task<bool> ExecuteUnitOfWorkAsync(Func<IDbContextTransaction, CancellationToken, Task<bool>> handler, IDbContextTransaction transactionOne, CancellationToken cancellationToken)
    {
        return await _traceManager.StartTracing("Execute Unit Of Work Transaction", ActivityKind.Internal, async (activity) =>
        {
            var handlerResponse = await handler(transactionOne, cancellationToken);

            if (handlerResponse == true)
            {
                await _dataContext.SaveChangesAsync(cancellationToken);
                await transactionOne.CommitAsync(cancellationToken);
                await transactionOne.DisposeAsync();
                return true;
            }
            else
            {
                await transactionOne.RollbackAsync(cancellationToken);
                await transactionOne.DisposeAsync();
                return false;
            }
        }, new Dictionary<string, string>());
    }
}
