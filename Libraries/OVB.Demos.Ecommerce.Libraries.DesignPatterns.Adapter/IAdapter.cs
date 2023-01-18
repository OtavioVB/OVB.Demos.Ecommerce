namespace OVB.Demos.Ecommerce.Libraries.DesignPatterns.Adapter;

public interface IAdapter<TAdaptee, TAdapted>
    where TAdaptee : class
    where TAdapted : class
{
    public TAdapted Adapt(TAdaptee adaptee);
}
