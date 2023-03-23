using RabbitMQ.Client;

namespace OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.Configuration.Properties;

public sealed class BasicProperties : IBasicProperties
{
    public string AppId { get; set; } = string.Empty;
    public string ClusterId { get; set; } = string.Empty;
    public string ContentEncoding { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
    public string CorrelationId { get; set; } = string.Empty;
    public byte DeliveryMode { get; set; }
    public string Expiration { get; set; } = string.Empty;
    public IDictionary<string, object> Headers { get; set; } = new Dictionary<string, object>();
    public string MessageId { get; set; } = string.Empty;
    public bool Persistent { get; set; } 
    public byte Priority { get; set; } 
    public string ReplyTo { get; set; } = string.Empty;
    public PublicationAddress ReplyToAddress { get; set; }
    public AmqpTimestamp Timestamp { get; set; } 
    public string Type { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;

    public BasicProperties(string exchangeType, string exchangeName, string routingKey)
    {
        ReplyToAddress = new PublicationAddress(exchangeType, exchangeName, routingKey);
    }

    public ushort ProtocolClassId => throw new NotImplementedException();

    public string ProtocolClassName => throw new NotImplementedException();

    public void ClearAppId()
    {
        throw new NotImplementedException();
    }

    public void ClearClusterId()
    {
        throw new NotImplementedException();
    }

    public void ClearContentEncoding()
    {
        throw new NotImplementedException();
    }

    public void ClearContentType()
    {
        throw new NotImplementedException();
    }

    public void ClearCorrelationId()
    {
        throw new NotImplementedException();
    }

    public void ClearDeliveryMode()
    {
        throw new NotImplementedException();
    }

    public void ClearExpiration()
    {
        throw new NotImplementedException();
    }

    public void ClearHeaders()
    {
        throw new NotImplementedException();
    }

    public void ClearMessageId()
    {
        throw new NotImplementedException();
    }

    public void ClearPriority()
    {
        throw new NotImplementedException();
    }

    public void ClearReplyTo()
    {
        throw new NotImplementedException();
    }

    public void ClearTimestamp()
    {
        throw new NotImplementedException();
    }

    public void ClearType()
    {
        throw new NotImplementedException();
    }

    public void ClearUserId()
    {
        throw new NotImplementedException();
    }

    public bool IsAppIdPresent()
    {
        throw new NotImplementedException();
    }

    public bool IsClusterIdPresent()
    {
        throw new NotImplementedException();
    }

    public bool IsContentEncodingPresent()
    {
        throw new NotImplementedException();
    }

    public bool IsContentTypePresent()
    {
        throw new NotImplementedException();
    }

    public bool IsCorrelationIdPresent()
    {
        throw new NotImplementedException();
    }

    public bool IsDeliveryModePresent()
    {
        throw new NotImplementedException();
    }

    public bool IsExpirationPresent()
    {
        throw new NotImplementedException();
    }

    public bool IsHeadersPresent()
    {
        throw new NotImplementedException();
    }

    public bool IsMessageIdPresent()
    {
        throw new NotImplementedException();
    }

    public bool IsPriorityPresent()
    {
        throw new NotImplementedException();
    }

    public bool IsReplyToPresent()
    {
        throw new NotImplementedException();
    }

    public bool IsTimestampPresent()
    {
        throw new NotImplementedException();
    }

    public bool IsTypePresent()
    {
        throw new NotImplementedException();
    }

    public bool IsUserIdPresent()
    {
        throw new NotImplementedException();
    }
}
