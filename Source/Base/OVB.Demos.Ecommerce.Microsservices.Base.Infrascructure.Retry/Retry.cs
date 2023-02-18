using OpenTelemetry.Trace;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Management;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Management.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Retry.Configuration.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Retry.Interfaces;
using Polly;
using Polly.Retry;
using System.Diagnostics;

namespace OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Retry;

public sealed class Retry<TException> : IRetry<TException>
    where TException : Exception
{
    private readonly RetryPolicy _retryPolicy;
    private readonly ITraceManager _traceManager;

    public Retry(IRetryConfiguration retryConfiguration, ITraceManager traceManager)
    {
        _retryPolicy = retryConfiguration.GetPolicy<TException>();
        _traceManager = traceManager;
    }

    public async Task<(bool RetryResult, TOutput? Output)> TryRetry<TOutput>(Func<Task<TOutput>> handler)
    {
        return await _traceManager.StartTracing<(bool RetryResult, TOutput? Output)>("Retry Results", ActivityKind.Internal, async (activity) =>
        {
            var retryResponse = await _retryPolicy.Execute(async () => 
            {
                return await handler();
            });
            return (true, retryResponse);

        }, new Dictionary<string, string>()));
    }
}
