namespace OVB.Demos.Ecommerce.Microsservices.Account.Application.Services.UseCases.Interfaces;

public interface IUseCase<TInput>
    where TInput : class
{
    public Task<bool> ExecuteUseCaseAsync(TInput input, CancellationToken cancellationToken);
}
