using StructuredLoggingBasics.LoggerThings.ExceptionBasics.Base;

namespace StructuredLoggingBasics.LoggerThings.ExceptionBasics;

public class UnableToGetWeatherException(string methodName, string[] args, Exception? innerException = null) : AppException(StructuredException.Application.UnableToGetWeather, "Unable To Fetch Weather Data", methodName, args, innerException);
