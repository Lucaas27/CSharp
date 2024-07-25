namespace CookiesCookbook.Recipes.Ingredients;
public abstract class Spice : Ingredient
{
    public override string Instructions => $"Take half a teaspoon. {base.Instructions}";
}

