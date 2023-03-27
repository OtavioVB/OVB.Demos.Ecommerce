using Npgsql;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.CircuitBreaker.Configuration.Interfaces;
using Polly;
using Polly.CircuitBreaker;
using RabbitMQ.Client.Exceptions;

namespace OVB.Demos.Ecommerce.Libraries.Infrascructure.CircuitBreaker.Configuration;

public sealed class CircuitBreakerConfiguration : ICircuitBreakerConfiguration
{
    private IDictionary<string, AsyncCircuitBreakerPolicy> _circuitBreakerPolicies;

    public CircuitBreakerConfiguration()
    {
        _circuitBreakerPolicies = new Dictionary<string, AsyncCircuitBreakerPolicy>();

        AddCircuitBreakerPolicy<NpgsqlException>(1, TimeSpan.FromMilliseconds(1500));
        AddCircuitBreakerPolicy<PostgresException>(1, TimeSpan.FromMilliseconds(1500));
        AddCircuitBreakerPolicy<RabbitMQClientException>(1, TimeSpan.FromMilliseconds(1500));
    }

    public ICircuitBreakerConfiguration AddCircuitBreakerPolicy<TException>(int exceptionsAllowedBeforeBreak, TimeSpan durationOfBreak)
        where TException : Exception
    {
        if (_circuitBreakerPolicies.ContainsKey(typeof(TException).ToString()))
            throw new Exception($"This key is already configured - {typeof(TException)}");

        _circuitBreakerPolicies.Add(KeyValuePair.Create(typeof(TException).ToString(), Policy.Handle<TException>().CircuitBreakerAsync(exceptionsAllowedBeforeBreak, durationOfBreak)));
        return this;
    }

    public AsyncCircuitBreakerPolicy GetCircuitBreakerPolicyByKey<TException>()
        where TException : Exception
    {
        var circuitBreaker = _circuitBreakerPolicies[typeof(TException).ToString()];

        if (circuitBreaker is null)
            throw new Exception("The circuit breaker is not configured.");

        return circuitBreaker;
    }
}