namespace GameDataParser;

public class Logger
{
    private readonly string _logFileName;

    public Logger(string logFileName)
    {
        _logFileName = logFileName;
    }

    public void Log(Exception exception)
    {
        var entry =
            $@"[{DateTime.Now}]
Exception message: {exception.Message}
Stack trace: {exception.StackTrace}

";
        File.AppendAllText(_logFileName, entry);
    }
}