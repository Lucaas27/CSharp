using StarWarsStats.Enums;
using StarWarsStats.Extensions;

namespace StarWarsStats.UserInteraction
{
    public class ConsoleInteraction : IUserInteraction
    {

        public void PrintMessage(string message, ConsoleMessageType messageType = ConsoleMessageType.Info)
        {
            Console.ForegroundColor = messageType switch
            {
                ConsoleMessageType.Error => ConsoleColor.Red,
                ConsoleMessageType.Info => ConsoleColor.Green,
                ConsoleMessageType.Success => ConsoleColor.Cyan,
                _ => ConsoleColor.White
            };

            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void PrintErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public string? ReadInput()
        {
            var input = Console.ReadLine();
            return input;
        }

        public void PrintMenuOptions()
        {
            var menuOptionValues = Enum.GetValues<MenuOptions>();

            var menuOptionDescription = menuOptionValues
                                            .Select(option => option.GetDescription())
                                            .Where(option => option != "exit")
                                            .Where(option => option != "restart");

            var menuString = string.Join(Environment.NewLine, menuOptionDescription);

            var menu = @$"
The statistics of which property would you like to see?
{menuString}";

            PrintMessage(menu);
        }

        public void PrintTable<T>(IEnumerable<T> data)
        {
            ConsoleTable.Print(data);
        }

        public void Exit()
        {
            PrintMessage("Press any key to exit...");
            Console.ReadKey();
        }
    }
}