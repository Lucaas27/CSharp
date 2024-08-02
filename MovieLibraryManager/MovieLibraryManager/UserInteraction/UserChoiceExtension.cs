
namespace MovieLibraryManager.UserInteraction;

public static class UserChoiceExtension
{
    public static void PrintChoices()
    {
        foreach (UserChoice c in Enum.GetValues(typeof(UserChoice)))
        {
            // Print the enum value and its corresponding number
            Console.WriteLine($"{(int)c}. {c}");

        }

    }
}

