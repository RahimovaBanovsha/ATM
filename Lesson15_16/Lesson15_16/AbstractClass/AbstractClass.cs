namespace Lesson15_16.AbstractClass;
abstract class Car
{
    public abstract void Drive();
}
class BMW : Car
{
    public override void Drive()
    {
        Console.WriteLine("BMW is driving...");
        //throw new NotImplementedException();
    }
}
class Program
{
    static void Main()
    {
        Car myCar = new BMW(); //Bu olar, çünki BMW Car-dan miras alıb və Drive metodunu implement edib.
        myCar.Drive();
    }
}