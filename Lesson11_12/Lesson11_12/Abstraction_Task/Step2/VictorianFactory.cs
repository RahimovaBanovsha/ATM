namespace Lesson11_12.Abstraction_Task.Step2
{
    internal class VictorianFactory
    {
        public string Name { get; set; } = "Factory";
        public VictorianChair CreateVictorianChair() => new VictorianChair();
        public VictorianSofa CreateVictorianSofa() => new VictorianSofa();
        public VictorianCoffeeChair CreateVictorianCoffeeChair() => new VictorianCoffeeChair();
        public ModernChair CreateModernChair() => new ModernChair();
        public ModernSofa CreateModernSofa() => new ModernSofa();
        public ModernCoffeeChair CreateModernCoffeeChair() => new ModernCoffeeChair();
        public ArtDecoChair CreateArtDecoChair() => new ArtDecoChair();
        public ArtDecoSofa CreateArtDecoSofa() => new ArtDecoSofa();
        public ArtDecoCoffeeChair CreateArtDecoCoffeeChair() => new ArtDecoCoffeeChair();
    }
    class VictorianChair{}
    class VictorianSofa{}
    class VictorianCoffeeChair{}
    class ModernChair { }
    class ModernSofa { }
    class ModernCoffeeChair { }
    class ArtDecoChair { }
    class ArtDecoSofa { }
    class ArtDecoCoffeeChair { }

}
