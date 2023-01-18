using OVB.Demos.Ecommerce.Libraries.Serialization.Protobuf.Interfaces;
using ProtoBuf;

namespace OVB.Demos.Ecommerce.Libraries.Serialization.Protobuf;

public class Serialization : ISerialization
{
    public virtual byte[] SerializeUsingProtobuf<TEntity>(TEntity entity)
        where TEntity : class
    {
        using var memoryStream = new MemoryStream();

        Serializer.Serialize(memoryStream, entity);

        return memoryStream.ToArray();
    }

    public virtual TEntity DeserializeUsingProtobuf<TEntity>(byte[] bytes)
        where TEntity : class
    {
        using var memoryStream = new MemoryStream(bytes);

        var entity = Serializer.Deserialize<TEntity>(memoryStream);

        return entity;
    }
}
