using System.Text.Json;

namespace MovieLibraryManager.DataAccess;


public class StringJsonRepository : StringStorageRepository
{
    protected override string ListToString(List<string> strings)
    {
        return JsonSerializer.Serialize(strings); // Serialize the list of strings to a string.
    }


    protected override List<string> StringsToList(string fileContents)
    {
        return JsonSerializer.Deserialize<List<string>>(fileContents); // Deserialize the string to a list of strings.
    }

}
