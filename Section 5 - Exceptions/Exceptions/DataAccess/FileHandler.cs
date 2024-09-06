
using System.Text.Json;
using Exceptions.UserInteraction;
using Exceptions.Model;

namespace Exceptions.DataAccess
{
    public class FileHandler : IFileHandler
    {

        private readonly IUserInteraction _userInteraction;

        public FileHandler(IUserInteraction userInteraction)
        {
            _userInteraction = userInteraction;
        }


        public bool FileExists(string? fileName)
        {
            if (File.Exists(fileName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string ReadFile(string fileName)
        {
            string fileContent = File.ReadAllText(fileName);
            return fileContent;
        }

        public List<VideoGame>? DeserializeJson(string fileContent, string fileName)
        {
            try
            {
                List<VideoGame>? videoGames = JsonSerializer.Deserialize<List<VideoGame>>(fileContent);
                return videoGames;

            }
            catch (JsonException ex)
            {
                _userInteraction.PrintErrorMessage($"JSON in {fileName} does not contain valid JSON data.");
                _userInteraction.PrintErrorMessage($"{fileContent}");

                throw new JsonException($"The file does not contain valid JSON data - {ex.Message}. File: {fileName} ", ex);
            }
        }

    }

}