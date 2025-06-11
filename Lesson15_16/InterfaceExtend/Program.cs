public interface IFoo
{
    void Foo();
}
public interface IBoo:IFoo
{
    // TODO: yeni method elave edecem
    void Boo();
}
public class Some : IBoo
{
    public void Boo() => Console.WriteLine("Some Boo");
    public void Foo() => Console.WriteLine("Some Foo");
}
