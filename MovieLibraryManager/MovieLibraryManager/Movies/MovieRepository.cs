using MovieLibraryManager.DataAccess;
using MovieLibraryManager.Movies.Categories;
using MovieLibraryManager.UserInteraction;

namespace MovieLibraryManager.Movies;

public class MovieRepository(string filePath, IStringStorageRepository stringStorageRepository, IUserInteraction userInteraction, ICategoryRegister categoryRegister) : IMovieRepository
{
    private readonly string _filePath = filePath;
    private readonly IStringStorageRepository _stringStorageRepository = stringStorageRepository;
    private readonly IUserInteraction _userInteraction = userInteraction;
    private readonly ICategoryRegister _categoryRegister = categoryRegister;

    public void PrintMovies()
    {
        List<string> moviesFromFile = _stringStorageRepository.Read(_filePath);
        if (moviesFromFile.Count > 0)
        {
            int counter = 1;
            foreach (var movieString in moviesFromFile)
            {
                _userInteraction.ShowMessage($"*****{counter}*****");
                _userInteraction.ShowMessage(movieString);
                counter++;
            }

        }
        else
        {
            _userInteraction.ShowMessage("No movies found.");
        }

    }

    public List<Movie> Read()
    {
        List<string> moviesFromFile = _stringStorageRepository.Read(_filePath);
        List<Movie> allMovies = new List<Movie>();
        foreach (var movieString in moviesFromFile)
        {
            allMovies.Add(MovieFromString(movieString));
        }

        return allMovies;

    }

    public Movie MovieFromString(string movieString)
    {
        var movieParts = movieString.Split(';');
        var id = movieParts[0].Split(":")[1].Trim();
        var title = movieParts[1].Split(":")[1].Trim();
        var director = movieParts[2].Split(":")[1].Trim();
        var categoryIds = movieParts[3].Split(":")[1].Trim()
        .Split('-')
                                        .Select(category => category
                                        .Split('.')[0].Trim())
                                        .Select(int.Parse).ToList();
        var categories = categoryIds.Select(_categoryRegister.GetById).ToList();
        var year = int.Parse(movieParts[4].Split(':')[1].Trim());
        var rating = double.Parse(movieParts[5].Split(':')[1].Trim());

        return new Movie(title, director, categories, year, rating);
    }


    public void Write(List<Movie> allMovies)
    {
        var allMoviesAsStrings = new List<string>();
        foreach (var movie in allMovies)
        {
            allMoviesAsStrings.Add(movie.ToString());
        }

        _stringStorageRepository.Write(_filePath, allMoviesAsStrings);
    }

}

