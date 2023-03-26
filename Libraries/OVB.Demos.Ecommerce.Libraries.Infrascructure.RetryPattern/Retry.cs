using OVB.Demos.Ecommerce.Libraries.Infrascructure.CircuitBreaker.Interfaces;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RetryPattern.Configuration.Interfaces;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RetryPattern.Interfaces;
using System.Threading;

namespace OVB.Demos.Ecommerce.Libraries.Infrascructure.RetryPattern;

public sealed class Retry : IRetry
{
    private readonly IRetryConfiguration _retryConfiguration;
    private readonly ICircuitBreakerFunctions _circuitBreakerFunctions;

    public Retry(
        IRetryConfiguration retryConfiguration, 
        ICircuitBreakerFunctions circuitBreakerFunctions)
    {
        _retryConfiguration = retryConfiguration;
        _circuitBreakerFunctions = circuitBreakerFunctions;
    }

    public TOutput TryRetry<TOutput, TException>(Func<TOutput> handler)
        where TException : Exception
    {
        return _retryConfiguration.GetPolicy<TException>().Execute(() =>
        {
            return handler();
        });
    }

    public TOutput TryRetry<TOutput, TException, TExceptionTwo>(Func<TOutput> handler)
        where TException : Exception
        where TExceptionTwo : Exception
    {
        return _retryConfiguration.GetPolicy<TExceptionTwo>().Execute(() =>
        {
            return _retryConfiguration.GetPolicy<TException>().Execute(() =>
            {
                return handler();
            });
        });
    }

    public Task TryRetry<TException>(Func<Task> handler)
        where TException : Exception
    {
        return _retryConfiguration.GetPolicy<TException>().Execute(() =>
        {
            return handler();
        });
    }

    public Task<TOutput> TryRetryWithCircuitBreaker<TOutput, TException, TExceptionTwo>(Func<TOutput> handler, CancellationToken cancellationToken)
        where TException : Exception
        where TExceptionTwo : Exception
    {
        return _circuitBreakerFunctions.ExecuteCircuitBreakerAsync<TOutput, TException>(async (cancellationToken) =>
        {
            return await _circuitBreakerFunctions.ExecuteCircuitBreakerAsync<TOutput, TExceptionTwo>((cancellationToken) =>
            {
                return _retryConfiguration.GetPolicy<TExceptionTwo>().Execute(() =>
                {
                    return _retryConfiguration.GetPolicy<TException>().Execute(async () =>
                    {
                        return await handler();
                    });
                });
            }, cancellationToken);
        }, cancellationToken);
    }

    public Task<TOutput> TryRetryWithCircuitBreaker<TOutput, TException>(Func<TOutput> handler, CancellationToken cancellationToken)
        where TException : Exception
    {
        return _circuitBreakerFunctions.ExecuteCircuitBreakerAsync<TOutput, TException>((cancellationToken) =>
        {
            return _retryConfiguration.GetPolicy<TException>().Execute(() =>
            {
                return handler();
            });
        }, cancellationToken);
    }
}
