string choice;

bool isMatch(string choice, string letter)
{
    bool isMatch = choice.Equals(letter, StringComparison.OrdinalIgnoreCase);
    return isMatch;
}

do
{
    Console.WriteLine("\nHello!");
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[A]dd numbers");
    Console.WriteLine("[S]ubtract numbers");
    Console.WriteLine("[M]ultiply numbers");
    choice = Console.ReadLine();
}
while (!isMatch(choice, "a") && !isMatch(choice, "s") && !isMatch(choice, "m"));

int CaptureNumber()
{

    string choice = Console.ReadLine();
    bool parsedChoice = int.TryParse(choice, out int parsedFirstNumber);

    while (!parsedChoice)
    {
        Console.WriteLine("Not a number!! Please try to enter a number again");
        choice = Console.ReadLine();
        parsedChoice = int.TryParse(choice, out parsedFirstNumber);

    };

    return parsedFirstNumber;
}


void Calculate(string operation)
{
    Console.WriteLine("Input your first number");
    int firstUserInput = CaptureNumber();

    Console.WriteLine("Input your second number");
    int secondUserInput = CaptureNumber();

    int result = operation == "+" ? firstUserInput + secondUserInput : operation == "-" ? firstUserInput - secondUserInput : firstUserInput * secondUserInput;
    Console.WriteLine($"Result: {firstUserInput} {operation} {secondUserInput} = {result} ");
    Console.WriteLine("Press any key to close");
    Console.ReadKey();
}

switch (choice.ToLower())
{
    case "a":
        Calculate("+");
        break;
    case "s":
        Calculate("-");
        break;
    case "m":
        Calculate("*");
        break;
    default:
        Console.WriteLine("Invalid choice");
        break;
}



