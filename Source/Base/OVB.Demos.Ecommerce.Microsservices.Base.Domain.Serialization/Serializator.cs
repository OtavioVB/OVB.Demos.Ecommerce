using ProtoBuf;

namespace OVB.Demos.Ecommerce.Microsservices.Base.Domain.Serialization;

/// <summary>
/// This class serialize objects that using protobuf-net.
/// </summary>
public static class Serializator
{
    public static byte[] SerializeProtobuf<TEntity>(TEntity entity) where TEntity : class
    {
        using var memoryStream = new MemoryStream();

        Serializer.Serialize(memoryStream, entity);

        return memoryStream.ToArray();
    }

    public static TEntity DeserializeProtobuf<TEntity>(byte[] bytes) where TEntity : class
    {
        using var memoryStream = new MemoryStream(bytes);

        var entity = Serializer.Deserialize<TEntity>(memoryStream);

        return entity;
    }
}
