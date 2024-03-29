﻿using OVB.Demos.Ecommerce.Libraries.Domain;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.AccountContext.DataTransferObject;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.DataTransferObject;

public sealed class User : DataTransferObjectBase
{
    public User(string username, string name, string lastName, string email, string password, bool isEmailConfirmed, int typeUser,
        Guid identifier, Guid tenantIdentifier, Guid correlationIdentifier, string sourcePlatform, DateTime createdOn) 
        : base(identifier, tenantIdentifier, correlationIdentifier, sourcePlatform, createdOn)
    {
        Username = username;
        Name = name;
        LastName = lastName;
        Email = email;
        Password = password;
        IsEmailConfirmed = isEmailConfirmed;
        TypeUser = typeUser;
    }

    public string Username { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int TypeUser { get; set; }
    public bool IsEmailConfirmed { get; set; }
    public Account? Account { get; set; }
}
