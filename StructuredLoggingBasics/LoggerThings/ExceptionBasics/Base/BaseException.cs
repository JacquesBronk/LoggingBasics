namespace StructuredLoggingBasics.LoggerThings.ExceptionBasics.Base;

public abstract class BaseException(string errorCode, string message, string methodName, string[] args, Exception? innerException = null) : Exception(message, innerException)
{
    public string ErrorCode { get; } = errorCode;
    public DateTime ErrorTime { get; } = DateTime.UtcNow;
    public string MethodName { get; } = methodName;
    public string[] Arguments { get; } = args;

    public override string ToString()
    {
        var stringBuilder = new System.Text.StringBuilder();
        stringBuilder.Clear();
        stringBuilder.AppendLine($"Error {ErrorCode} at {ErrorTime}: {Message}");
        stringBuilder.AppendLine($"Method: {MethodName}");

        if (Arguments.Length > 0)
        {
            stringBuilder.AppendLine($"Arguments: {string.Join(", ", Arguments)}");
        }
        else
        {
            stringBuilder.AppendLine("Arguments: No arguments");
        }

        stringBuilder.AppendLine($"StackTrace: {StackTrace}");

        return stringBuilder.ToString();
    }
}