using Microsoft.Extensions.DependencyInjection;

namespace OVB.Demos.Ecommerce.TestsInCode.Samples;

internal class Program
{
    static void Main(string[] args)
    {
        new OverrideWrite().Escrever();
    }

    public abstract class BaseWrite
    {
        public virtual void Escrever()
        {
            Console.WriteLine("1");
        }
    }

    public class Write : BaseWrite
    {
        public new virtual void Escrever()
        {
            base.Escrever();
            Console.WriteLine("2");
        }
    }

    public class OverrideWrite : Write
    {
        public override void Escrever()
        {
            base.Escrever();
            Console.WriteLine("3");
        }
    }
}