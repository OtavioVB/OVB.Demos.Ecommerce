using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.Services.Inputs;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.Services.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.UseCases.Inputs;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.UseCases.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data;
using OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.UnitOfWork.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Adapter;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.UseCases;

public sealed class CreateAccountUseCase : IUseCase<CreateAccountUseCaseInput>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAccountService _accountService;
    private readonly DataContext _dataContext;
    private readonly IAdapter<CreateAccountUseCaseInput, CreateAccountServiceInput> _adapterUseCaseInputToAccountServiceInput;

    public CreateAccountUseCase(
        IUnitOfWork unitOfWork, 
        IAccountService accountService, 
        DataContext dataContext, 
        IAdapter<CreateAccountUseCaseInput, CreateAccountServiceInput> adapterUseCaseInputToAccountServiceInput)
    {
        _unitOfWork = unitOfWork;
        _accountService = accountService;
        _dataContext = dataContext;
        _adapterUseCaseInputToAccountServiceInput = adapterUseCaseInputToAccountServiceInput;
    }

    public async Task<bool> ExecuteUseCaseAsync(CreateAccountUseCaseInput input, CancellationToken cancellationToken)
    {
        var transaction = await _dataContext.Database.BeginTransactionAsync(cancellationToken);
        return await _unitOfWork.ExecuteUnitOfWorkAsync(async (transaction, cancellationToken) =>
        {
            var accountCreateResponse = await _accountService.CreateAccountAsync(_adapterUseCaseInputToAccountServiceInput.Adapter(input), cancellationToken);

            if (accountCreateResponse.HasDone)
                return true;
            else
                return false;
        }, transaction, cancellationToken);
    }
}
