using StarWarsStats.Models;

public interface IStarWarsAPIReader
{
    Task<string> CallEndpoint(string endpoint);
    // Task<IEnumerable<Planet>> GetPlanets(string endpoint);
}