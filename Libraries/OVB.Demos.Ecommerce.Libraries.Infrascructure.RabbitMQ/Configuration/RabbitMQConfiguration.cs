using OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.Configuration.Exceptions;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.Configuration.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;

namespace OVB.Demos.Ecommerce.Libraries.Infrascructure.RabbitMQ.Configuration;

public sealed class RabbitMQConfiguration : IRabbitMQConfiguration
{
    private IConnection? RabbitMQConnection { get; set; }
    private IModel? RabbitMQChannel { get; set; }

    private string Hostname { get; set; }
    private string Virtualhost { get; set; }
    private int Port { get; set; }
    private string ClientProviderName { get; set; }
    private string Username { get; set; }
    private string Password { get; set; }

    public RabbitMQConfiguration(string hostName, string virtualHost, int port, string clientProviderName, string userName, string password)
    {
        Hostname = hostName;
        Virtualhost = virtualHost;
        Port = port;
        ClientProviderName = clientProviderName;
        Username = userName;
        Password = password;
    }

    public IModel GetChannel()
    {
        if (RabbitMQConnection is null)
        {
            var factory = new ConnectionFactory()
            {
                Port = Port,
                HostName = Hostname,
                VirtualHost = Virtualhost,
                UserName = Username,
                ClientProvidedName = ClientProviderName,
                Password = Password,
            };
            RabbitMQConnection = factory.CreateConnection();
        }

        if (RabbitMQChannel is null)
            RabbitMQChannel = RabbitMQConnection.CreateModel();

        return RabbitMQChannel;
    }
}
