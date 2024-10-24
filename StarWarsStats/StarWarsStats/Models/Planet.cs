using StarWarsStats.DTOs;
using StarWarsStats.Extensions;

namespace StarWarsStats.Models
{
    public readonly record struct Planet
    {
        public string Name { get; init; }
        public int Diameter { get; init; }
        public int? SurfaceWater { get; init; }
        public long? Population { get; init; }

        public Planet(string name, int diameter, int? surfaceWater, long? population)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Diameter = diameter;
            SurfaceWater = surfaceWater;
            Population = population;
        }

        public static explicit operator Planet(PlanetData planetDto)
        {
            var name = planetDto.Name;
            var diameter = int.Parse(planetDto.Diameter);

            long? population = planetDto.Population.ConverToLongOrNull();

            int? surfaceWater = planetDto.SurfaceWater.ConverToIntOrNull();

            return new Planet(name, diameter, surfaceWater, population);
        }

    }
}
