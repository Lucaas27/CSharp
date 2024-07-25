namespace MovieLibraryManager.DataAccess;


/// <summary>
/// Represents a repository for storing and retrieving strings using a text file.
/// </summary>
public class StringTxtRepository : StringStorageRepository
{
    private static readonly string Separator = Environment.NewLine;

    /// <summary>
    /// Converts a list of strings to a single string representation.
    /// </summary>
    /// <param name="strings">The list of strings to convert.</param>
    /// <returns>The string representation of the list of strings.</returns>
    protected override string ListToString(List<string> strings)
    {
        return string.Join(Separator, strings);
    }


    /// <summary>
    /// Converts a string representation to a list of strings.
    /// </summary>
    /// <param name="fileContents">The string representation to convert.</param>
    /// <returns>The list of strings.</returns>
    protected override List<string> StringsToList(string fileContents)
    {
        return [.. fileContents.Split(Separator)]; // Split the string by the separator and convert to a list.
    }

}
