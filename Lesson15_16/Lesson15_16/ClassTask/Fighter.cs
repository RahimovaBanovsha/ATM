namespace Lesson15_16.ClassTask;
internal class Fighter : IFighter, IKiller
{
    public void Attack() => Console.WriteLine("Fighter has attacked.");

    public void Fire() => Console.WriteLine("Fighter has fired.");

    public void Kill() => Console.WriteLine("Fighter has killed.");

    public void Shot() => Console.WriteLine("Fighter has shot.");
}
