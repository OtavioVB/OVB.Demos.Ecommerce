﻿using OVB.Demos.Ecommerce.Libraries.Domain.ValueObjects;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker.Infrascructure.Connection.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker.Infrascructure.Repositories.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Synchronizer.Worker.Infrascructure.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly IDataConnection _dataConnection;

    public UserRepository(IDataConnection dataConnection)
    {
        _dataConnection = dataConnection;
    }

    public Task AddUserAsync()
    {
        throw new NotImplementedException();
    }

    public async Task CreateTableUserIfThisNotExists()
    {
        var connection = await _dataConnection.GetNpgsqlConnectionAsync();
        using (var command = connection.CreateCommand())
        {
            command.CommandText = $"CREATE TABLE IF NOT EXISTS \"User\" ( " +
                $"Identifier UUID, " +
                $"Username VARCHAR({Username.MaxLength}) NOT NULL, " +
                $"Name VARCHAR({Name.MaxLength}) NOT NULL, " +
                $"LastName VARCHAR({LastName.MaxLength}) NOT NULL, " +
                $"Email VARCHAR({Email.MaxLength}) NOT NULL, " +
                $"Password VARCHAR({Password.MaxLength}) NOT NULL, " +
                $"TypeUser SMALLINT, " +
                $"IsEmailConfirmed BOOLEAN," +
                $"CONSTRAINT Pk_User_Identifier PRIMARY KEY (Identifier)," +
                $"CONSTRAINT Uk_User_UsernameAndEmail UNIQUE (Username, Email) " +
                ");";
            await command.ExecuteNonQueryAsync();
        }
    }
}