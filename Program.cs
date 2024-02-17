using System.Text.Json;

bool isFileReadable = false;
var fileContents = default(string);
do
{
    try
    {
        Console.WriteLine("Enter the name of the file you want to read: ");
        var fileName = Console.ReadLine();

        fileContents = File.ReadAllText(fileName);
        isFileReadable = true;
    }
    catch (ArgumentNullException argument)
    {
        Console.WriteLine($"The file name can't be null.");
    }
    catch (ArgumentException argException)
    {
        Console.WriteLine($"{argException.Message}");
    }
    catch (FileNotFoundException fileNotFoundException)
    {
        Console.WriteLine($"{fileNotFoundException.Message}");
    }
    
} while (!isFileReadable);

var videoGames = JsonSerializer.Deserialize<List<VideoGame>>(fileContents);

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

Console.WriteLine("Press any key to shut down the process.");
Console.ReadKey();


public class VideoGame
{
    public string Title { get; init; }
    public int ReleaseYear { get; init; }
    public decimal Rating { get; init; }

    public override string ToString() => @$"{Title}, released in {ReleaseYear}, Rating: {Rating}";
}