using System.Threading.Channels;

namespace Lesson11_12.Abstraction_Task.Step3;
internal class VictorianFactory
{
    public string Name { get; set; } = "Factory";
    public string Model { get; set; }
    public VictorianFactory(string model)
    {
        Model = model;
    }
    public object CreateChair() {
        if (Model == "Victorian")
            return new VictorianChair();
        else if (Model == "Modern")
            return new ModernChair();
        else return new ArtDecoChair();
    }
    public object CreateSofa(){
        if (Model == "Victorian")
            return new VictorianSofa();
        else if (Model == "Modern")
            return new ModernSofa();
        else return new ArtDecoSofa();
    }
    public object CreateCoffeeChair() {
        if (Model == "Victorian")
            return new VictorianCoffeeChair();
        else if (Model == "Modern")
            return new ModernCoffeeChair();
        else return new ArtDecoCoffeeChair();
    }
}
class VictorianChair {}
class VictorianSofa { }
class VictorianCoffeeChair { }
class ModernChair { }
class ModernSofa { }
class ModernCoffeeChair { }
class ArtDecoChair {
    public ArtDecoChair()
    {
        Console.WriteLine("ArtDecoChair");
    }
}
class ArtDecoSofa {
    public ArtDecoSofa()
    {
        Console.WriteLine("ArtDecoSofa");
    }
}
class ArtDecoCoffeeChair {
    public ArtDecoCoffeeChair()
    {
        Console.WriteLine("ArtDecoCoffeeChair");
    }
}