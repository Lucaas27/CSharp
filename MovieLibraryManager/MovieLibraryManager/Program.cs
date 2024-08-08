using MovieLibraryManager.App;
using MovieLibraryManager.DataAccess;
using MovieLibraryManager.FileStorage;
using MovieLibraryManager.Movies;
using MovieLibraryManager.Movies.Categories;
using MovieLibraryManager.UserInteraction;

const FileStorageType fileStorageType = FileStorageType.TXT;

var categoryRegister = new CategoryRegister();

IStringStorageRepository stringJsonRepository = fileStorageType == FileStorageType.JSON ?
new StringJsonRepository() :
new StringTxtRepository();

var filename = "movies";
var FileMetadata = new FileMetadata(fileStorageType, filename);

var app = new App(
    new MovieRepository(FileMetadata.FilePath(), stringJsonRepository,
    new ConsoleUserInteraction(categoryRegister),
    categoryRegister
    ),
    new ConsoleUserInteraction(categoryRegister)
);

app.Run();