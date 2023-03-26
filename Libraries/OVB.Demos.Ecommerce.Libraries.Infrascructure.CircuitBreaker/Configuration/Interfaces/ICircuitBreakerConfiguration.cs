using Polly.CircuitBreaker;

namespace OVB.Demos.Ecommerce.Libraries.Infrascructure.CircuitBreaker.Configuration.Interfaces;

public interface ICircuitBreakerConfiguration
{
    public ICircuitBreakerConfiguration AddCircuitBreakerPolicy<TException>(int exceptionsAllowedBeforeBreak, TimeSpan durationOfBreak)
        where TException : Exception;
    public AsyncCircuitBreakerPolicy GetCircuitBreakerPolicyByKey<TException>()
        where TException : Exception;
}
