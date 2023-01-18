using OVB.Demos.Ecommerce.Libraries.DesignPatterns.Adapter;
using OVB.Demos.Ecommerce.Libraries.Serialization.Protobuf.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.Entities.Base;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Infrascructure.Data;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Infrascructure.UnitOfWork.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.ChannelUsageConfiguration;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.RabbitMQ.Publisher.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.Inputs;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.UseCases.CreateAccount.Inputs;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.UseCases.CreateAccount.Inputs.Protobuf;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.UseCases.CreateAccount;

public sealed class CreateAccountUseCase : IUseCase<CreateAccountUseCaseInput>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAccountService _accountService;
    private readonly IMessengerPublisher _messengerPublisher;
    private readonly IChannelUsageConfiguration _channelUsageConfiguration;
    private readonly ISerialization _serialization;
    private readonly IAdapter<CreateAccountUseCaseInput, CreateAccountServiceInput> _adapterInput;
    private readonly IAdapter<AccountBase, AccountProtobuf> _adapterProtobufer;
    private readonly DataContext _dataContext;

    public CreateAccountUseCase(
        IUnitOfWork unitOfWork,
        IAccountService accountService, 
        IAdapter<CreateAccountUseCaseInput, CreateAccountServiceInput> adapterInput,
        IMessengerPublisher messengerPublisher,
        ISerialization serialization,
        IChannelUsageConfiguration channelUsageConfiguration,
        IAdapter<AccountBase, AccountProtobuf> adapterProtobufer,
        DataContext dataContext)
    {
        _unitOfWork = unitOfWork;
        _accountService = accountService;
        _dataContext = dataContext;
        _adapterInput = adapterInput;
        _messengerPublisher = messengerPublisher;
        _serialization = serialization;
        _channelUsageConfiguration = channelUsageConfiguration;
        _adapterProtobufer = adapterProtobufer;
    }

    public async Task<bool> ExecuteUseCaseAsync(CreateAccountUseCaseInput input)
    {
        var transaction = await _dataContext.Database.BeginTransactionAsync();
        return await _unitOfWork.ExecuteAsync(async transaction =>
        {
            var accountCreateAccountResponse = await _accountService.CreateAccountAsync(_adapterInput.Adapt(input), transaction);
            await _dataContext.SaveChangesAsync();

            if (accountCreateAccountResponse.HasExecuted == true)
            {
                if (accountCreateAccountResponse.Account is null)
                    throw new Exception("Account is null after pass in creation. OVB.Demos.Ecommerce.Microsservices.AccountContext.UseCases.CreateAccount.CreateAccountUseCase:57");

                _channelUsageConfiguration.DeclareQueueModel("Microsservices.Account.Created", true, false, false);
                _channelUsageConfiguration.DeclareExchangeChannelModelMode("Microsservices.Account", ExchangeTypes.topic, true, false);
                _channelUsageConfiguration.BindExchangeWithChannel("Microsservices.Account", "Microsservices.Account.Created", "Microsservices.Account.#");
                _messengerPublisher.PublishMessage("Main", "Microsservices.Account", "Microsservices.Account.#", _serialization.SerializeUsingProtobuf(_adapterProtobufer.Adapt(accountCreateAccountResponse.Account)));
            }

            return (accountCreateAccountResponse.HasExecuted);
        }, transaction);
    }
}
