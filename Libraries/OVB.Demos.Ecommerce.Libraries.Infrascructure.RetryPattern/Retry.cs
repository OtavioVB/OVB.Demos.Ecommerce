using OVB.Demos.Ecommerce.Libraries.Infrascructure.RetryPattern.Configuration.Interfaces;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RetryPattern.Interfaces;

namespace OVB.Demos.Ecommerce.Libraries.Infrascructure.RetryPattern;

public sealed class Retry : IRetry
{
    private readonly IRetryConfiguration _retryConfiguration;

    public Retry(
        IRetryConfiguration retryConfiguration)
    {
        _retryConfiguration = retryConfiguration;
    }

    public TOutput TryRetry<TOutput, TException>(Func<TOutput> handler)
        where TException : Exception
    {
        return _retryConfiguration.GetPolicy<TException>().Execute(() =>
        {
            return handler();
        });
    }

    public Task TryRetry<TException>(Func<Task> handler)
        where TException : Exception
    {
        return _retryConfiguration.GetPolicy<TException>().Execute(() =>
        {
            return handler();
        });
    }
}
