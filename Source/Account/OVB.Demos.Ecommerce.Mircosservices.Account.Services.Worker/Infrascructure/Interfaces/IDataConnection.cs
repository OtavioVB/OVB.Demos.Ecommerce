using Npgsql;
using System.Data;
using System.Data.Common;

namespace OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker.Infrascructure.Interfaces;

public interface IDataConnection<TTypeCommand>
    where TTypeCommand : IDbCommand
{
    public Task OpenConnection();
    public Task CloseConnection();
    public Task<TTypeCommand> CreateCommand();
}
