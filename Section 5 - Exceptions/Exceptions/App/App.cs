using Exceptions.DataAccess;
using Exceptions.UserInteraction;
using Exceptions.Model;

namespace Exceptions.App
{
    public class App
    {
        private readonly IFileHandler _fileHandler;
        private readonly IUserInteraction _userInteraction;

        public App(IFileHandler fileHandler, IUserInteraction userInteraction)
        {
            _fileHandler = fileHandler;
            _userInteraction = userInteraction;
        }
        public void Run()
        {
            // Get the name of the file to read
            string fileToRead = GetFileName();
            // Read the file content
            string fileContent = _fileHandler.ReadFile(fileToRead);
            // Parse the JSON content
            List<VideoGame>? videoGames = _fileHandler.DeserializeJson(fileContent, fileToRead);
            // Print the video games in the file
            PrintVideoGames(videoGames);
            // Exit the application
            _userInteraction.Exit();
        }

        private string GetFileName()
        {
            string? fileToRead;
            bool isInputValid;
            bool fileExists = false;

            do
            {
                // Ask the user for the name of the file to read
                _userInteraction.PrintMessage("Enter the name of the file you want to read: ");
                fileToRead = _userInteraction.ReadInput();
                isInputValid = _userInteraction.IsInputValid(fileToRead);
                if (!isInputValid)
                {
                    continue;
                }

                // Check if the file exists
                fileExists = _fileHandler.FileExists(fileToRead);
                if (!fileExists)
                {
                    _userInteraction.PrintMessage($"File not found. Please try again.");
                    continue;
                }

            } while (!isInputValid || !fileExists);

            return fileToRead!;
        }

        private void PrintVideoGames(List<VideoGame>? videoGames)
        {
            if (videoGames != null && videoGames.Count > 0)
            {
                _userInteraction.PrintMessage("The following games were loaded:");
                foreach (var game in videoGames)
                {
                    _userInteraction.PrintMessage(game);
                }
            }
            else
            {
                _userInteraction.PrintMessage("No games were loaded.");
            }
        }

    }
}