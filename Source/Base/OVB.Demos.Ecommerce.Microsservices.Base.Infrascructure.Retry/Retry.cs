namespace OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Retry;

public sealed class Retry
{
    public async Task<(bool RetryResult, TOutput Output)> Retry<TOutput>(Func<Task<TOutput>> handler, bool catchingErrorResult)
        where TOutput : class
    {
        if (catchingErrorResult == false)
        {
            int retriesCount = 0;


        }
        else
        {
            return (true, await handler());
        }
    }
}
