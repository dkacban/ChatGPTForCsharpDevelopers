using AutoMapper;
using ChatGPTForCsharpDevelopers._1_concepts.Domain;
using ChatGPTForCsharpDevelopers._2_documentation;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    static void Main(string[] args)
    {
        // Create service collection
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        // Create service provider
        var serviceProvider = serviceCollection.BuildServiceProvider();

        // Get instance of WeatherService from DI system
        var service = serviceProvider.GetRequiredService<WeatherService>();

        // Rest of your code...
        
        var weather = service.GetWeatherAsync("London").Result;

        Console.WriteLine($"weather: " +
            $"windSpeed: {weather.WindSpeed}, " +
            $"Pressure: {weather.Pressure}, " +
            $"MaxTemp: {weather.MaxTemperature}, " +
            $"humidity: {weather.Humidity}");
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // AutoMapper Configuration
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new AutoMapping());
        });

        IMapper mapper = mappingConfig.CreateMapper();
        services.AddSingleton(mapper);

        // Add your services
        var apiKey = "5080309f8043d0eccd48ccbaebca49d8";
        services.AddTransient(provider => new WeatherService(provider.GetRequiredService<IMapper>(), apiKey));
    }

}