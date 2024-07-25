using MovieLibraryManager.App;
using MovieLibraryManager.DataAccess;
using MovieLibraryManager.Movies;
using MovieLibraryManager.Movies.Categories;
using MovieLibraryManager.UserInteraction;

var app = new App(new MovieRepository("movies.txt", new StringTxtRepository()), new ConsoleUserInteraction(new CategoryRegister()));

app.Run();