using StructuredLoggingBasics.LoggerThings.ExceptionBasics.Base;

namespace StructuredLoggingBasics.LoggerThings.ExceptionBasics;

public class DatabaseConnectionException(string methodName, string[] args, Exception? innerException = null) : InfrastructureException(StructuredException.Infrastructure.UnableToConnectToDatabase, "Unable To connect to database", methodName, args, innerException);
