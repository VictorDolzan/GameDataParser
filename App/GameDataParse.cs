using GameDataParser.DataAccess;
using GameDataParser.UserInteraction;

namespace GameDataParser.App;

public class GameDataParse
{
    private readonly IUserInteractor _userInteractor;
    private readonly IGamesPrinter _gamesPrinter;
    private readonly IVideoGamesDeserializer _videoGamesDeserializer;
    private readonly IFileReader _fileReader;

    public GameDataParse(IUserInteractor userInteractor, IGamesPrinter gamesPrinter, 
        IVideoGamesDeserializer videoGamesDeserializer, IFileReader fileReader)
    {
        _userInteractor = userInteractor;
        _gamesPrinter = gamesPrinter;
        _videoGamesDeserializer = videoGamesDeserializer;
        _fileReader = fileReader;
    }
    public void Run()
    {
        var fileName = _userInteractor.ReadValidPath();
        var fileContents = _fileReader.Read(fileName);
        var videoGames = _videoGamesDeserializer.DeserializeFrom(fileContents, fileName);
        _gamesPrinter.Print(videoGames);
    }
}