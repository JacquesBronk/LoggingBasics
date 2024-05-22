using StructuredLoggingBasics.LoggerThings.ExceptionBasics.Base;

namespace StructuredLoggingBasics.LoggerThings.ExceptionBasics;

public class InvalidWeatherDataException(string methodName, string[] args, Exception? innerException = null) : DomainException(StructuredException.Domain.InvalidWeatherData, "Weather Data In Invalid Format", methodName, args, innerException);
