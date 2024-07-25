namespace CookiesCookbook.Recipes.Ingredients;

public abstract class Flour : Ingredient
{
    public override string Instructions => $"Sieve. {base.Instructions}";
}
