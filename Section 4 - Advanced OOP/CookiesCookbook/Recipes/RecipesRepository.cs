
using CookiesCookbook.DataAccess;
using CookiesCookbook.Recipes;
using CookiesCookbook.Recipes.Ingredients;

public class RecipesRepository : IRecipesRepository
{
    private readonly IStringRepository _stringRepository;
    private readonly IIngredientsRegister _ingredientsRegister;
    private const string Separator = ",";

    public RecipesRepository(IStringRepository stringRepository, IIngredientsRegister ingredientsRegister)
    {
        _stringRepository = stringRepository;
        _ingredientsRegister = ingredientsRegister;
    }
    public List<Recipe> Read(string filepath)
    {

        return _stringRepository.Read(filepath)
        .Select(RecipeFromString)
        .ToList();
    }

    private Recipe RecipeFromString(string recipeFromFile)
    {
        var ingredients = recipeFromFile.Split(Separator)
            .Select(int.Parse)
            .Select(_ingredientsRegister.GetIngredientById);

        return new Recipe(ingredients.Where(ingredient => ingredient != null)!);
    }

    public void Write(string filepath, List<Recipe> allRecipes)
    {
        var recipesAsStrings = allRecipes
            .Select(recipe =>
                string.Join(Separator, recipe.Ingredients.Select(ingredient => ingredient.Id))
            ).ToList();

        _stringRepository.Write(filepath, recipesAsStrings);
    }
}

