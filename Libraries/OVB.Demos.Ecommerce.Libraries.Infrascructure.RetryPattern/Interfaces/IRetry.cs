namespace OVB.Demos.Ecommerce.Libraries.Infrascructure.RetryPattern.Interfaces;

public interface IRetry
{
    public TOutput TryRetry<TOutput, TException>(Func<TOutput> handler)
        where TException : Exception;

    public TOutput TryRetry<TOutput, TException, TExceptionTwo>(Func<TOutput> handler)
        where TException : Exception
        where TExceptionTwo : Exception;
}
