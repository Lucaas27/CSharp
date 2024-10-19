using System.Text.Json;
using System.Text.Json.Serialization;

IApiDataReader apiService = new ApiDataReader("https://datausa.io/api/");
var content = await apiService.Read("data?drilldowns=Nation&measures=Population");
Data? yearlyData = JsonSerializer.Deserialize<Data>(content);

if (yearlyData?.data != null)
{
    var result = string.Join(
        Environment.NewLine,
        yearlyData.data
            .OrderBy(d => d.Year)
            .Select(d => $"Nation: {d.Nation} - Year: {d.IDYear} - Population: {d.Population:N0}")
    );

    Console.WriteLine(result);
}
else
{
    Console.WriteLine("No data available.");
}

Console.ReadKey();


public interface IApiDataReader
{
    Task<string> Read(string endpoint);
}

class ApiDataReader : IApiDataReader
{
    private readonly string _baseUrl = "https://datausa.io/api/";
    public ApiDataReader(string baseUrl)
    {
        _baseUrl = baseUrl;
    }

    public async Task<string> Read(string endpoint)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(_baseUrl);
        HttpResponseMessage response = await client.GetAsync($"{endpoint}");
        response.EnsureSuccessStatusCode();

        string content = await response.Content.ReadAsStringAsync();

        return content;

    }
}

public record Annotations(
    [property: JsonPropertyName("source_name")] string source_name,
    [property: JsonPropertyName("source_description")] string source_description,
    [property: JsonPropertyName("dataset_name")] string dataset_name,
    [property: JsonPropertyName("dataset_link")] string dataset_link,
    [property: JsonPropertyName("table_id")] string table_id,
    [property: JsonPropertyName("topic")] string topic,
    [property: JsonPropertyName("subtopic")] string subtopic
);

public record Datum(
    [property: JsonPropertyName("ID Nation")] string IDNation,
    [property: JsonPropertyName("Nation")] string Nation,
    [property: JsonPropertyName("ID Year")] int IDYear,
    [property: JsonPropertyName("Year")] string Year,
    [property: JsonPropertyName("Population")] int Population,
    [property: JsonPropertyName("Slug Nation")] string SlugNation
);

public record Data(
    [property: JsonPropertyName("data")] IReadOnlyList<Datum> data,
    [property: JsonPropertyName("source")] IReadOnlyList<Source> source
);

public record Source(
    [property: JsonPropertyName("measures")] IReadOnlyList<string> measures,
    [property: JsonPropertyName("annotations")] Annotations annotations,
    [property: JsonPropertyName("name")] string name,
    [property: JsonPropertyName("substitutions")] IReadOnlyList<object> substitutions
);
