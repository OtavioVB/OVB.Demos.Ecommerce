namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Services.UseCases;

public interface IUseCase<TInput>
    where TInput : class
{
    public Task<bool> ExecuteUseCaseAsync(TInput input);
}
