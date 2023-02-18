using Polly;
using Polly.Retry;

namespace OVB.Demos.Ecommerce.Microsservices.Base.Infrascructure.Retry.Configuration.Base;

public abstract class RetryConfigurationBase
{
    private IList<Type> _exceptionsTypes;

    protected RetryConfigurationBase()
    {
        _exceptionsTypes = new List<Type>();
    }

    public RetryConfigurationBase AddException<TException>()
        where TException : Exception
    {
        _exceptionsTypes.Add(typeof(TException));
        return this;
    }


}
