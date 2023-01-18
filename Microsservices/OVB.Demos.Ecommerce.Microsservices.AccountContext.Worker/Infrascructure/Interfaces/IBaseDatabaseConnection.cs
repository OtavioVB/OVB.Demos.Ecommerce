namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Worker.Infrascructure.Interfaces;

public interface IBaseDatabaseConnection<TSBGDConnection>
    where TSBGDConnection : class
{
    public Task OpenAsync();
    public Task CloseAsync();
    public TSBGDConnection GetConnection();
}
