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

        AddCircuitBreakerPolicy<NpgsqlException>("Npgsql", 1, TimeSpan.FromMilliseconds(1500));
        AddCircuitBreakerPolicy<PostgresException>("Postgres", 1, TimeSpan.FromMilliseconds(1500));
    }

    public ICircuitBreakerConfiguration AddCircuitBreakerPolicy<TException>(string name, int exceptionsAllowedBeforeBreak, TimeSpan durationOfBreak)
        where TException : Exception
    {
        if (_circuitBreakerPolicies.ContainsKey(name))
            throw new Exception("This key is already configured.");

        _circuitBreakerPolicies.Add(KeyValuePair.Create(name, Policy.Handle<TException>().CircuitBreakerAsync(exceptionsAllowedBeforeBreak, durationOfBreak)));
        return this;
    }

    public AsyncCircuitBreakerPolicy GetCircuitBreakerPolicyByKey(string key)
    {
        var circuitBreaker = _circuitBreakerPolicies[key];

        if (circuitBreaker is null)
            throw new Exception("The circuit breaker is not configured.");

        return circuitBreaker;
    }
}