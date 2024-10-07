using CookiesCookbook.Recipes.Ingredients;

public class IngredientsRegister : IIngredientsRegister
{
    public IEnumerable<Ingredient> AllIngredients { get; } =
    [
        new Butter(),
        new Cardamom(),
        new Chocolate(),
        new Cinnamon(),
        new CocoaPowder(),
        new CoconutFlour(),
        new Sugar(),
        new WheatFlour()
    ];

    public Ingredient? GetIngredientById(int id)
    {
        var allIngredients = AllIngredients.Where(i => i.Id == id);
        if (allIngredients.Count() > 1)
        {
            throw new InvalidOperationException($"Multiple ingredients found with ID {id}");
        }

        return allIngredients.FirstOrDefault(i => i.Id == id);

    }
}

