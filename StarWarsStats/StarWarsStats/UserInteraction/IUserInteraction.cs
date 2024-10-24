using StarWarsStats.Enums;

namespace StarWarsStats.UserInteraction
{
    public interface IUserInteraction
    {
        string? ReadInput();
        void PrintMessage(string message, ConsoleMessageType messageType = ConsoleMessageType.Info);
        void PrintErrorMessage(string message);
        void PrintMenuOptions();
        void PrintTable<T>(IEnumerable<T> data);
        void Exit();
    }
}