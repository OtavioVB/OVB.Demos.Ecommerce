using OpenTelemetry.Trace;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Management;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Management.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Retry.Interfaces;
using Polly;
using Polly.Retry;
using System.Diagnostics;

namespace OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Retry;

public sealed class Retry : IRetry
{
    private readonly ITraceManager _traceManager;

    public Retry(ITraceManager traceManager)
    {
        _traceManager = traceManager;
    }

    public async Task<(bool RetryResult, TOutput? Output)> TryRetry<TOutput, TException>(Func<Task<TOutput>> handler)
        where TException : Exception
    {
        return await _traceManager.StartTracing<(bool RetryResult, TOutput? Output)>("Retry Results", ActivityKind.Internal, async (activity) =>
        {

            RetryPolicy retry = Policy
            .Handle<TException>()
            .WaitAndRetry(new[]
            {
                TimeSpan.FromMicroseconds(50),
                TimeSpan.FromMicroseconds(125),
                TimeSpan.FromMicroseconds(200),
                TimeSpan.FromMicroseconds(275),
                TimeSpan.FromMicroseconds(350),
            });
            return retry.Execute(async () =>
            {
                return await handler();
            });

        }, new Dictionary<string, string>().AddKeyValue("RetryCount", "5"));
    }
}
