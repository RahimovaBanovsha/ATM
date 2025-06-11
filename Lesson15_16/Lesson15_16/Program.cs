using Lesson15_16.Interfaces;
using Lesson15_16.Models;

//Mercedes mercedes=new Mercedes();
//mercedes.Sport();
////////////////////////////////////
//var mercedes=new Mercedes();
//mercedes.Turbo();
////////////////////////////////////
//ITurbo mercedes = new Mercedes();
//mercedes.Turbo();
//(mercedes as IClassic)!.Classic();
///////////////////////////////////
//ITurbo mercedes = new Mercedes();
//mercedes.Turbo();
//(mercedes as IClassic)?.Classic();

//List <ITurbo> ClassicCars=new List<ITurbo>()
//{
//    new Mercedes(),
//    new Lada()
//};

List<IClassic> ClassicCars = new List<IClassic>();
ClassicCars.Add(new Mercedes());
ClassicCars.Add(new Lada());

foreach (var item in ClassicCars)
{
    item.Classic();
}








