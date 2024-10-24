namespace StarWarsStats.APIDataAccess
{
   public class MockStarWarsAPIReader : IStarWarsAPIReader
   {
      private const string ExpectedBaseAddress = "https://swapi.dev";
      private const string ExpectedRequestUri = "/api/planets";
      private readonly string _baseUrl;
      private readonly Task<string> _response = File.ReadAllTextAsync("./mockData.json");


      public MockStarWarsAPIReader(string baseUrl)
      {
         _baseUrl = baseUrl;
      }

      public async Task<string> CallEndpoint(string endpoint)
      {
         if (_baseUrl != ExpectedBaseAddress)
         {
            throw new ArgumentException(
                $"Base URL can only be {ExpectedBaseAddress}");
         }
         if (endpoint != ExpectedRequestUri)
         {
            throw new ArgumentException(
               $"Request URI can only be {ExpectedRequestUri}");
         }

         return await _response;
      }


   }
}