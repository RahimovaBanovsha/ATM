namespace Lesson11_12.Abstraction_Task.Step4;
abstract class Chair();
abstract class Sofa();
abstract class CoffeeChair();

class VictorianSofa : Sofa
{
    public VictorianSofa()
    {
        Console.WriteLine("VictorianSofa");
    }
}
class ArtDecoSofa : Sofa
{
    public ArtDecoSofa()
    {
        Console.WriteLine("ArtDecoSofa");
    }
}
class ModernSofa : Sofa
{
    public ModernSofa()
    {
        Console.WriteLine("ModernSofa");
    }
}
class VictorianChair : Chair
{
    public VictorianChair()
    {
        Console.WriteLine("VictorianChair");
    }
}
class ArtDecoChair : Chair
{
    public ArtDecoChair()
    {
        Console.WriteLine("ArtDecoChair");
    }
}
class ModernChair : Chair
{
    public ModernChair()
    {
        Console.WriteLine("ModernChair");
    }
}
class VictorianCoffeeChair : CoffeeChair
{
    public VictorianCoffeeChair()
    {
        Console.WriteLine("VictorianCoffeeChair");
    }
}
class ArtDecoCoffeeChair : CoffeeChair
{
    public ArtDecoCoffeeChair()
    {
        Console.WriteLine("ArtDecoCoffeeChair");
    }
}
class ModernCoffeeChair : CoffeeChair
{
    public ModernCoffeeChair()
    {
        Console.WriteLine("ModernCoffeeChair");
    }
}
abstract class Factory
{
    public abstract Chair CreateChair();
    public abstract Sofa CreateSofa();

    public abstract CoffeeChair CreateCoffeeChair();
}
//Extend elemek:
class VictorianFactory : Factory
{
    public override Chair CreateChair()=>new VictorianChair();
    public override Sofa CreateSofa()=>new VictorianSofa();
    public override CoffeeChair CreateCoffeeChair() => new VictorianCoffeeChair();   
}
class ModernFactory : Factory
{
    public override Chair CreateChair() => new ModernChair();
    public override Sofa CreateSofa() => new ModernSofa();
    public override CoffeeChair CreateCoffeeChair() => new ModernCoffeeChair();
}
class ArtDecoFactory : Factory
{
    public override Chair CreateChair() => new ArtDecoChair();
    public override Sofa CreateSofa() => new ArtDecoSofa();
    public override CoffeeChair CreateCoffeeChair() => new ArtDecoCoffeeChair();
}