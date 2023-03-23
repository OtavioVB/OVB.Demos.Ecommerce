namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker.Infrascructure.Repositories.Interfaces;

public interface IUserRepository
{
    public Task CreateTableUserIfThisNotExists();
    public Task AddUserAsync();
}
