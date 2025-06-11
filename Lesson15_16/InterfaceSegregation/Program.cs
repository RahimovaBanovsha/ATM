using InterfaceSegregation.CorrectImplementation;
using InterfaceSegregation.WrongImplementation;
using DivXMediaPlayer = InterfaceSegregation.CorrectImplementation.DivXMediaPlayer;
using DVDPlayer = InterfaceSegregation.CorrectImplementation.DVDPlayer;
using Winamp = InterfaceSegregation.CorrectImplementation.Winamp;
/*

Klassik Yazilis:
List<IPlayer> players = new List<IPlayer>();

*/
// Wrong Implementation:
//List<IPlayer> players = new();
//players.Add(new DVDPlayer());
//players.Add(new Winamp());
//players.Add(new DivXMediaPlayer());
//foreach (var player in players)
//{
//    player.PlayAudio();
//}
// Correct Implementation:
List<IAudioPlayer> players = new();
//players.Add(new DVDPlayer());
players.Add(new Winamp());
players.Add(new DivXMediaPlayer());
foreach (var player in players)
{
    player.PlayAudio();
}







