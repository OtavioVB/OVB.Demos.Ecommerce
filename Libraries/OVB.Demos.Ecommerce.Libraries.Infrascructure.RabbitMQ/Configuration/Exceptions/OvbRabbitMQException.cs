namespace OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.Configuration.Exceptions;

public sealed class OvbRabbitMQException : Exception
{
    public OvbRabbitMQException(string? message) : base(message)
    {
    }
}
