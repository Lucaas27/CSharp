using MovieLibraryManager.DataAccess;
using MovieLibraryManager.Movies.Categories;

namespace MovieLibraryManager.Movies;

public class MovieRepository(string filePath, IStringStorageRepository stringStorageRepository) : IMovieRepository
{
    private readonly string _filePath = filePath;
    private readonly IStringStorageRepository _stringStorageRepository = stringStorageRepository;


    public List<Movie> Read()
    {
        List<string> moviesFromFile = _stringStorageRepository.Read(_filePath);
        List<Movie> allMovies = [];
        if (moviesFromFile.Count > 0)
        {
            int counter = 1;
            foreach (var movieString in moviesFromFile)
            {
                Console.WriteLine($"*****{counter}*****");

                // string[] movieProperties = movieString.Split(","); // Split the string by the comma to get the movie properties.
                // string title = movieProperties[0];
                // string director = movieProperties[1];
                // List<Category> categories = new List<Category>();
                // foreach (var categoryId in movieProperties[2].Split(";")) // Split the string by the semicolon to get the category IDs.
                // {
                //     int id = int.Parse(categoryId);
                //     categories.Add(_categoryRegister.GetById(id)); // Get the category object by its ID and add it to the list of categories.
                // }
                // int releaseYear = int.Parse(movieProperties[3]);
                // double movieRating = double.Parse(movieProperties[4]);
                // allMovies.Add(new Movie(title, director, categories, releaseYear, movieRating)); // Create a new movie object and add it to the list of movies.
                Console.WriteLine(movieString);
            }

        }

        return allMovies;
    }
    // return
    // [
    //     new Movie("The Shawshank Redemption", "Frank Darabont",[new Categories.Action(),new Drama()]
    //     ,1994, 9.3),
    //     new Movie("The Godfather", "Francis Ford Coppola",[new Drama(), new Categories.Action()], 1972, 9.2),
    //     new Movie("The Dark Knight", "Christopher Nolan", [new Categories.Action()], 2008, 9.0),
    //     new Movie("The Godfather: Part II", "Francis Ford Coppola",[new Drama(), new Categories.Action()], 1974, 9.0),
    //     new Movie("The Lord of the Rings: The Return of the King", "Peter Jackson", [new Drama(), new Categories.Action()], 2003, 8.9),
    //     new Movie("Pulp Fiction", "Quentin Tarantino", [new Categories.Action(), new Comedy()], 1994, 8.9),
    //     new Movie("Schindler's List", "Steven Spielberg", [new Drama()], 1993, 8.9),
    // ];

    public void Write(IEnumerable<Movie> allMovies)
    {
        _stringStorageRepository.Write(_filePath, allMovies.Select(m => m.ToString()).ToList()); // Convert each movie to a string and write it to the file.
    }

}

