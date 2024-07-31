using CookiesCookbook.Recipes;
using CookiesCookbook.Recipes.Ingredients;

public interface IRecipesUserInteraction
{
    void ShowMessage(string message);
    void Exit();
    void PrintRecipes(IEnumerable<Recipe> allRecipes);
    void PromptToCreateRecipe();
    IEnumerable<Ingredient> ReadIngredientsFromUser();
}

