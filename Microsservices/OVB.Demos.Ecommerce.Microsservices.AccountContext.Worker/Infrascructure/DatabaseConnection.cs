using MySql.Data.MySqlClient;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Worker.Infrascructure.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Worker.Infrascructure;

public class DatabaseConnection : IBaseDatabaseConnection<MySqlConnection>
{
    private readonly MySqlConnection _mysqlConnnection;

    public DatabaseConnection(IConfiguration configuration)
    {
        _mysqlConnnection = new MySqlConnection(configuration["Databases:MySQL"]);
    }

    public async Task OpenAsync()
    {
        await _mysqlConnnection.OpenAsync();
    }

    public async Task CloseAsync()
    {
        await _mysqlConnnection.CloseAsync();
    }

    public MySqlConnection GetConnection()
    {
        return _mysqlConnnection;
    }
}
