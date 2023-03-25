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

    public async Task<(bool HasDone, TOutput? Output)> ExecuteCircuitBreakerAsync<TOutput>(
        string nameCircuitBreaker, Func<CancellationToken, Task<TOutput?>> handler, CancellationToken cancellationToken)
    {
        var respectiveCircuitBreakerPolicy = _circuitBreakerConfiguration.GetCircuitBreakerPolicyByKey(nameCircuitBreaker);

        TOutput? response = default;

        var policyResult = await respectiveCircuitBreakerPolicy.ExecuteAndCaptureAsync(async (context, cancellationToken) =>
        {
            response = await handler(cancellationToken);
        }, contextData: new Dictionary<string, object>(), cancellationToken);

        var policyHasBeenExecutedSuccesfull = policyResult.Outcome == OutcomeType.Successful;

        if (policyHasBeenExecutedSuccesfull == false)
        {
            return (HasDone: false, Output: response);
        }

        return (true, response);
    }

    public async Task<(bool HasDone, TOutput? Output)> ExecuteCircuitBreakerAsync<TInput, TOutput>(
        string nameCircuitBreaker, TInput input, Func<TInput, CancellationToken, Task<TOutput?>> handler, CancellationToken cancellationToken)
    {
        var respectiveCircuitBreakerPolicy = _circuitBreakerConfiguration.GetCircuitBreakerPolicyByKey(nameCircuitBreaker);

        TOutput? response = default;

        var policyResult = await respectiveCircuitBreakerPolicy.ExecuteAndCaptureAsync(async (context, cancellationToken) =>
        {
            response = await handler(input, cancellationToken);
        }, contextData: new Dictionary<string, object>(), cancellationToken);

        var policyHasBeenExecutedSuccesfull = policyResult.Outcome == OutcomeType.Successful;

        if (policyHasBeenExecutedSuccesfull == false)
        {
            return (HasDone: false, Output: response);
        }

        return (true, response);
    }
}
