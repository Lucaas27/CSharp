using MovieLibraryManager.Movies;
using MovieLibraryManager.Movies.Categories;

namespace MovieLibraryManager.UserInteraction;

public class ConsoleUserInteraction(CategoryRegister categoryRegister) : IUserInteraction
{
    private readonly CategoryRegister _categoryRegister = categoryRegister;

    public UserChoice LoadMainScreen()
    {
        UserChoice choice;
        bool isValidChoice = false;

        Console.WriteLine("\nWelcome to the Movie Library Manager! Please select a number corresponding to an option.");
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

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public Movie ReadDetailsFromUser()
    {
        int releaseYear;
        double movieRating;
        string title;
        string director;
        List<Category> categoryList = [];

        bool isValid;
        do
        {
            Console.WriteLine("Enter the title of the movie:");
            title = Console.ReadLine()?.Trim() ?? string.Empty;

            Console.WriteLine("Enter the director of the movie:");
            director = Console.ReadLine()?.Trim() ?? string.Empty;

            Console.WriteLine("Enter the release year of the movie:");
            releaseYear = int.TryParse(Console.ReadLine(), out int year) ? year : 0;

            Console.WriteLine("Enter the rating for the movie:");
            movieRating = double.TryParse(Console.ReadLine(), out double rating) ? rating : 0;

            Console.WriteLine("Enter the numbers corresponding to the categories separated by commas:");
            PrintCategories();
            var categoryInputs = Console.ReadLine()?.Split(',').ToList() ?? [];

            // foreach (var input in categoryInputs)
            // {
            //     if (Enum.TryParse(input.Trim(), out Category category) && Enum.IsDefined(typeof(Category), category))
            //     {
            //         categoryList.Add(category);
            //     }
            // }


            isValid = title != string.Empty
            && releaseYear != 0
            && movieRating != 0
            && director != string.Empty
            && categoryList.Count > 0;

        } while (!isValid);

        return new Movie(title, director, categoryList, releaseYear, movieRating);

    }

    public void PrintCategories()
    {
        foreach (var cat in _categoryRegister.AllCategories)
        {
            Console.WriteLine(cat);

        };
    }

    public void PrintMovies(IEnumerable<Movie> allMovies)
    {
        if (allMovies.Any())
        {
            for (int index = 0; index < allMovies.Count(); ++index)
            {
                Console.WriteLine($"*****{index + 1}*****");
                Console.WriteLine(allMovies.ElementAt(index));
            }

        }
        else
        {
            Console.WriteLine("No movies found.");
        }
    }

}
