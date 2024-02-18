using System.Text.Json;
using GameDataParser.Model;
using GameDataParser.UserInteraction;

namespace GameDataParser.DataAccess;

public class VideoGamesDeserializer : IVideoGamesDeserializer
{
    private readonly IUserInteractor _userInteractor;

    public VideoGamesDeserializer(IUserInteractor userInteractor)
    {
        _userInteractor = userInteractor;
    }

    public List<VideoGame> DeserializeFrom(string fileContents, string fileName)
    {
        try
        {
            return JsonSerializer.Deserialize<List<VideoGame>>(fileContents);
        }
        catch (JsonException jsonException)
        {
            _userInteractor.PrintError($"JSON in {fileName} file was not in a valid format. JSON body: ");
            _userInteractor.PrintError(fileContents);
            
            throw new JsonException($"{jsonException.Message}. The file is: {fileName}", jsonException);
        }
    }
}