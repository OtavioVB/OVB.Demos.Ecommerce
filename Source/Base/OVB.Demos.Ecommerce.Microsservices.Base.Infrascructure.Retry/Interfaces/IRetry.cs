namespace OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Retry.Interfaces;

public interface IRetry
{
    public Task<TOutput?> TryRetry<TOutput, TException>(Func<Task<TOutput>> handler)
        where TException : Exception;
}
