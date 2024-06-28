namespace DiceRoll.UserInput;

public static class ConsoleReader
{
    public static int ReadInteger(string message)
    {
        int value;
        bool isValid;
        do
        {
            Console.Write(message);
            isValid = int.TryParse(Console.ReadLine(), out value);
            if (!isValid)
            {
                Console.WriteLine("Not a valid integer.");
            }
        } while (!isValid);

        return value;
    }
}
