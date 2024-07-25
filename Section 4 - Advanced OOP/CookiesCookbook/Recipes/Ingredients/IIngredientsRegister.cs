using CookiesCookbook.Recipes.Ingredients;

public interface IIngredientsRegister
{
    IEnumerable<Ingredient> AllIngredients { get; }

    Ingredient GetIngredientById(int id);
}

