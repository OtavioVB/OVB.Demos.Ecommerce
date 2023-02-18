namespace OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Retry.Interfaces;

public interface IRetry
{
    public Task<(bool RetryResult, TOutput? Output)> TryRetry<TOutput, TException>(Func<Task<TOutput>> handler)
        where TException : Exception;
}
