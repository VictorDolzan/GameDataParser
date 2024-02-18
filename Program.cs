using GameDataParser.App;
using GameDataParser.DataAccess;
using GameDataParser.Logging;
using GameDataParser.UserInteraction;

var userIteraction = new ConsoleUserInteractor();
var app = new GameDataParse(
    userIteraction,
    new GamesPrinter(userIteraction),
    new VideoGamesDeserializer(userIteraction),
    new LocalFileReader());

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
}

Console.WriteLine("Press any key to shut down the process.");
Console.ReadKey();