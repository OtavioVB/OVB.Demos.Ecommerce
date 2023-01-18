using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.ENUMs;
using ProtoBuf;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.UseCases.CreateAccount.Inputs.Protobuf;

[ProtoContract]
public sealed class AccountProtobuf
{
    [ProtoMember(1)]
    public string Identifier { get; set; }
    [ProtoMember(2)]
    public string Username { get; set; }
    [ProtoMember(3)]
    public string Password { get; set; }
    [ProtoMember(4)]
    public string Email { get; set; }
    [ProtoMember(5)]
    public int TypeAccount { get; set; }
}
