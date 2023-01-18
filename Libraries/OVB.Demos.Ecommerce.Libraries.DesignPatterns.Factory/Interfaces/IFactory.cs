namespace OVB.Demos.Ecommerce.Libraries.DesignPatterns.Factory.Interfaces;

public interface IFactory<TAdaptee, TAdapted>
{
    public TAdapted FactoryAdapt(TAdaptee adaptee);
}
