using Lesson15_16.AbstractClass;
using Lesson15_16.Interfaces;
using static System.Console;
namespace Lesson15_16.Models;
public class Mercedes : Interfaces.Car, ITurbo, ISport, IClassic
{
    public void Classic() => WriteLine("Mercedes Classic");

    public void Sport() => WriteLine("Mercedes Sport");

    public void Turbo() => WriteLine("Mercedes Turbo");
}
