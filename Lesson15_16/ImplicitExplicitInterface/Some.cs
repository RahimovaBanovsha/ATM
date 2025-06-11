namespace ImplicitExplicitInterface;

public interface IA
{
    void Get();
}
public interface IB
{
    void Get();
}

public class Some : IA, IB
{
    void IA.Get() => Console.WriteLine("IA Get");
    void IB.Get() => Console.WriteLine("IB Get");
    public void Get() => Console.WriteLine("Some Get");
}