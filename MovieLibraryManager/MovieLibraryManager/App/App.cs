using MovieLibraryManager.Movies;
namespace MovieLibraryManager.App;

public class App(IMovieRepository movieRepository, IUserInteraction userInteraction)
{
    private readonly IMovieRepository _movieRepository = movieRepository;
    private readonly IUserInteraction _userInteraction = userInteraction;

    public void Run()
    {
        // Read movies from file
        var allMovies = _movieRepository.Read(filepath);
        UserChoice userInput = _userInteraction.LoadMainScreen();
        switch (userInput)
        {
            case UserChoice.ViewAllMovies:
                // Display movies
                _userInteraction.PrintTable(allMovies);
                break;
            case UserChoice.SearchForMovie:
                Console.WriteLine("Search Movies was chosen");
                break;
            case UserChoice.AddNewMovie:
                // Read new movie details
                Movie newMovie = _userInteraction.ReadDetailsFromUser();
                // Add new movie to the pre-existent list
                allMovies.Add(newMovie);
                // Write to the file to add new movie
                _movieRepository.Write(filepath, allMovies);
                _userInteraction.ShowMessage("Movie added successfully!");
                break;
            default:
                _userInteraction.Exit();
                break;
        };

    }
}
