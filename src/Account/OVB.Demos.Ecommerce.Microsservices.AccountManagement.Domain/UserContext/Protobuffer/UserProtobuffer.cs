using ProtoBuf;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.Protobuffer;

[ProtoContract()]
public sealed class UserProtobuffer
{
    [ProtoMember(1)]
    public string? Username { get; set; }

    [ProtoMember(2)]
    public string? Name { get; set; }

    [ProtoMember(3)]
    public string? LastName { get; set; }

    [ProtoMember(4)]
    public string? Email { get; set; }

    [ProtoMember(5)]
    public string? Password { get; set; }

    [ProtoMember(6)]
    public int TypeUser { get; set; }

    [ProtoMember(7)]
    public bool IsEmailConfirmed { get; set; }

    [ProtoMember(8)]
    public string? Identifier { get; set; }

    [ProtoMember(9)]
    public string? CorrelationIdentifier { get; set; }

    [ProtoMember(10)]
    public string?TenantIdentifier { get; set; }

    [ProtoMember(11)]
    public string? SourcePlatform { get; set; }

    [ProtoMember(12)]
    public DateTime CreatedOn { get; set; }
}
