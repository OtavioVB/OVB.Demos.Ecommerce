namespace OVB.Demos.Ecommerce.Libraries.DesignPatterns.Builder;

public interface IBuilder<TBuiltEntity, TTyped>
{
    public TBuiltEntity BuildEntityByType(TTyped type);
}
