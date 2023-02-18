namespace OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Retry.Interfaces;

public interface IRetry<TException>
    where TException : Exception
{
    public Task<(bool RetryResult, TOutput? Output)> TryRetry<TOutput>(Func<Task<TOutput>> handler);
}
