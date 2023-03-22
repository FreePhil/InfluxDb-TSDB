using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;

namespace OpenTSDB_Producer;

public class SingleFactory
{
    private static ILoggerFactory? loggerFactory = null;
    
    private SingleFactory() {}

    public static ILoggerFactory GetLoggerFactory()
    {
        if (loggerFactory == null)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog();
            });
        }

        return loggerFactory;
    }
}