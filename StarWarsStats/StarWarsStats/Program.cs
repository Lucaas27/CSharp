using StarWarsStats.APIDataAccess;
using StarWarsStats.Application;
using StarWarsStats.UserInteraction;

var baseUrl = "https://swapi.dev/api";
var userInteraction = new ConsoleInteraction();
var mockAPI = new MockStarWarsAPIReader(baseUrl); // This is a mock API reader that returns a JSON string of planet data. Only used if the actual API call fails.
IStarWarsAPIReader apiDataReader = new StarWarsAPIReader(baseUrl, mockAPI);
var starWarsApp = new StarWarsApp(apiDataReader, userInteraction);

try
{
    await starWarsApp.Run();

}
catch (Exception ex)
{
    userInteraction.PrintErrorMessage($"An error occurred - {ex.Message}" + ex.StackTrace);
}
