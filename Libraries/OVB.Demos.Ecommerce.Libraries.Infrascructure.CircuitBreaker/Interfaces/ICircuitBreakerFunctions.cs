namespace OVB.Demos.Ecommerce.Libraries.Infrascructure.CircuitBreaker.Interfaces;

public interface ICircuitBreakerFunctions
{
    public Task<(bool HasDone, TOutput? Output)> ExecuteCircuitBreakerAsync<TOutput>(
        string nameCircuitBreaker, Func<CancellationToken, Task<TOutput?>> handler, CancellationToken cancellationToken);
    public Task<(bool HasDone, TOutput? Output)> ExecuteCircuitBreakerAsync<TInput, TOutput>(
        string nameCircuitBreaker, TInput input, Func<TInput, CancellationToken, Task<TOutput?>> handler, CancellationToken cancellationToken);
}
