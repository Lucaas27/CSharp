using MovieLibraryManager.App;
using MovieLibraryManager.Movies;

namespace MovieLibraryManager.UserInteraction;

public class ConsoleUserInteraction : IUserInteraction
{
    public UserChoice LoadMainScreen()
    {
        UserChoice choice;
        bool isValidChoice = false;

        Console.WriteLine("Welcome to the Movie Library Manager! Please select a number corresponding to an option.");
        UserChoiceExtension.PrintChoices();
        do
        {
            var userInput = Console.ReadLine();
            // Parse the user input to the enum and check if it is a valid choice
            if (Enum.TryParse(userInput, out choice) && Enum.IsDefined(typeof(UserChoice), choice))
            {
                isValidChoice = true;
            }
            else
            {
                Console.WriteLine("\nInvalid input. Please enter a valid number:");
            }

        } while (!isValidChoice);


        return choice;
    }


    public void Exit()
    {
        Console.WriteLine("Press any key to close...");
        Console.ReadLine();
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public Movie ReadDetailsFromUser()
    {
        throw new NotImplementedException();
    }

    public void PrintTable(object allMovies)
    {
        throw new NotImplementedException();
    }
}
