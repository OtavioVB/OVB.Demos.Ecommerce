using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.UseCases.Inputs;
using OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.UseCases.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.UseCases;

public sealed class CreateAccountUseCase : IUseCase<CreateAccountUseCaseInput>
{
    public Task<bool> ExecuteUseCaseAsync(CreateAccountUseCaseInput input, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
