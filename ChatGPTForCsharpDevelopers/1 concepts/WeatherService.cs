using AutoMapper;
using ChatGPTForCsharpDevelopers._1_concepts.Domain;
using ChatGPTForCsharpDevelopers._1_concepts.DTO;
using System.Text.Json;

public class WeatherService
{
    private readonly HttpClient httpClient;
    private readonly string apiKey;
    private readonly IMapper _mapper;

    public WeatherService(IMapper mapper, string apiKey)
    {
        _mapper = mapper;
        if (string.IsNullOrEmpty(apiKey))
        {
            throw new ArgumentException("API key must be provided.", nameof(apiKey));
        }

        this.apiKey = apiKey;
        this.httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/")
        };
    }

    public async Task<string> GetCurrentWeatherAsync(string cityName)
    {
        if (string.IsNullOrEmpty(cityName))
        {
            throw new ArgumentException("City name must be provided.", nameof(cityName));
        }

        var response = await this.httpClient.GetAsync($"weather?q={cityName}&appid={this.apiKey}");

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        using var jsonDoc = JsonDocument.Parse(json);
        var root = jsonDoc.RootElement;

        var weatherDescription = root.GetProperty("weather")[0].GetProperty("description").GetString();
        var temperature = root.GetProperty("main").GetProperty("temp").GetDecimal();

        // Convert temperature from Kelvin to Celsius
        temperature -= 273.15m;

        return $"The current weather in {cityName} is {weatherDescription} with a temperature of {temperature}°C.";
    }

    public async Task<WeatherInfo> GetWeatherAsync(string cityName)
    {
        var response = await this.httpClient.GetAsync($"weather?q={cityName}&appid={this.apiKey}");
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        var dto = JsonSerializer.Deserialize<WeatherDataDto>(json);

        return _mapper.Map<WeatherInfo>(dto);
    }
}



// Code for Main method testing:
//var weatherService = new WeatherService("5080309f8043d0eccd48ccbaebca49d8");
//string cityName = "Warsaw";
//var result = weatherService.GetCurrentWeatherAsync(cityName).Result;
//Console.WriteLine(result);
//Console.ReadLine();