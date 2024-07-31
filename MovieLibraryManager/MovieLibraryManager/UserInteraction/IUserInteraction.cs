using MovieLibraryManager.Movies;

namespace MovieLibraryManager.App;

public interface IUserInteraction
{
    UserChoice LoadMainScreen();
    void Exit();
    void ShowMessage(string v);
    Movie ReadDetailsFromUser();
    void PrintTable(object allMovies);
}