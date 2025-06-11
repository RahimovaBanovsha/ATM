using InterfaceAndProperties.Derived;
using InterfaceAndProperties.Interface;

namespace InterfaceAndProperties.MyClass;
public class Manager : Employee, IWork, IManage
{
    public bool isWorker { get; set; }
    public void EstimateBudget() => Console.WriteLine("Manager estimates budget.");
    public void Plan() => Console.WriteLine("Manager plans.");
    public void ReviewHistory() => Console.WriteLine("Manager reviews history.");
    public void Work() => Console.WriteLine("Manager works!");
}
