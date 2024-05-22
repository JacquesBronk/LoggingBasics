using StructuredLoggingBasics.LoggerThings;
using StructuredLoggingBasics.LoggerThings.ExceptionBasics;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.AddConsole();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", (ILogger<Program> logger) =>
    {
        List<WeatherForecast> forecasts = new();
        for (int index = 0; index <= 5; index++)
        {
            DateOnly date = DateOnly.FromDateTime(DateTime.Now.AddDays(index));
            int temperatureC = Random.Shared.Next(-20, 55);
            string summary = summaries[Random.Shared.Next(summaries.Length)];
            logger.LogDebug("Weather for {Date} is {Temperature}C and {Summary}", date, temperatureC, summary);
            forecasts.Add(new WeatherForecast(date, temperatureC, summary));
        }

        return forecasts.ToArray();
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.MapGet("/error", (ILogger<Program> logger) =>
    {
        Random random = new Random();
        int exceptionType = random.Next(1, 4);
        try
        {
            switch (exceptionType)
            {
                case 1:
                    throw new DatabaseConnectionException("GetWeatherForecast", new string[] { "Connection String" });
                case 2:
                    throw new UnableToGetWeatherException("GetWeatherForecast", new string[] { "Location" });
                case 3:
                    throw new InvalidWeatherDataException("GetWeatherForecast", new string[] { "Weather Data" });
                default:
                    throw new Exception("Unknown Exception");
            }
        }
        catch (Exception e)
        {
            logger.LogError(EventIds.DatabaseConnectionError, e, StructuredException.Application.UnableToGetWeather);
        }
    })
    .WithName("GetError")
    .WithOpenApi();

app.MapGet("/withscope", (ILogger<Program> logger) =>
    {
        int importantNumber = 42;

        using (logger.BeginScope("ImportantNumber: {ImportantNumber}", importantNumber))
        {
            int notSoImportantNumber = 24;
            logger.LogInformation("This is an important log");
            logger.LogInformation("This is another important log");
            logger.LogDebug("This is not such an important number: {NotSoImportantNumber}", notSoImportantNumber);
        }
    })
    .WithName("GetLogWithScope")
    .WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}