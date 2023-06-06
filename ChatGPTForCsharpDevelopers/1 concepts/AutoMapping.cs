using AutoMapper;
using ChatGPTForCsharpDevelopers._1_concepts.Domain;
using ChatGPTForCsharpDevelopers._1_concepts.DTO;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<WeatherDataDto, WeatherInfo>()
            .ForMember(dest => dest.WindSpeed, opt => opt.MapFrom(src => src.Wind.Speed))
            .ForMember(dest => dest.Pressure, opt => opt.MapFrom(src => src.Main.Pressure))
            .ForMember(dest => dest.MaxTemperature, opt => opt.MapFrom(src => src.Main.Temp_Max))
            .ForMember(dest => dest.Humidity, opt => opt.MapFrom(src => src.Main.Humidity));
    }
}
