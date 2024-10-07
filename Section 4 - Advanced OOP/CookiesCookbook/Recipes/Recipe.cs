namespace CookiesCookbook.Recipes;
using CookiesCookbook.Recipes.Ingredients;

public class Recipe
{
    public IEnumerable<Ingredient> Ingredients { get; }

    public Recipe(IEnumerable<Ingredient> ingredients)
    {
        Ingredients = ingredients;
    }

    // Override the ToString method
    public override string ToString()
    {
        return string.Join(Environment.NewLine, Ingredients.Select((ingredient, index) => $"{ingredient.Name} - {ingredient.Instructions}"));
    }
}
