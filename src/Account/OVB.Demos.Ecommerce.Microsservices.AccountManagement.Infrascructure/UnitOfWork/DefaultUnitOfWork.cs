using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.UnitOfWork.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.UnitOfWork;

public sealed class DefaultUnitOfWork : IUnitOfWork
{
    private readonly DataContext _dataContext;

    public DefaultUnitOfWork(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public Task AddChangesToTransaction()
    {
        return _dataContext.SaveChangesAsync();
    }

    public async Task<TOutput> ExecuteUnitOfWorkAsync<TOutput>(
        Func<CancellationToken, Task<(bool HasDone, TOutput Output)>> handler, CancellationToken cancellationToken)
    {
        var transaction = await _dataContext.Database.BeginTransactionAsync();

        var handlerResponse = await handler(cancellationToken);

        if (handlerResponse.HasDone == false)
        {
            await transaction.RollbackAsync(cancellationToken);
            await transaction.DisposeAsync();
            return handlerResponse.Output;
        }
        else
        {
            await transaction.CommitAsync(cancellationToken);
            await transaction.DisposeAsync();
            return handlerResponse.Output;
        }
    }
}