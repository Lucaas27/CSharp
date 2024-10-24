using System.Text.Json;
using StarWarsStats.DTOs;
using StarWarsStats.Enums;
using StarWarsStats.Models;
using StarWarsStats.UserInteraction;

namespace StarWarsStats.APIDataAccess
{
    public class StarWarsAPIReader : IStarWarsAPIReader
    {
        protected readonly string _baseUrl;
        private readonly IStarWarsAPIReader _mockAPI;

        public StarWarsAPIReader(string baseUrl, IStarWarsAPIReader mockAPI)
        {
            _baseUrl = baseUrl;
            _mockAPI = mockAPI;

        }




        public async Task<string> CallEndpoint(string endpoint)
        {
            try
            {

                using var client = new HttpClient();
                client.BaseAddress = new Uri(_baseUrl);

                var response = await client.GetAsync($"{endpoint}");

                response.EnsureSuccessStatusCode();

                // Read the response as a string and return it to the caller. If the response is null, call the mock API reader.
                string content = await response.Content.ReadAsStringAsync() ?? await _mockAPI.CallEndpoint(endpoint);

                return content;

            }
            catch (HttpRequestException)
            {

                if (endpoint == "/api/planets")
                {
                    return await _mockAPI.CallEndpoint(endpoint);
                }

                throw;
            }
        }



    }


}