using Lesson15_16.AbstractClass;
using Lesson15_16.Interfaces;

namespace Lesson15_16.Models;
public class Lada : Interfaces.Car, IClassic
{
    public void Classic() => Console.WriteLine("Lada Classic");
}
