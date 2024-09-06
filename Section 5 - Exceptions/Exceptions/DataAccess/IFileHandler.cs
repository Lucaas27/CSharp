using Exceptions.Model;

namespace Exceptions.DataAccess
{
    public interface IFileHandler
    {
        bool FileExists(string? fileName);
        string ReadFile(string fileName);
        List<VideoGame>? DeserializeJson(string fileContent, string fileName);
    }

}