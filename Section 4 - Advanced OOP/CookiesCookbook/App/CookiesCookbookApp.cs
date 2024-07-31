using CookiesCookbook.Recipes;

public class CookiesCookbookApp
{
    private readonly IRecipesRepository _recipesRepository;
    private readonly IRecipesUserInteraction _recipesUserInteraction;

    public CookiesCookbookApp(IRecipesRepository recipesRepository, IRecipesUserInteraction recipesUserInteraction)
    {
        _recipesRepository = recipesRepository;
        _recipesUserInteraction = recipesUserInteraction;
    }

    public void Run(string filepath)
    {
        var allRecipes = _recipesRepository.Read(filepath);
        _recipesUserInteraction.PrintRecipes(allRecipes);

        _recipesUserInteraction.PromptToCreateRecipe();

        var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

        if (ingredients.Count() > 0)
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

        _recipesUserInteraction.Exit();
    }
}
