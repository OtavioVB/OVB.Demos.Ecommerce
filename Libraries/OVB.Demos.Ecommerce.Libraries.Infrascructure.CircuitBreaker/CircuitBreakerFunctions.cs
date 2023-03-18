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

        var policyResult = await respectiveCircuitBreakerPolicy.ExecuteAndCaptureAsync(async (context, cancellationToken) =>
        {
            var response = await handler(cancellationToken);
            context.Add("output", response);
        }, contextData: new Dictionary<string, object?>(), cancellationToken);

        var policyHasBeenExecutedSuccesfull = policyResult.Outcome == OutcomeType.Successful;

        if (policyHasBeenExecutedSuccesfull == false)
        {
            return (HasDone: false, Output: (TOutput)policyResult.Context["output"]);
        }

        return (true, (TOutput)policyResult.Context["output"]);
    }

    public async Task<(bool HasDone, TOutput? Output)> ExecuteCircuitBreakerAsync<TInput, TOutput>(
        string nameCircuitBreaker, TInput input, Func<TInput, CancellationToken, Task<TOutput?>> handler, CancellationToken cancellationToken)
    {
        var respectiveCircuitBreakerPolicy = _circuitBreakerConfiguration.GetCircuitBreakerPolicyByKey(nameCircuitBreaker);

        var policyResult = await respectiveCircuitBreakerPolicy.ExecuteAndCaptureAsync(async (context, cancellationToken) =>
        {
            var response = await handler(input, cancellationToken);
            context.Add("output", response);
        }, contextData: new Dictionary<string, object?>(), cancellationToken);

        var policyHasBeenExecutedSuccesfull = policyResult.Outcome == OutcomeType.Successful;

        if (policyHasBeenExecutedSuccesfull == false)
        {
            return (HasDone: false, Output: (TOutput)policyResult.Context["output"]);
        }

        return (true, (TOutput)policyResult.Context["output"]);
    }
}
