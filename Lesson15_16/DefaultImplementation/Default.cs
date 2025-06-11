namespace DefaultImplementation;
public interface IDrawable
{
    void Draw();
    void DrawDetailed() => Console.WriteLine("Draw Detailed!");
}
public class Shape : IDrawable
{
    public void Draw() => Console.WriteLine("Shape Draw!");
    //public void DrawDetailed() => Console.WriteLine("Draw Overriden Detailed!");
    //void IDrawable.DrawDetailed() => Console.WriteLine("Draw Overriden Detailed!");
}