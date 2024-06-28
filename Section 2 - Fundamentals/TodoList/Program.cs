string userChoice;
var todos = new List<string>();

void Intro()
{
    Console.WriteLine("\nHello!");
    Console.WriteLine("\nWhat do you need to do?");
    Console.WriteLine("[S]ee all TODOS");
    Console.WriteLine("[A]dd a new TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");

    userChoice = Console.ReadLine();
}

bool IsInputValid(string userInput)
{
    if (userInput.Length == 0)
    {
        Console.WriteLine("TODO cannot be empty. Please try again.");
        return false;
    }
    else if (todos.Contains(userInput))
    {
        Console.WriteLine("TODO already exists. Please try again.");
        return false;
    }

    return true;
}

void CheckTODOsCount()
{
    if (todos.Count == 0)
    {
        Console.WriteLine("No TODOs in the list. Add one with [A]");
        return;
    }
}

void SeeTodos()
{
    CheckTODOsCount();
    for (int i = 0; i < todos.Count; ++i)
    {
        Console.WriteLine("{0}.{1} ", i + 1, todos[i]);
    }
}


void AddTodos()
{
    string userInput;
    do
    {
        Console.WriteLine("Enter a new TODO");
        userInput = Console.ReadLine();

    } while (!IsInputValid(userInput));

    todos.Add(userInput);
    Console.WriteLine("Added TODO: {0}", userInput);

}

void RemoveTodos()
{

    bool isInvalid = true;
    do
    {
        Console.WriteLine("\nSelect the index of the TODO to remove");
        SeeTodos();

        string userInput = Console.ReadLine();
        bool isParsingSuccessful = int.TryParse(userInput, out int result);

        if (userInput.Length == 0)
        {
            Console.WriteLine("Selected index cannot be empty. Please try again.");
            continue;
        }

        if (isParsingSuccessful)
        {
            if (result <= todos.Count && result > 0)
            {
                int i = result - 1;
                Console.WriteLine("Removed TODO: {0}", todos[i]);
                todos.RemoveAt(i);
                isInvalid = false;
            }
            else
            {
                Console.WriteLine("Invalid index. Please try again.");
            }
        }
    } while (isInvalid);

}



do
{
    Intro();
    switch (userChoice.ToLower())
    {
        case "s":
            SeeTodos();
            break;
        case "a":
            AddTodos();
            break;
        case "r":
            RemoveTodos();
            break;
        case "e":
            break;
        default:
            Console.WriteLine("Invalid option. Please try again.\n");
            break;
    }

} while (!userChoice.Equals("E", StringComparison.OrdinalIgnoreCase));

