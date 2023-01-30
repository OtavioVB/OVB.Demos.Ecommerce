using OpenTelemetry.Trace;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Configuration.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Management.Interfaces;
using System.Diagnostics;

namespace OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Management;

public sealed class TraceManager : ITraceManager
{
    private readonly ITracingSource _tracingSource;

    public TraceManager(ITracingSource tracingSource)
    {
        _tracingSource = tracingSource;
    }

    public void StartTracing(string name, ActivityKind activityKind, Action<Activity> handler, IDictionary<string, string> dictionaryTags)        
    {
        using var activity = _tracingSource.ActivitySource.StartActivity(name, activityKind);

        if (activity is null)
            return;

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
        using var activity = _tracingSource.ActivitySource.StartActivity(name, activityKind);

        if (activity is null)
            return;

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

    public void SetTags(Activity activity, IDictionary<string, string> dictionaryTags)
    {
        foreach (var keyValuePair in dictionaryTags)
        {
            activity.AddTag(keyValuePair.Key, keyValuePair.Value);
        }
    }
}
