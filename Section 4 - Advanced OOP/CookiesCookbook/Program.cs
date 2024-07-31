
using CookiesCookbook.DataAccess;
using CookiesCookbook.FileAccess;

const FileFormat Format = FileFormat.Json;

IStringRepository stringsRepository = Format == FileFormat.Json ? 
    new StringJsonRepository() : 
    new StringTextualRepository();

var ingredientsRegister = new IngredientsRegister();

var cookiesCookbookApp = new CookiesCookbookApp(
    new RecipesRepository(stringsRepository, ingredientsRegister),
    new RecipesConsoleUserInteraction(ingredientsRegister)
);

var fileMetada = new FileMetadata("recipes", Format);

cookiesCookbookApp.Run(fileMetada.ToPath());