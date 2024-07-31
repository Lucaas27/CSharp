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
        var steps = new List<string>();
        foreach (var ingredient in Ingredients)
        {
            steps.Add($"{ingredient.Name}. {ingredient.Instructions}");
        }

        return string.Join(Environment.NewLine, steps);
    }
}
