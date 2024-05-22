namespace StructuredLoggingBasics.LoggerThings.ExceptionBasics.Base;

public abstract class DomainException(string errorCode, string message, string methodName, string[] args, Exception? innerException = null) : BaseException(errorCode, message, methodName, args, innerException);