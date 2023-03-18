using OVB.Demos.Ecommerce.Libraries.Infrascructure.RetryPattern.Configuration.ENUMs;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RetryPattern.Configuration.Interfaces;
using Polly;
using Polly.Retry;

namespace OVB.Demos.Ecommerce.Libraries.Infrascructure.RetryPattern.Configuration;

public sealed class RetryConfiguration : IRetryConfiguration
{
    private TypeRetry? _typeRetry;
    private TimeSpan _ratio = TimeSpan.FromMilliseconds(75);
    private TimeSpan _firstTime = TimeSpan.FromMilliseconds(50);
    private int _numberOfRetries = 5;

    public IRetryConfiguration SetTypeOfRetryEqualGeometricProgression(TimeSpan ratio, TimeSpan firstTime, int numberOfRetries)
    {
        if (_typeRetry is not null)
            throw new Exception("Type of retry has been setted.");

        _ratio = ratio;
        _firstTime = firstTime;
        _numberOfRetries = numberOfRetries;
        _typeRetry = TypeRetry.GeometricProgression;
        return (RetryConfiguration)this;
    }

    public IRetryConfiguration SetTypeOfRetryEqualArithmeticProgression(TimeSpan ratio, TimeSpan firstTime, int numberOfRetries)
    {
        if (_typeRetry is not null)
            throw new Exception("Type of retry has been setted.");

        _ratio = ratio;
        _firstTime = firstTime;
        _typeRetry = TypeRetry.ArithmeticProgression;
        _numberOfRetries = numberOfRetries;
        return (RetryConfiguration)this;
    }

    public IRetryConfiguration SetTypeOfRetryStandard(TimeSpan ratio, int numberOfRetries)
    {
        if (_typeRetry is not null)
            throw new Exception("Type of retry has been setted.");

        _numberOfRetries = numberOfRetries;
        _typeRetry = TypeRetry.Standard;
        return (RetryConfiguration)this;
    }

    public RetryPolicy GetPolicy<TException>()
        where TException : Exception
    {
        if (_typeRetry is null)
            throw new Exception("Type of Retry Configuration has not been setted.");

        switch (_typeRetry)
        {
            case TypeRetry.Standard:
                return Policy.Handle<TException>().WaitAndRetry(_numberOfRetries, (exception) =>
                {
                    return _ratio;
                });
            case TypeRetry.ArithmeticProgression:
                var retries = new TimeSpan[_numberOfRetries];

                for (int i = 0; i < _numberOfRetries; i++)
                {
                    retries[i] = _firstTime + i * _ratio;
                }

                return Policy.Handle<TException>().WaitAndRetry(retries);
            case TypeRetry.GeometricProgression:
                var retriesGeometric = new TimeSpan[_numberOfRetries];

                for (int i = 0; i < _numberOfRetries; i++)
                {
                    retriesGeometric[i] = _firstTime * Math.Pow(_ratio.TotalMilliseconds, i);
                }

                return Policy.Handle<TException>().WaitAndRetry(retriesGeometric);
            default:
                throw new Exception("Type of Retry Configuration has not been setted.");
        }
    }
}
