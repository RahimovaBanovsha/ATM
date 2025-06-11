using System.Threading.Channels;

namespace Lesson15_16.ClassTask;
internal class Commander : Fighter, IManage
{
    public void CompleteMission() => Console.WriteLine("Commander has completed mission.");
    public void Control() => Console.WriteLine("Commander has taken control.");
    public void GatherPeople() => Console.WriteLine("Commander has gathered people.");
}
