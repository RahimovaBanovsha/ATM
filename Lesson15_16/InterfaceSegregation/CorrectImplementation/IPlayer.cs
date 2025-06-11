namespace InterfaceSegregation.CorrectImplementation;
interface IAudioPlayer
{
    void PlayAudio();
}
interface IVideoPlayer
{
    void PlayVideo();
}

class DivXMediaPlayer : IAudioPlayer, IVideoPlayer
{
    public void PlayAudio() => Console.WriteLine("DivXMediaPlayer PlayAudio");
    public void PlayVideo() => Console.WriteLine("DivXMediaPlayer PlayVideo");
}
class Winamp : IAudioPlayer
{
    public void PlayAudio() => Console.WriteLine("Winamp PlayAudio");
    public void PlayVideo() { }

}
class DVDPlayer : IVideoPlayer
{
    public void PlayAudio() { }
    public void PlayVideo() => Console.WriteLine("DVDPlayer PlayVideo");
}
