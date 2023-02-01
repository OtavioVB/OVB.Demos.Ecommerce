namespace OVB.Demos.Ecommerce.Microsservices.Base.DesignPatterns.Adapter;

public interface IAdapter<TInput, TOutput>
    where TInput : class
    where TOutput : class
{
    public TOutput Adapter(TInput input);
}
