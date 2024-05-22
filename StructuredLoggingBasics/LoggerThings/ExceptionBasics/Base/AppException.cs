namespace StructuredLoggingBasics.LoggerThings.ExceptionBasics.Base;

public abstract class AppException(string errorCode, string message, string methodName, string[] args, Exception? innerException = null) : BaseException(errorCode, message, methodName, args, innerException);