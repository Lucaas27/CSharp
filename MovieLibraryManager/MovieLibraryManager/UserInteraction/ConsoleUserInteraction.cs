using MovieLibraryManager.Movies;
using MovieLibraryManager.Movies.Categories;

namespace MovieLibraryManager.UserInteraction;

public class ConsoleUserInteraction(ICategoryRegister categoryRegister) : IUserInteraction
{
    private readonly ICategoryRegister _categoryRegister = categoryRegister;

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
        bool isValid;
        IEnumerable<Category> categoryList;
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
            categoryList = ReadCategories();


            isValid = title != string.Empty
            && releaseYear != 0
            && movieRating != 0
            && director != string.Empty
            && categoryList.Any();

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

    public IEnumerable<Category> ReadCategories()
    {
        var categoryInputs = Console.ReadLine()?.Split(',').ToList() ?? [];
        List<Category> categories = [];
        foreach (var input in categoryInputs)
        {
            if (int.TryParse(input, out int id))
            {
                var selectedCategory = _categoryRegister.GetById(id);
                if (selectedCategory is not null)
                {
                    categories.Add(selectedCategory);
                }
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }

        return categories;
    }

    public void PrintMovies(IEnumerable<string> allMovies)
    {
        if (allMovies.Any())
        {
            int counter = 1;
            foreach (var movieString in allMovies)
            {
                Console.WriteLine($"*****{counter}*****");
                Console.WriteLine(movieString);
                counter++;
            }

        }
        else
        {
            Console.WriteLine("No movies found.");
        }
    }

}
