namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker.Infrascructure.Repositories.Interfaces;

public interface IAccountRepository
{
    public Task CreateTableAccountIfThisNotExists();
    public Task AddAccountAsync();
}
