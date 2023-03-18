using ProtoBuf;

namespace OVB.Demos.Ecommerce.Libraries.Domain.Serializator;

public static class Serializator
{
    public static byte[] SerializeProtobuf<TEntity>(TEntity entity) where TEntity : class
    {
        try
        {
            using var memoryStream = new MemoryStream();

            Serializer.Serialize(memoryStream, entity);

            return memoryStream.ToArray();
        }
        catch
        {
            throw new InvalidCastException("Is not possible to serialize an entity to an array bytes, define attributes in protobuf entity.");
        }
    }

    public static TEntity DeserializeProtobuf<TEntity>(byte[] bytes) where TEntity : class
    {
        try
        {
            using var memoryStream = new MemoryStream(bytes);

            var entity = Serializer.Deserialize<TEntity>(memoryStream);

            return entity;
        }
        catch
        {
            throw new InvalidCastException("Is not possible to deserialize a byte array to a protobuf entity, because the structure of your object does not match.");
        }
    }
}
