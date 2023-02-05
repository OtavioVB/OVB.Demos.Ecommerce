using OVB.Demos.Ecommerce.Microsservices.Account.Domain.ENUMs;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.ValueObjects;
using ProtoBuf;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Domain.Protobuffer;

[ProtoContract()]
public sealed class AccountProtobuf
{
    [ProtoMember(1)]
    public Guid Identifier { get; set; }
    [ProtoMember(2)]
    public Guid TenantIdentifier { get; set; }
    [ProtoMember(3)]
    public Guid CorrelationIdentifier { get; set; }
    [ProtoMember(4)]
    public string? SourcePlatform { get; set; }
    [ProtoMember(5)]
    public string? ExecutionUser { get; set; }
    [ProtoMember(6)]
    public string? Name { get; set; }
    [ProtoMember(7)]
    public string? LastName { get; set; }
    [ProtoMember(8)]
    public string? Username { get; set; }
    [ProtoMember(9)]
    public string? Email { get; set; }
    [ProtoMember(10)]
    public string? Password { get; set; }
    [ProtoMember(11)]
    public int TypeAccount { get; set; }
}
