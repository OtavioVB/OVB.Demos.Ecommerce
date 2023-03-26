using OVB.Demos.Ecommerce.Libraries.Infrascructure.CircuitBreaker.Configuration.Interfaces;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.CircuitBreaker.Interfaces;
using Polly;

namespace OVB.Demos.Ecommerce.Libraries.Infrascructure.CircuitBreaker;

public sealed class CircuitBreakerFunctions : ICircuitBreakerFunctions
{
    private readonly ICircuitBreakerConfiguration _circuitBreakerConfiguration;

    public CircuitBreakerFunctions(ICircuitBreakerConfiguration circuitBreakerConfiguration)
    {
        _circuitBreakerConfiguration = circuitBreakerConfiguration;
    }

    public async Task<TOutput> ExecuteCircuitBreakerAsync<TInput, TOutput, TException>(TInput input, 
        Func<TInput, CancellationToken, Task<TOutput>> handler, CancellationToken cancellationToken)
        where TException : Exception
    {
        var respectiveCircuitBreakerPolicy = _circuitBreakerConfiguration.GetCircuitBreakerPolicyByKey<TException>();

        TOutput? response = default(TOutput);

        var policyResult = await respectiveCircuitBreakerPolicy.ExecuteAndCaptureAsync(async (context, cancellationToken) =>
        {
            response = await handler(input, cancellationToken);
        }, contextData: new Dictionary<string, object>(), cancellationToken);

        var policyHasBeenExecutedSuccesfull = policyResult.Outcome == OutcomeType.Successful;

        if (policyHasBeenExecutedSuccesfull == false)
        {
            throw policyResult.FinalException;
        }

        if (response is null)
            throw new NotImplementedException();

        return (response);
    }

    public async Task<TOutput> ExecuteCircuitBreakerAsync<TOutput, TException>(Func<CancellationToken, Task<TOutput>> handler, 
        CancellationToken cancellationToken) where TException : Exception
    {
        var respectiveCircuitBreakerPolicy = _circuitBreakerConfiguration.GetCircuitBreakerPolicyByKey<TException>();

        TOutput? response = default(TOutput);

        var policyResult = await respectiveCircuitBreakerPolicy.ExecuteAndCaptureAsync(async (context, cancellationToken) =>
        {
            response = await handler(cancellationToken);
        }, contextData: new Dictionary<string, object>(), cancellationToken);

        var policyHasBeenExecutedSuccesfull = policyResult.Outcome == OutcomeType.Successful;

        if (policyHasBeenExecutedSuccesfull == false)
        {
            throw policyResult.FinalException;
        }

        if (response is null)
            throw new NotImplementedException();

        return (response);
    }
}
