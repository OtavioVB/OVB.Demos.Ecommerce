using OpenTelemetry.Trace;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Management;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Management.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Retry.Interfaces;
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
        where TOutput : class
        where TException : Exception
    {
        return await _traceManager.StartTracing<(bool RetryResult, TOutput? Output)>("Retry Results", ActivityKind.Internal, async (activity) =>
        {
            for (int retriesCount = 0; retriesCount < 5; retriesCount++)
            {
                try
                {
                    // An = Ai + (n - 1).r
                    // A1 = 50 ms
                    // A2 = 125 ms
                    // A3 = 200 ms
                    // A4 = 275 ms
                    // A5 = 350 ms
                    await Task.Delay(50 + (retriesCount)*75);
                    return (true, await handler());
                }
                catch (TException exception)
                {
                    activity.RecordException(exception);
                    continue;
                }
            }

            return (false, null);

        }, new Dictionary<string, string>().AddKeyValue("RetryCount", "5"));
    }
}
