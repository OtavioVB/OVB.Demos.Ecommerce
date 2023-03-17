namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.UnitOfWork.Interfaces;

public interface IUnitOfWork
{
    public Task<TOutput> ExecuteUnitOfWorkAsync<TOutput>(Func<CancellationToken, Task<(bool HasDone, TOutput Output)>> handler, CancellationToken cancellationToken);
    public Task AddChangesToTransaction();
}
