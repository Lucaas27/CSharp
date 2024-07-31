using CookiesCookbook.Recipes;
using CookiesCookbook.Recipes.Ingredients;

public class RecipesConsoleUserInteraction : IRecipesUserInteraction
{

    private readonly IIngredientsRegister _ingredientsRegister;

    public RecipesConsoleUserInteraction(IIngredientsRegister ingredientsRegister)
    {
        _ingredientsRegister = ingredientsRegister;
    }
    public void Exit()
    {
        Console.WriteLine("Press any key to close...");
        Console.ReadLine();
    }

    public void PrintRecipes(IEnumerable<Recipe> allRecipes)
    {
        if (allRecipes.Count() == 0)
        {
            Console.WriteLine("No recipes found.");
        }
        else
        {
            Console.WriteLine("Existing recipes are: ");

            for (int i = 0; i < allRecipes.Count(); ++i)
            {
                Console.WriteLine("******** Recipe {0} ********", i + 1);
                Console.WriteLine(allRecipes.ElementAt(i));
                Console.WriteLine();
            }
        }
    }

    public void PromptToCreateRecipe()
    {
        Console.WriteLine("Create a new cookie recipe! Available ingredients are:");
        foreach (var ingredient in _ingredientsRegister.AllIngredients)
        {
            Console.WriteLine(ingredient);

        }
    }

    public IEnumerable<Ingredient> ReadIngredientsFromUser()
    {
        bool stopLoop = false;
        var ingredients = new List<Ingredient>();
        while (!stopLoop)
        {
            Console.WriteLine("Enter the ingredient ID you want to add, or type anything if you are finished.");
            string input = Console.ReadLine();
            int id;
            if (int.TryParse(input, out id))
            {
                var ingredient = _ingredientsRegister.GetIngredientById(id);
                if (ingredient != null)
                {
                    ingredients.Add(ingredient);
                }
            }
            else
            {
                stopLoop = true;
            }
        }
        return ingredients;

    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}

