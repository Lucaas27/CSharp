namespace MovieLibraryManager.Movies;

public interface IMovieRepository
{
    List<Movie> Read();
    void Write(IEnumerable<Movie> allMovies);
}