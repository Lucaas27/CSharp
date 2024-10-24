
using System.Text.Json;
using StarWarsStats.DTOs;
using StarWarsStats.Enums;
using StarWarsStats.Extensions;
using StarWarsStats.Models;
using StarWarsStats.UserInteraction;

namespace StarWarsStats.Application
{
    public class StarWarsApp : IStarWarsApp
    {
        private readonly IUserInteraction _userInteraction;
        private readonly IStarWarsAPIReader _apiDataReader;

        public StarWarsApp(IStarWarsAPIReader apiDataReader, IUserInteraction userInteraction)
        {
            _userInteraction = userInteraction;
            _apiDataReader = apiDataReader;
        }

        public async Task Run()
        {
            _userInteraction.PrintMessage("Welcome to the Star Wars Stats App!");

            var planets = await GetPlanets();

            // var planetsString = string.Join(Environment.NewLine, planets.Select(planet => $"Name: {planet.Name} - Population: {planet.Population} - Diameter: {planet.Diameter} - Surface Water: {planet.SurfaceWater}"));

            _userInteraction.PrintTable(planets);

            // _userInteraction.PrintMessage(planetsString);

            _userInteraction.PrintMenuOptions();

            var input = _userInteraction.ReadInput();

            var selectedOption = ValidateInput(input);

            await ShowStats(selectedOption, planets);

        }

        private async Task ShowStats(MenuOptions? selectedOption, IEnumerable<Planet> planets)
        {
            var description = selectedOption?.GetDescription();

            if (selectedOption == MenuOptions.restart)
            {
                await Run();
                return;
            }

            if (selectedOption == MenuOptions.exit)
            {
                _userInteraction.Exit();
                return;
            }

            Func<Planet, long?> propertySelector = selectedOption switch
            {
                MenuOptions.population => planet => planet.Population,
                MenuOptions.diameter => planet => planet.Diameter,
                MenuOptions.surfaceWater => planet => planet.SurfaceWater,
                _ => throw new ArgumentOutOfRangeException("Invalid option selected. Please try again.")
            };

            var planetWithLargestProperty = planets.MaxBy(propertySelector);
            _userInteraction.PrintMessage($"The planet with the largest {description} is: {planetWithLargestProperty.Name} - {propertySelector(planetWithLargestProperty)}");

            var planetWithSmallestProperty = planets.MinBy(propertySelector);
            _userInteraction.PrintMessage($"The planet with the smallest {description} is: {planetWithSmallestProperty.Name} -  {propertySelector(planetWithSmallestProperty)}");
        }
        private MenuOptions? ValidateInput(string? input)
        {

            // Check if the input matches the Description attribute of any enum value
            foreach (var option in Enum.GetValues<MenuOptions>())
            {
                var description = option.GetDescription();
                if (string.Equals(input, description, StringComparison.OrdinalIgnoreCase))
                {
                    return option;
                }
            }


            // Check if the input is a valid enum value
            if (Enum.TryParse<MenuOptions>(input, true, out var menuOption)
            && Enum.IsDefined(menuOption))
            {
                return menuOption;
            }
            else if (input == MenuOptions.exit.ToString())
            {
                return MenuOptions.exit;
            }
            else
            {
                _userInteraction.PrintErrorMessage("Invalid input. Please try again.");
                return MenuOptions.restart;
            }
        }



        private async Task<IEnumerable<Planet>> GetPlanets()
        {
            var response = await _apiDataReader.CallEndpoint("/api/planets");

            var planetsDTO = JsonSerializer.Deserialize<PlanetDTO>(response);

            var planets = ConvertToCustomPlanets(planetsDTO);

            return planets;
        }

        private static IEnumerable<Planet> ConvertToCustomPlanets(PlanetDTO? planetsDTO)
        {
            ArgumentNullException.ThrowIfNull(planetsDTO);

            var planets = planetsDTO.PlanetData.Select(planetDTO => (Planet)planetDTO);

            return planets;
        }



    }
}