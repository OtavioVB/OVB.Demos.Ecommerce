namespace OVB.Demos.Ecommerce.Libraries.Serialization.Protobuf.Interfaces;

public interface ISerialization
{
    public byte[] SerializeUsingProtobuf<TEntity>(TEntity entity)
        where TEntity : class;
    public TEntity DeserializeUsingProtobuf<TEntity>(byte[] bytes)
        where TEntity : class;
}
