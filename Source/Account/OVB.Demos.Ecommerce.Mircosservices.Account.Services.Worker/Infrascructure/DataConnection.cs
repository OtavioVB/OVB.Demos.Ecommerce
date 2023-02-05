using Npgsql;
using OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker.Infrascructure.Interfaces;

namespace OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker.Infrascructure;

public sealed class DataConnection : IDataConnection<NpgsqlCommand>
{
    private NpgsqlConnection _connection;

    public bool ConnectionHasOpenned = false;

    public DataConnection(NpgsqlConnection connection)
    {
        _connection = connection;
    }

    public Task OpenConnection()
    {
        ConnectionHasOpenned = true;
        return Task.FromResult(_connection.OpenAsync());
    }

    public Task CloseConnection()
    {
        ConnectionHasOpenned = false;
        return Task.FromResult(_connection.CloseAsync());
    }

    public Task<NpgsqlCommand> CreateCommand()
    {
        if (ConnectionHasOpenned == false)
            OpenConnection();

        return Task.FromResult(_connection.CreateCommand());
    }
}
