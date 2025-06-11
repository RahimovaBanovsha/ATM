namespace InterfaceSegregation.WrongImplementation;
public interface IPlayer
{
    void PlayAudio();
    void PlayVideo();
}
class DivXMediaPlayer : IPlayer
{
    public void PlayAudio() => Console.WriteLine("DivXMediaPlayer PlayAudio");
    public void PlayVideo() => Console.WriteLine("DivXMediaPlayer PlayVideo");
}
class Winamp : IPlayer
{
    public void PlayAudio() => Console.WriteLine("Winamp PlayAudio");
    public void PlayVideo() { }

}
class DVDPlayer : IPlayer
{
    public void PlayAudio(){}
    public void PlayVideo() => Console.WriteLine("DVDPlayer PlayVideo");
}