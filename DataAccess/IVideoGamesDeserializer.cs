using GameDataParser.Model;

namespace GameDataParser.DataAccess;

public interface IVideoGamesDeserializer
{
    List<VideoGame> DeserializeFrom(string fileContents, string fileName);
}