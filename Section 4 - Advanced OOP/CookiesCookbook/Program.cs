
using System.Runtime.InteropServices;

var cookiesCookbookApp = new CookiesCookbookApp();
cookiesCookbookApp.Run();

public class CookiesCookbookApp
{
    private readonly RecipesRepository _recipesRepository;
    private readonly RecipesUserInteraction _recipesUserInteraction;
    public CookiesCookbookApp(RecipesRepository recipesRepository, RecipesUserInteraction recipesUserInteraction)
    {
        _recipesRepository = recipesRepository;
        _recipesUserInteraction = recipesUserInteraction;
    }

    public void Run()
    {
        var allRecipes = _recipesRepository.Read(filepath);
        _recipesUserInteraction.PrintRecipes(allRecipes);

        _recipesUserInteraction.PromptToCreateRecipe();

        var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

        if (ingredients.Count > 0)
        {
            var recipe = new Recipe(ingredients);

            allRecipes.Add(recipe);
            _recipesRepository.Write(filepath, allRecipes);
            _recipesUserInteraction.ShowMessage($"Recipe added: {recipe}");
        }
        else
        {
            _recipesUserInteraction.ShowMessage("No ingredients have been selected. Recipe will not be saved.");
        }
    }
}

