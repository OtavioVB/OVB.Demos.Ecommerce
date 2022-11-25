using Microsoft.Extensions.DependencyInjection;

namespace OVB.Demos.Ecommerce.TestsInCode.Samples;

internal class Program
{
    static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddTransient<ITeste, Teste>();
        IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
        serviceProvider.GetService<ITeste>();
    }

    public interface ITeste
    {
        public void Escrever(string teste);
    }

    public class Teste : ITeste
    {
        public void Escrever(string teste)
        {
            Console.WriteLine(teste);
        }
    }
}