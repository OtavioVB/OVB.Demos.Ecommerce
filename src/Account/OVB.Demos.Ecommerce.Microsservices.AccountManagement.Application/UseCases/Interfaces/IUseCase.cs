namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Application.UseCases.Interfaces;

public interface IUseCase<TInput, TOutput>
{
    public Task<(bool HasDone, TOutput Output)> ExecuteUseCaseAsync(TInput input, CancellationToken cancellationToken);
}
