using MySql.Data.MySqlClient;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Worker.Infrascructure.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Worker.Infrascructure.Repositories.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Worker.Infrascructure.Repositories.Base;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : class
{
    protected readonly IBaseDatabaseConnection<MySqlConnection> _databaseConnection;

    protected BaseRepository(IBaseDatabaseConnection<MySqlConnection> databaseConnection)
    {
        _databaseConnection = databaseConnection;
    }

    public abstract Task AddEntityAsync(TEntity entity);
}
