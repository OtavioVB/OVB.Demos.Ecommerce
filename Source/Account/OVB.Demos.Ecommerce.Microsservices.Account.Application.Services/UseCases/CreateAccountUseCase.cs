using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.Services.Inputs;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.Services.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.UseCases.Inputs;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.UseCases.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.Entities.Base;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.Protobuffer;
using OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data;
using OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.UnitOfWork.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Adapter;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Management.Interfaces;
using System.Diagnostics;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.UseCases;

public sealed class CreateAccountUseCase : IUseCase<CreateAccountUseCaseInput>
{
    private readonly ITraceManager _traceManager;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAccountService _accountService;
    private readonly DataContext _dataContext;
    private readonly IAdapter<CreateAccountUseCaseInput, CreateAccountServiceInput> _adapterUseCaseInputToAccountServiceInput;
    private readonly IAdapter<AccountBase, AccountProtobuf> _adapterAccountBaseToAccountProtobuf;
    private readonly IMessengerSynchronizerService<AccountProtobuf> _messengerSynchronizerService;

    public CreateAccountUseCase(
        ITraceManager traceManager,
        IUnitOfWork unitOfWork, 
        IAccountService accountService, 
        DataContext dataContext, 
        IAdapter<CreateAccountUseCaseInput, CreateAccountServiceInput> adapterUseCaseInputToAccountServiceInput, 
        IMessengerSynchronizerService<AccountProtobuf> messengerSynchronizerService,
        IAdapter<AccountBase, AccountProtobuf> adapterAccountBaseToAccountProtobuf)
    {
        _traceManager = traceManager;
        _unitOfWork = unitOfWork;
        _accountService = accountService;
        _dataContext = dataContext;
        _adapterUseCaseInputToAccountServiceInput = adapterUseCaseInputToAccountServiceInput;
        _messengerSynchronizerService = messengerSynchronizerService;
        _adapterAccountBaseToAccountProtobuf = adapterAccountBaseToAccountProtobuf;
    }

    public async Task<bool> ExecuteUseCaseAsync(CreateAccountUseCaseInput input, CancellationToken cancellationToken)
    {
        var transaction = await _dataContext.Database.BeginTransactionAsync(cancellationToken);
        return await _unitOfWork.ExecuteUnitOfWorkAsync(async (transaction, cancellationToken) =>
        {
            var accountCreateResponse = await _accountService.CreateAccountAsync(_adapterUseCaseInputToAccountServiceInput.Adapter(input), cancellationToken);

            if (accountCreateResponse.HasDone)
            {
                _messengerSynchronizerService.PublishMessengerToSynchronizeDatabase(_adapterAccountBaseToAccountProtobuf.Adapter(accountCreateResponse.Account));
                return true;
            }
            else
                return false;
        }, transaction, cancellationToken);
    }
}
