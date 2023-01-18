using OVB.Demos.Ecommerce.Libraries.DesignPatterns.Adapter;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Infrascructure.Data;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Infrascructure.UnitOfWork.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.Inputs;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.UseCases.CreateAccount.Inputs;
using System.Runtime.CompilerServices;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.UseCases.CreateAccount;

public sealed class CreateAccountUseCase : IUseCase<CreateAccountUseCaseInput>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAccountService _accountService;
    private readonly IAdapter<CreateAccountUseCaseInput, CreateAccountServiceInput> _adapterInput;
    private readonly DataContext _dataContext;
    private readonly IAccountMessengerService _accountMessengerService;

    public CreateAccountUseCase(
        IUnitOfWork unitOfWork, 
        IAccountService accountService,
        IAdapter<CreateAccountUseCaseInput, CreateAccountServiceInput> adapterInput,
        DataContext dataContext,
        IAccountMessengerService accountMessengerService)
    {
        _unitOfWork = unitOfWork;
        _accountService = accountService;
        _adapterInput = adapterInput;
        _dataContext = dataContext;
        _accountMessengerService = accountMessengerService;
    }

    public async Task<bool> ExecuteUseCaseAsync(CreateAccountUseCaseInput input, CancellationToken cancellationToken)
    {
        var transaction = await _dataContext.Database.BeginTransactionAsync();
        return await _unitOfWork.ExecuteAsync(async transaction =>
        {
            var accountCreateAccountResponse = await _accountService.CreateAccountAsync(_adapterInput.Adapt(input), transaction, cancellationToken);
            await _dataContext.SaveChangesAsync();

            if (accountCreateAccountResponse.HasExecuted == true)
            {
                if (accountCreateAccountResponse.Account is null)
                    throw new Exception("Account is null after pass in creation. OVB.Demos.Ecommerce.Microsservices.AccountContext.UseCases.CreateAccount.CreateAccountUseCase:57");

                _accountMessengerService.SendMessageAboutAccountCreatedUsingMessenger(accountCreateAccountResponse.Account);
            }

            return (accountCreateAccountResponse.HasExecuted);
        }, transaction, cancellationToken);
    }
}
