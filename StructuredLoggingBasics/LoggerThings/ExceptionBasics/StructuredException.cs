namespace StructuredLoggingBasics.LoggerThings.ExceptionBasics;

public static class StructuredException
{
    public static class Infrastructure
    {
        public const string UnableToConnectToDatabase = $"{TopicDictionary.Infra}.{TopicDictionary.Database}.{TopicDictionary.DatabaseConnection}.{TopicDictionary.Exception}.UnableToConnectToDatabase";
    }

    public static class Application
    {
        public const string UnableToGetWeather = $"{TopicDictionary.App}.{TopicDictionary.WeatherApi}.{TopicDictionary.Exception}.UnableToGetWeather";
    }
    
    public static class Domain
    {
        public const string InvalidWeatherData = $"{TopicDictionary.Domain}.{TopicDictionary.WeatherApi}.{TopicDictionary.Exception}.InvalidWeatherData";
    }
}