namespace GameDataParser.UserInteraction;

public class ConsoleUserInteractor : IUserInteractor
{
    public string ReadValidPath()
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

    public void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void PrintError(string message)
    {
        var originalConsoleForegroundColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        PrintMessage(message);
        Console.ForegroundColor = originalConsoleForegroundColor;
    }
}