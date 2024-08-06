using MovieLibraryManager.Movies;
using MovieLibraryManager.Movies.Categories;

namespace MovieLibraryManager.UserInteraction;

public interface IUserInteraction
{
    UserChoice LoadMainScreen();
    Movie ReadDetailsFromUser();
    void PrintMovies(IEnumerable<string> allMovies);
    void PrintCategories();
    void ShowMessage(string v);
}