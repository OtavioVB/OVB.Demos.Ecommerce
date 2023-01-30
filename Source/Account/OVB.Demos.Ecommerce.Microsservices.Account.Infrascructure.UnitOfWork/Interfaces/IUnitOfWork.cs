namespace OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.UnitOfWork.Interfaces;

public interface IUnitOfWork
{
    public Task<bool> ExecuteUnitOfWorkAsync(Func<bool> handler);
}
