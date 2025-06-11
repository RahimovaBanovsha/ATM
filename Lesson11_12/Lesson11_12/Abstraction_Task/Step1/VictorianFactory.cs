namespace Lesson11_12.Abstraction_Task.Step1;
internal class VictorianFactory
{
    public string Name { get; set; } = "Factory";
    public VictorianChair CreateVictorianChair() => new VictorianChair();
    public VictorianSofa CreateVictorianSofa() => new VictorianSofa();
    public VictorianCoffeeChair CreateVictorianCoffeeChair() => new VictorianCoffeeChair();
}
class VictorianChair
{
    public double Width { get; set; }
    public double Height { get; set; }
    public double length { get; set; }
    public ConsoleColor? Color { get; set; }
    //Default Constructor:
    public VictorianChair()
    {
        Console.WriteLine("VictorianChair");
    }

}
class VictorianSofa
{
    public double Width { get; set; }
    public double Height { get; set; }
    public double length { get; set; }
    public ConsoleColor? Color { get; set; }
    public bool IsCorner { get; set; }
    //Default Constructor:
    public VictorianSofa()
    {
        Console.WriteLine("VictorianSofa");
    }
}
class VictorianCoffeeChair
{
    //Default Constructor:
    public VictorianCoffeeChair() 
    {
        Console.WriteLine("VictorianCoffeeChair");
    } 
}
