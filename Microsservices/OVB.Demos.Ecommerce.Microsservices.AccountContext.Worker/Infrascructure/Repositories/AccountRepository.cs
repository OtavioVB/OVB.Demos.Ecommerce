using MySql.Data.MySqlClient;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.Inputs.Protobuf;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Worker.Infrascructure.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Worker.Infrascructure.Repositories.Base;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Worker.Infrascructure.Repositories;

public sealed class AccountRepository : BaseRepository<AccountProtobuf>
{
    public AccountRepository(IBaseDatabaseConnection<MySqlConnection> databaseConnection) 
        : base(databaseConnection)
    {
    }

    public override async Task AddEntityAsync(AccountProtobuf entity)
    {
        using (var command = _databaseConnection.GetConnection().CreateCommand())
        {
            await _databaseConnection.OpenAsync();

            command.CommandText = @$"INSERT INTO Accounts (Identifier, Username, Password, Email, TypeAccount) VALUES 
                    (@{nameof(entity.Identifier)}, @{nameof(entity.Username)}, @{nameof(entity.Password)}, 
                    @{nameof(entity.Email)}, @{nameof(entity.TypeAccount)});";
            command.Parameters.AddWithValue($"@{nameof(entity.Identifier)}", entity.Identifier);
            command.Parameters.AddWithValue($"@{nameof(entity.Username)}", entity.Username);
            command.Parameters.AddWithValue($"@{nameof(entity.Password)}", entity.Password);
            command.Parameters.AddWithValue($"@{nameof(entity.Email)}", entity.Email);
            command.Parameters.AddWithValue($"@{nameof(entity.TypeAccount)}", entity.TypeAccount);
            await command.ExecuteNonQueryAsync();

            await _databaseConnection.CloseAsync();
        }
    }
}
