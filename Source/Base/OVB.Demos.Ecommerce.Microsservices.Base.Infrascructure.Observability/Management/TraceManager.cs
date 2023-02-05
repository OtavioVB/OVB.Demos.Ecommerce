using Microsoft.AspNetCore.Mvc.Formatters;
using OpenTelemetry.Trace;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Configuration.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Management.Interfaces;
using System.Diagnostics;

namespace OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Management;

public sealed class TraceManager : ITraceManager
{
    public ITracingSource TracingSource { get; }

    public TraceManager(ITracingSource tracingSource)
    {
        TracingSource = tracingSource;
    }

    public void StartTracing(string name, ActivityKind activityKind, Action<Activity> handler, IDictionary<string, string> dictionaryTags)        
    {
        using var activity = TracingSource.ActivitySource.StartActivity(name, activityKind);

        if (activity is null)
            throw new Exception("Observability Activity is not expected status. It is null.");

        SetTags(activity, dictionaryTags);

        try
        {
            activity.SetStatus(ActivityStatusCode.Ok);
            handler(activity);
        }
        catch (Exception ex)
        {
            activity.RecordException(ex);
            activity.SetStatus(ActivityStatusCode.Error);
            throw;
        }
    }

    public void StartTracing<TInput>(string name, ActivityKind activityKind, TInput input, Action<TInput, Activity> handler, IDictionary<string, string> dictionaryTags)
    {
        using var activity = TracingSource.ActivitySource.StartActivity(name, activityKind);

        if (activity is null)
            throw new Exception("Observability Activity is not expected status. It is null.");

        SetTags(activity, dictionaryTags);

        try
        {
            activity.SetStatus(ActivityStatusCode.Ok);
            handler(input, activity);
        }
        catch (Exception ex)
        {
            activity.RecordException(ex);
            activity.SetStatus(ActivityStatusCode.Error);
            throw;
        }
    }

    public async Task<TOutput> StartTracing<TInput, TOutput>(string name, ActivityKind activityKind, TInput input, Func<TInput, Activity, Task<TOutput>> handler, IDictionary<string, string> dictionaryTags)
    {
        using var activity = TracingSource.ActivitySource.StartActivity(name, activityKind);

        if (activity is null)
            throw new Exception("Observability Activity is not expected status. It is null.");

        SetTags(activity, dictionaryTags);

        try
        {
            activity.SetStatus(ActivityStatusCode.Ok);
            return await handler(input, activity);
        }
        catch (Exception ex)
        {
            activity.RecordException(ex);
            activity.SetStatus(ActivityStatusCode.Error);
            throw;
        }
    }

    public async Task<bool> StartTracing<TInput>(string name, ActivityKind activityKind, TInput input, Func<TInput, Activity, Task<bool>> handler, IDictionary<string, string> dictionaryTags)
    {
        using var activity = TracingSource.ActivitySource.StartActivity(name, activityKind);

        if (activity is null)
            throw new Exception("Observability Activity is not expected status. It is null.");

        SetTags(activity, dictionaryTags);

        try
        {
            activity.SetStatus(ActivityStatusCode.Ok);
            return await handler(input, activity);
        }
        catch (Exception ex)
        {
            activity.RecordException(ex);
            activity.SetStatus(ActivityStatusCode.Error);
            throw;
        }
    }

    public void SetTags(Activity activity, IDictionary<string, string> dictionaryTags)
    {
        foreach (var keyValuePair in dictionaryTags)
        {
            activity.AddTag(keyValuePair.Key, keyValuePair.Value);
        }
    }
}
