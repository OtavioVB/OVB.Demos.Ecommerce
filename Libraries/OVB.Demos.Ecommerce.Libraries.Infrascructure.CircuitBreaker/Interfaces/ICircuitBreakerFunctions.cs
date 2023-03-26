﻿namespace OVB.Demos.Ecommerce.Libraries.Infrascructure.CircuitBreaker.Interfaces;

public interface ICircuitBreakerFunctions
{
    public Task<TOutput> ExecuteCircuitBreakerAsync<TOutput, TException>(
        Func<CancellationToken, TOutput> handler, CancellationToken cancellationToken)
        where TException : Exception;

    public Task<TOutput> ExecuteCircuitBreakerAsync<TOutput, TException>(
        Func<CancellationToken, Task<TOutput>> handler, CancellationToken cancellationToken)
        where TException : Exception;

    public Task<TOutput> ExecuteCircuitBreakerAsync<TInput, TOutput, TException>(TInput input,
        Func<TInput, CancellationToken, TOutput> handler, CancellationToken cancellationToken)
        where TException : Exception;
}
