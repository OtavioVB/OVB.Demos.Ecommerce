using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Management.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Retry.Configuration.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Retry.Interfaces;
using System.Diagnostics;

namespace OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Retry;

public sealed class Retry : IRetry
{
    private readonly IRetryConfiguration _retryConfiguration;
    private readonly ITraceManager _traceManager;

    public Retry(
        IRetryConfiguration retryConfiguration, 
        ITraceManager traceManager)
    {
        _retryConfiguration = retryConfiguration;
        _traceManager = traceManager;
    }

    public Task<TOutput?> TryRetry<TOutput, TException>(Func<Task<TOutput?>> handler)
        where TException : Exception
    {
        return _traceManager.StartTracing("Polly Retries", ActivityKind.Internal, (activity) =>
        {
            return _retryConfiguration.GetPolicy<TException>().Execute(() => 
            {
                return handler();
            });
        }, 
        new Dictionary<string, string>());
    }

    public Task TryRetry<TException>(Func<Task> handler)
        where TException : Exception
    {
        return _traceManager.StartTracing("Polly Retries", ActivityKind.Internal, (activity) =>
        {
            return _retryConfiguration.GetPolicy<TException>().Execute(() =>
            {
                return handler();
            });

        },
        new Dictionary<string, string>());
    }
}