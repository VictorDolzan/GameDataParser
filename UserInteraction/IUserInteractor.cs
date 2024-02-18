namespace GameDataParser.UserInteraction;

public interface IUserInteractor
{
    string ReadValidPath();
    void PrintMessage(string message);
    void PrintError(string message);
}