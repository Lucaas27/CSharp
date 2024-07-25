namespace CookiesCookbook.Recipes.Ingredients;
public abstract class Ingredient
{
    public abstract int Id { get; }
    public abstract string Name { get; }
    public virtual string Instructions => "Add to other ingredients."; // This is the default instruction for all ingredients. You can override it in derived classes.

    public override string ToString()
    {
        return $"{Id} - {Name}";
    }
}
