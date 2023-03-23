using ProtoBuf;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.Protobuffer;

[ProtoContract()]
public sealed class UserProtobuffer
{
    public UserProtobuffer(string username, string name, string lastName, string email, string password, int typeUser, bool isEmailConfirmed)
    {
        Username = username;
        Name = name;
        LastName = lastName;
        Email = email;
        Password = password;
        TypeUser = typeUser;
        IsEmailConfirmed = isEmailConfirmed;
    }

    [ProtoMember(1)]
    public string Username { get; set; }

    [ProtoMember(2)]
    public string Name { get; set; }

    [ProtoMember(3)]
    public string LastName { get; set; }

    [ProtoMember(4)]
    public string Email { get; set; }

    [ProtoMember(5)]
    public string Password { get; set; }

    [ProtoMember(6)]
    public int TypeUser { get; set; }

    [ProtoMember(7)]
    public bool IsEmailConfirmed { get; set; }
}
