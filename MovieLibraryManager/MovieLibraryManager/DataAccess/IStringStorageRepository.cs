namespace MovieLibraryManager.DataAccess;

public interface IStringStorageRepository
{
    List<string> Read(string filepath);
    void Write(string filepath, List<string> allStrings);
}
