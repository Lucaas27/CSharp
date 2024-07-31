using MovieLibraryManager.App;
using MovieLibraryManager.UserInteraction;

var app = new App(new MovieRepository(), new ConsoleUserInteraction());

app.Run();