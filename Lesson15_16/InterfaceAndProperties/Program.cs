using InterfaceAndProperties.Base;
using InterfaceAndProperties.Derived;
using InterfaceAndProperties.Interface;
using InterfaceAndProperties.MyClass;
//Human human=new Human();
//human.Name = "Banovsha";
//human.Surname = "Rahimova";
//human.BirthDate= DateTime.Now;
//Console.WriteLine(human);
//Console.WriteLine(human.ToString());
//Employee employee=new Employee();
//employee.Position = "Cashier";
//employee.Name = "Jack";
//employee.Surname = "Daniels";
//employee.BirthDate = new DateTime();
//employee.BirthDate = DateTime.Now;
//employee.Salary = 1200;
//Console.WriteLine(employee);
var workers = new List<IWork>();
workers.Add(new Seller());
workers.Add(new Cashier());
workers.Add(new Seller());
workers.Add(new Cashier());
workers.Add(new Cashier());
workers.Add(new Manager());
foreach (var worker in workers)
{
    worker.Work();
}









