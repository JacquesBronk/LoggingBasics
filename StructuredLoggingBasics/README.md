# Logging Basics

## Configuration
The logger configuration is typically set up in the `appsettings.json` or `appsettings.Development.json` file. Here, you can specify the log level for different categories, as well as configure the console logger to use a specific formatter.
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Warning",
      "Microsoft.AspNetCore": "Warning",
      "Program": "Debug"
    },
    "Console": {
      "FormatterName": "json",
      "FormatterOptions": {
        "SingleLine": true,
        "IncludeScopes": true,
        "UseUtcTimestamp": true,
        "JsonWriterOptions": {
          "Indented": true
        }
      }
    }
  }
}
```
In the `LogLevel` section, you can specify the minimum log level for different categories. The `Default` category applies to all logs, while the other categories apply to logs from specific namespaces. The log levels are as follows, in increasing order of severity: `Trace`, `Debug`, `Information`, `Warning`, `Error`, `Critical`.

In the `Console` section, you can configure the console logger. The `FormatterName` option specifies the formatter to use, in this case, the JSON formatter. The `FormatterOptions` section contains options specific to the JSON formatter.

### Log Categories
Log categories are a way to group related logs together. They are typically set to the fully qualified name of the class from which the logs are being written. This allows you to control the log level on a per-class basis.

### Scopes
Scopes provide a way to add contextual information to logs. When you start a scope, the specified data is attached to all subsequent logs until the scope is disposed. This can be useful for attaching data such as a request ID to all logs related to a specific HTTP request.

### Log Levels
Log levels indicate the severity of the logs. They are, in increasing order of severity: `Trace`, `Debug`, `Information`, `Warning`, `Error`, `Critical`. The log level set in the configuration is the minimum level for logs to be written. For example, if the log level is set to `Information`, then `Trace` and `Debug` logs will be ignored.

```csharp
  public enum LogLevel
  {
    /// <summary>
    /// Logs that contain the most detailed messages. These messages may contain sensitive application data.
    /// These messages are disabled by default and should never be enabled in a production environment.
    /// </summary>
    Trace,
    /// <summary>
    /// Logs that are used for interactive investigation during development.  These logs should primarily contain
    /// information useful for debugging and have no long-term value.
    /// </summary>
    Debug,
    /// <summary>
    /// Logs that track the general flow of the application. These logs should have long-term value.
    /// </summary>
    Information,
    /// <summary>
    /// Logs that highlight an abnormal or unexpected event in the application flow, but do not otherwise cause the
    /// application execution to stop.
    /// </summary>
    Warning,
    /// <summary>
    /// Logs that highlight when the current flow of execution is stopped due to a failure. These should indicate a
    /// failure in the current activity, not an application-wide failure.
    /// </summary>
    Error,
    /// <summary>
    /// Logs that describe an unrecoverable application or system crash, or a catastrophic failure that requires
    /// immediate attention.
    /// </summary>
    Critical,
    /// <summary>
    /// Not used for writing log messages. Specifies that a logging category should not write any messages.
    /// </summary>
    None,
  }
```

### Best Practices
* Use appropriate log levels: This helps to control the volume of logs and makes it easier to find important information.
* Use scopes to add context: This can make it easier to understand the context in which a log was written.
* Use structured logging: This allows you to write logs that can be easily queried and analyzed.
* Avoid sensitive data in logs: Never log sensitive data such as passwords or personally identifiable information.
* Use log categories: This allows you to control the log level on a per-class basis, which can be useful for debugging.
* __ALWAYS__ Read the latest docs: Logging is a complex topic with many options and configurations. Make sure to read the latest documentation to understand the best practices and options available.
## Structured Exception Setup
### Topic Dictionary
The first step in setting up structured exceptions is to define a topic dictionary. This is a static class that contains constant string values representing various topics or categories that your exceptions might fall under.  

For example, in the `TopicDictionary.cs` file, we have defined topics such as "Infrastructure", "Application", "Domain", "Event", "Exception", "Database", "DatabaseConnection", "Security", "WeatherApi", and "Redis".  

These topics can be used to categorize your exceptions and make it easier to filter and search for specific types of exceptions in your logs.

```csharp
namespace StructuredLoggingBasics.LoggerThings;

public static class TopicDictionary
{
    public const string Infra = "Infrastructure";
    public const string App = "Application";
    public const string Domain = "Domain";
    public const string Event = "Event";
    public const string Exception = "Exception";
    public const string Database = "Database";
    public const string DatabaseConnection = "DatabaseConnection";
    public const string Security = "Security";
    public const string WeatherApi = "WeatherApi";
    public const string Redis = "Redis";
}
```

### Structured Exceptions
Next, we define structured exceptions. These are static classes that contain constant string values representing specific exceptions. Each exception is defined as a string that combines various topics from the topic dictionary.

For example, in the `StructuredException.cs` file, we have defined exceptions such as "UnableToConnectToDatabase", "UnableToGetWeather", and "InvalidWeatherData". Each of these exceptions is defined as a string that combines various topics from the topic dictionary.

```csharp
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
```
### Application Specific Exceptions
Finally, we define application-specific exceptions. These are classes that inherit from a base exception class and are used to throw specific exceptions in your application. 

For example, in the `UnableToGetWeatherException.cs` file, we have defined an exception that is thrown when the application is unable to get weather data. This exception inherits from the AppException class and uses the "UnableToGetWeather" structured exception.

```csharp
using StructuredLoggingBasics.LoggerThings.ExceptionBasics.Base;

namespace StructuredLoggingBasics.LoggerThings.ExceptionBasics;

public class UnableToGetWeatherException(string methodName, string[] args, Exception? innerException = null) : AppException(StructuredException.Application.UnableToGetWeather, "Unable To Fetch Weather Data", methodName, args, innerException);
```
This setup allows for a structured and organized way to handle exceptions in your application. It makes it easier to filter and search for specific types of exceptions in your logs, and it provides a clear and consistent structure for defining and throwing exceptions.