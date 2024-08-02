namespace MovieLibraryManager.DataAccess;

public abstract class StringStorageRepository : IStringStorageRepository
{
    public List<string> Read(string filepath)
    {
        if (File.Exists(filepath))
        {
            string fileContents = File.ReadAllText(filepath);
            return StringsToList(fileContents);
        }
        else
        {
            return [];
        }
    }

    public void Write(string filepath, List<string> allStrings)
    {
        var fileContents = ListToString(allStrings);
        File.WriteAllText(filepath, fileContents);
    }

    protected abstract List<string> StringsToList(string fileContents);
    protected abstract string ListToString(List<string> strings);


}
