using OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Configuration.Interfaces;
using System.Diagnostics;

namespace OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Observability.Management.Interfaces;

public interface ITraceManager
{
    public ITracingSource TracingSource { get; }
    public Task<TOutput> StartTracing<TInput, TOutput>(string name, ActivityKind activityKind, TInput input, Func<TInput, Activity, Task<TOutput>> handler, IDictionary<string, string> dictionaryTags)
    public Task<bool> StartTracing<TInput>(string name, ActivityKind activityKind, TInput input, Func<TInput, Activity, Task<bool>> handler, IDictionary<string, string> dictionaryTags);
    public void StartTracing(string name, ActivityKind activityKind, Action<Activity> handler, IDictionary<string, string> dictionaryTags);
    public void StartTracing<TInput>(string name, ActivityKind activityKind, TInput input, Action<TInput, Activity> handler, IDictionary<string, string> dictionaryTags);
    public void SetTags(Activity activity, IDictionary<string, string> dictionaryTags);
}
