using InterfaceAndProperties.Derived;
using InterfaceAndProperties.Interface;

namespace InterfaceAndProperties.MyClass;
public class Cashier : Employee, IWork
{
    public bool isWorker { get; set; }
    public void Work() => Console.WriteLine("Cashier Works!");
}
