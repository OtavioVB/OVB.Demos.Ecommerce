using OpenTelemetry.Trace;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.OpenTelemetry.Configuration.Interfaces;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.OpenTelemetry.Trace.Interfaces;
using System.Diagnostics;

namespace OVB.Demos.Ecommerce.Libraries.Infrascructure.OpenTelemetry.Trace;

public sealed class TraceManager : ITraceManager
{
    public ITracingSource TracingSource => throw new NotImplementedException();

    public async Task StartTracing<TInput>(string name, ActivityKind activityKind, TInput input, Func<TInput, Activity, Task> handler, IDictionary<string, string> dictionaryTags)
    {
        using var activity = TracingSource.ActivitySource.StartActivity(name, activityKind);
        activity?.Start();

        if (activity is null)
            throw new Exception("Observability Activity status is not expected. It is null.");
        try
        {
            await handler(input, activity);
            activity.SetStatus(ActivityStatusCode.Ok);
        }
        catch (Exception ex)
        {
            activity.RecordException(ex);
            activity.SetStatus(ActivityStatusCode.Error);
            throw;
        }
    }

    public Task<TOutput?> StartTracing<TOutput>(string name, ActivityKind activityKind, Func<Activity, Task<TOutput?>> handler, IDictionary<string, string> dictionaryTags)
    {
        throw new NotImplementedException();
    }

    public Task<TOutput> StartTracing<TInput, TOutput>(string name, ActivityKind activityKind, TInput input, Func<TInput, Activity, Task<TOutput>> handler, IDictionary<string, string> dictionaryTags)
    {
        throw new NotImplementedException();
    }

    public Task<bool> StartTracing<TInput>(string name, ActivityKind activityKind, TInput input, Func<TInput, Activity, Task<bool>> handler, IDictionary<string, string> dictionaryTags)
    {
        throw new NotImplementedException();
    }

    public Task<bool> StartTracing(string name, ActivityKind activityKind, Func<Activity, Task<bool>> handler, IDictionary<string, string> dictionaryTags)
    {
        throw new NotImplementedException();
    }

    public Task StartTracing(string name, ActivityKind activityKind, Func<Activity, Task> handler, IDictionary<string, string> dictionaryTags)
    {
        throw new NotImplementedException();
    }
}
