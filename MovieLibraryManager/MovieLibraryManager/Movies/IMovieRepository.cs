namespace MovieLibraryManager.Movies;

public interface IMovieRepository
{
    List<Movie> Read();
    void PrintMovies();
    void Write(List<Movie> allMovies);
}