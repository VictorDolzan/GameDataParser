using System.Text.Json;
using GameDataParser;

var app = new GameDataParse();
var logger = new Logger("log.txt");

try
{
    app.Run();
}
catch (Exception e)
{
    Console.WriteLine(
        $"Sorry the application has experienced and unexpected error and it's gonna have to be shut down.");
    logger.Log(e);
    throw;
}

Console.WriteLine("Press any key to shut down the process.");
Console.ReadKey();

public class GameDataParse
{
    public void Run()
    {
        var fileName = ReadValidPathFromUser();
        var fileContents = File.ReadAllText(fileName);
        var videoGames = DeserializeVideoGameFrom(fileContents, fileName);
        PrintGames(videoGames);
    }

    private static void PrintGames(List<VideoGame> videoGames)
    {
        if (videoGames.Count > 0)
        {
            Console.WriteLine();
            Console.WriteLine("Loaded games are: ");
            foreach (var videoGame in videoGames)
            {
                Console.WriteLine(videoGame);
            }
        }
        else
        {
            Console.WriteLine("No games are present in the input file.");
        }
    }

    private static List<VideoGame> DeserializeVideoGameFrom(string fileContents, string fileName)
    {
        try
        {
            return JsonSerializer.Deserialize<List<VideoGame>>(fileContents);
        }
        catch (JsonException jsonException)
        {
            var originalConsoleForegroundColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"JSON in {fileName} file was not in a valid format. JSON body: ");
            Console.WriteLine(fileContents);

            Console.ForegroundColor = originalConsoleForegroundColor;

            throw new JsonException($"{jsonException.Message}. The file is: {fileName}", jsonException);
        }
    }

    public static string ReadValidPathFromUser()
    {
        bool isFilePathValid = false;
        var fileName = default(string);

        do
        {
            Console.WriteLine("Enter the name of the file you want to read: ");
            fileName = Console.ReadLine();

            if (fileName is null)
            {
                Console.WriteLine($"The file name can't be null.");
            }
            else if (fileName == string.Empty)
            {
                Console.WriteLine($"The file cannot be empty.");
            }
            else if (!File.Exists(fileName))
            {
                Console.WriteLine($"The file does not exist.");
            }
            else
            {
                isFilePathValid = true;
            }
        } while (!isFilePathValid);

        return fileName;
    }
}

public class VideoGame
{
    public string Title { get; init; }
    public int ReleaseYear { get; init; }
    public decimal Rating { get; init; }

    public override string ToString() => @$"{Title}, released in {ReleaseYear}, Rating: {Rating}";
}