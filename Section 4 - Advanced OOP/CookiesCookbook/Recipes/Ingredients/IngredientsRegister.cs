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

    public Ingredient GetIngredientById(int id)
    {
        foreach (var ingredient in AllIngredients)
        {
            if (ingredient.Id == id)
            {
                return ingredient;

            }
        }

        return null;

    }
}

