namespace Exceptions.UserInteraction
{
    public interface IUserInteraction
    {
        string? ReadInput();
        void PrintMessage(object message);
        void PrintErrorMessage(object message);
        bool IsInputValid(string? fileToRead);
        void Exit();
    }
}