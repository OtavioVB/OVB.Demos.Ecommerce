using Npgsql;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker.Infrascructure.Connection.Interfaces;

public interface IDataConnection
{
    public Task OpenConnectionAsync();
    public Task CloseConnectionAsync();
    public Task<NpgsqlConnection> GetNpgsqlConnectionAsync();
}
