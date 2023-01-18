using OVB.Demos.Ecommerce.Libraries.DesignPatterns.Adapter;
using OVB.Demos.Ecommerce.Libraries.Serialization.Protobuf.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.Entities.Base;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.ChannelUsageConfiguration;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Publisher.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.Inputs.Protobuf;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Services;

public sealed class AccountMessengerService : IAccountMessengerService
{
    private readonly IChannelUsageConfiguration _channelUsageConfiguration;
    private readonly IMessengerPublisher _messengerPublisher;
    private readonly ISerialization _serialization;
    private readonly IAdapter<AccountBase, AccountProtobuf> _adapterProtobufer;

    public AccountMessengerService(
        IChannelUsageConfiguration channelUsageConfiguration,
        IMessengerPublisher messengerPublisher,
        ISerialization serialization,
        IAdapter<AccountBase, AccountProtobuf> adapterProtobufer)
    {
        _channelUsageConfiguration = channelUsageConfiguration;
        _messengerPublisher = messengerPublisher;
        _serialization = serialization;
        _adapterProtobufer = adapterProtobufer;
    }

    public void SendMessageAboutAccountCreatedUsingMessenger(AccountBase account)
    {
        _channelUsageConfiguration.DeclareQueueModel("Microsservices.Account.Created", true, false, false);
        _channelUsageConfiguration.DeclareExchangeChannelModelMode("Microsservices.Account", ExchangeTypes.topic, true, false);
        _channelUsageConfiguration.BindExchangeWithChannel("Microsservices.Account", "Microsservices.Account.Created", "Microsservices.Account.#");
        _messengerPublisher.PublishMessage("Main", "Microsservices.Account", "Microsservices.Account.#", _serialization.SerializeUsingProtobuf(_adapterProtobufer.Adapt(account)));
    }
}