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
        if (allRecipes.Any())
        {
            var recipes = allRecipes
            .Select((recipe, index) => $"******** Recipe {index + 1} ********|{recipe}")
            .Select(r => r.Split('|'))
            .Select(parts => string.Join(Environment.NewLine, parts)); // Join parts of each recipe

            Console.WriteLine(string.Join(Environment.NewLine, recipes));
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("No recipes found.");
        }


    }

    public void PromptToCreateRecipe()
    {
        Console.WriteLine("Create a new cookie recipe! Available ingredients are:");
        Console.WriteLine(string.Join(Environment.NewLine, _ingredientsRegister.AllIngredients));
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

