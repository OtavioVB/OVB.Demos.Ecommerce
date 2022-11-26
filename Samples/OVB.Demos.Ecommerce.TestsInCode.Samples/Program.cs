namespace OVB.Demos.Ecommerce.TestsInCode.Samples;

internal class Program
{
    static void Main(string[] args)
    {
        Customer customer = new Customer("nome");
        CustomerVIP customerStandard = (CustomerVIP)customer;
        Console.WriteLine(customerStandard.Surname);
    }

    public class Customer
    {
        public string Name { get; set; }

        public Customer(string name) 
        { 
            Name = name;
        }
    }

    public class CustomerVIP : Customer
    {
        public CustomerVIP(string name, string surname) : base(name)
        {
            Surname = surname;
        }

        public string Surname { get; set; }


    }
}