using Npgsql;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.CircuitBreaker.Configuration.Interfaces;
using Polly;
using Polly.CircuitBreaker;

namespace OVB.Demos.Ecommerce.Libraries.Infrascructure.CircuitBreaker.Configuration;

public sealed class CircuitBreakerConfiguration : ICircuitBreakerConfiguration
{
    private IDictionary<string, AsyncCircuitBreakerPolicy> _circuitBreakerPolicies;

    public CircuitBreakerConfiguration()
    {
        _circuitBreakerPolicies = new Dictionary<string, AsyncCircuitBreakerPolicy>();

        AddCircuitBreakerPolicy<NpgsqlException>(1, TimeSpan.FromMilliseconds(1500));
        AddCircuitBreakerPolicy<PostgresException>(1, TimeSpan.FromMilliseconds(1500));
    }

    public ICircuitBreakerConfiguration AddCircuitBreakerPolicy<TException>(int exceptionsAllowedBeforeBreak, TimeSpan durationOfBreak)
        where TException : Exception
    {
        if (_circuitBreakerPolicies.ContainsKey(nameof(TException)))
            throw new Exception("This key is already configured.");

        _circuitBreakerPolicies.Add(KeyValuePair.Create(nameof(TException), Policy.Handle<TException>().CircuitBreakerAsync(exceptionsAllowedBeforeBreak, durationOfBreak)));
        return this;
    }

    public AsyncCircuitBreakerPolicy GetCircuitBreakerPolicyByKey<TException>()
        where TException : Exception
    {
        var circuitBreaker = _circuitBreakerPolicies[nameof(TException)];

        if (circuitBreaker is null)
            throw new Exception("The circuit breaker is not configured.");

        return circuitBreaker;
    }
}