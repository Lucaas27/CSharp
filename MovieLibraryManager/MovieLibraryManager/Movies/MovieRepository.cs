using MovieLibraryManager.Movies.Categories;

namespace MovieLibraryManager.Movies;

public class MovieRepository(string filePath) : IMovieRepository
{
    private readonly string _filePath = filePath;

    public List<Movie> Read()
    {
        return
        [
            new Movie("The Shawshank Redemption", "Frank Darabont",[new Categories.Action(),new Drama()]
            ,1994, 9.3),
            new Movie("The Godfather", "Francis Ford Coppola",[new Drama(), new Categories.Action()], 1972, 9.2),
            new Movie("The Dark Knight", "Christopher Nolan", [new Categories.Action()], 2008, 9.0),
            new Movie("The Godfather: Part II", "Francis Ford Coppola",[new Drama(), new Categories.Action()], 1974, 9.0),
            new Movie("The Lord of the Rings: The Return of the King", "Peter Jackson", [new Drama(), new Categories.Action()], 2003, 8.9),
            new Movie("Pulp Fiction", "Quentin Tarantino", [new Categories.Action(), new Comedy()], 1994, 8.9),
            new Movie("Schindler's List", "Steven Spielberg", [new Drama()], 1993, 8.9),
        ];
    }

    public void Write(List<Movie> allMovies)
    {
        throw new NotImplementedException();
    }
}