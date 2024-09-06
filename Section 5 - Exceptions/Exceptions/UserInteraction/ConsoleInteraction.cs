namespace Exceptions.UserInteraction
{
    public class ConsoleInteraction : IUserInteraction
    {

        public void PrintMessage(object message)
        {
            Console.WriteLine(message);
        }

        public void PrintErrorMessage(object message)
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

        public bool IsInputValid(string? fileToRead)
        {
            switch (fileToRead)
            {
                case null:
                    PrintMessage("File name cannot be null.");
                    return false;
                case "":
                    PrintMessage("File name cannot be empty.");
                    return false;
                default:
                    return true;
            }
        }

        public void Exit()
        {
            PrintMessage("Press any key to exit.");
            Console.ReadKey();
        }
    }
}