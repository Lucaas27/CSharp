namespace CookiesCookbook.DataAccess;

public abstract class StringsRepository : IStringRepository
{

    public List<string> Read(string filepath)
    {
        if (File.Exists(filepath))
        {
            var fileContents = File.ReadAllText(filepath);
            return TextToStrings(fileContents);
        }

        return [];
    }

    protected abstract List<string> TextToStrings(string fileContents);

    public void Write(string filepath, List<string> strings)
    {
        var fileContents = StringsToText(strings);
        File.WriteAllText(filepath, fileContents);
    }

    protected abstract string StringsToText(List<string> strings);
}
