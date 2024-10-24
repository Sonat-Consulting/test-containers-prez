using Microsoft.Extensions.Logging;
using static Microsoft.Extensions.Logging.LoggerFactory;

namespace TestcontainersExample;

public class Logging
{
    private static ILoggerFactory _loggerFactory = Create(builder =>
        builder.AddSimpleConsole(options =>
        {
            options.IncludeScopes = true;
            options.SingleLine = true;
            options.TimestampFormat = "HH:mm:ss ";
        }));

    public static ILoggerFactory LoggerFactory() => _loggerFactory;
}