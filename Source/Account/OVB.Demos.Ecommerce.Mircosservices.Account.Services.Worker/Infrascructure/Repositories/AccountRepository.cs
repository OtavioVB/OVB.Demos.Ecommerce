using Npgsql;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.DataTransferObject;
using OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker.Infrascructure.Repositories.Interfaces;

namespace OVB.Demos.Ecommerce.Mircosservices.Account.Services.Worker.Infrascructure.Repositories;

public sealed class AccountRepository : IBaseRepository<AccountDataTransfer>
{
    private readonly NpgsqlConnection _dataConnection;

    public AccountRepository(NpgsqlConnection dataConnection)
    {
        _dataConnection = dataConnection;
    }

    public async Task AddEntityAsync(AccountDataTransfer entity)
    {
        await _dataConnection.OpenAsync();
        using (var command = _dataConnection.CreateCommand())
        {
            command.CommandText = "INSERT INTO \"accounts\" (Identifier, TenantIdentifier, CorrelationIdentifier, SourcePlatform, ExecutionUser, " +
                "Name, Username, LastName, Email, Password, TypeAccount) VALUES (@Identifier, @TenantIdentifier, @CorrelationIdentifier, @Sou" +
                "rcePlatform, @ExecutionUser, @Name, @Username, @LastName, @Email, @Password, @TypeAccount);";
            command.Parameters.AddWithValue("@Identifier", entity.Identifier.ToString());
            command.Parameters.AddWithValue("@TenantIdentifier", entity.TenantIdentifier.ToString());
            command.Parameters.AddWithValue("@CorrelationIdentifier", entity.CorrelationIdentifier.ToString());
            command.Parameters.AddWithValue("@SourcePlatform", entity.SourcePlatform.ToString()!);
            command.Parameters.AddWithValue("@ExecutionUser", entity.ExecutionUser.ToString());
            command.Parameters.AddWithValue("@Name", entity.Name.ToString()!);
            command.Parameters.AddWithValue("@Username", entity.Username.ToString()!);
            command.Parameters.AddWithValue("@LastName", entity.LastName.ToString()!);
            command.Parameters.AddWithValue("@Email", entity.Email.ToString()!);
            command.Parameters.AddWithValue("@Password", entity.Password.ToString()!);
            command.Parameters.AddWithValue("@TypeAccount", (int)entity.TypeAccount);
            await command.ExecuteNonQueryAsync();
        }
        await _dataConnection.CloseAsync();
    }
}

