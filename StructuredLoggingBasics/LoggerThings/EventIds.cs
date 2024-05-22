namespace StructuredLoggingBasics.LoggerThings;

public static class EventIds
{
    public const int InfrastructureException = 1000;
    public const int ApplicationException = 2000;
    public const int DomainException = 3000;
    public const int DatabaseConnectionEstablished = 4000;
    public const int DatabaseConnectionFailed = 4001;
    public const int DatabaseConnectionClosed = 4002;
    public const int DatabaseConnectionOpened = 4003;
    public const int DatabaseConnectionError = 4004;
    public const int DatabaseConnectionTimeout = 4005;
    public const int DatabaseConnectionRetrying = 4006;
    public const int DatabaseConnectionRetried = 4007;
    public const int DatabaseConnectionRetryFailed = 4008;
    public const int DatabaseConnectionRetryLimitReached = 4009;
    public const int WeatherDataFetched = 5000;
    public const int WeatherDataFetchFailed = 5001;
    public const int WeatherDataInvalid = 5002;
    public const int WeatherDataInvalidFormat = 5003;
    public const int WeatherDataInvalidData = 5004;
}