namespace MovieLibraryManager.Movies;

public interface IMovieRepository
{
    List<Movie> Read();
    void Write(List<Movie> allMovies);
}