using Npgsql;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker.Infrascructure.Connection.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker.Infrascructure.Connection;

public sealed class DataConnection : IDataConnection
{
    private NpgsqlConnection Connection { get; set; }
    private bool IsConnected { get; set; }

    public DataConnection(string connectionString)
    {
        Connection = new NpgsqlConnection(connectionString);
        IsConnected = false;
    }

    public async Task OpenConnectionAsync()
    {
        await Connection.OpenAsync();
        IsConnected = true;
    }

    public async Task CloseConnectionAsync()
    {
        await Connection.CloseAsync();
        IsConnected = false;
    }

    public async Task<NpgsqlConnection> GetNpgsqlConnectionAsync()
    {
        if (IsConnected == false)
            await OpenConnectionAsync();

        return Connection;
    }

}
