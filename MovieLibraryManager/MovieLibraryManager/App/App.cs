using MovieLibraryManager.Movies;
using MovieLibraryManager.UserInteraction;
namespace MovieLibraryManager.App;

public class App(IMovieRepository movieRepository, IUserInteraction userInteraction)
{
    private readonly IMovieRepository _movieRepository = movieRepository;
    private readonly IUserInteraction _userInteraction = userInteraction;

    public void Run()
    {
        bool exit = false;
        while (!exit)
        {
            UserChoice userInput = _userInteraction.LoadMainScreen();
            // Read movies from file
            // var allMovies = _movieRepository.Read();
            switch (userInput)
            {
                case UserChoice.ViewAllMovies:
                    ViewAllMovies();
                    break;
                case UserChoice.SearchForMovie:
                    SearchForMovie();
                    break;
                case UserChoice.AddNewMovie:
                    AddNewMovie();
                    break;
                case UserChoice.Exit:
                    exit = true;
                    break;
                default:
                    _userInteraction.ShowMessage("Invalid choice. Please try again.");
                    break;
            };
        }

    }

    private void AddNewMovie()
    {
        var allMovies = _movieRepository.Read();
        var newMovie = _userInteraction.ReadDetailsFromUser();
        allMovies.Add(newMovie);
        _movieRepository.Write(allMovies);
        _userInteraction.ShowMessage("\nMovie added successfully!");
    }

    private void SearchForMovie()
    {
        _userInteraction.ShowMessage("Search Movies was chosen");
    }

    private void ViewAllMovies()
    {
        var allMovies = _movieRepository.Read();

    }
}
