using Polly.Retry;

namespace OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Retry.Configuration.Interfaces;

public interface IRetryConfiguration
{
    public IRetryConfiguration SetTypeOfRetryEqualGeometricProgression(TimeSpan ratio, TimeSpan firstTime, int numberOfRetries);
    public IRetryConfiguration SetTypeOfRetryEqualArithmeticProgression(TimeSpan ratio, TimeSpan firstTime, int numberOfRetries);
    public IRetryConfiguration SetTypeOfRetryStandard(TimeSpan ratio, int numberOfRetries);
    public RetryPolicy GetPolicy<TException>()
        where TException : Exception;
}
