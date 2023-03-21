using Microsoft.Extensions.Logging;

namespace OpenTSDB_Producer;

public class SingleFactory
{
    static private ILoggerFactory? loggerFactory = null;
    
    private SingleFactory() {}

    static public ILoggerFactory GetLoggerFactory()
    {
        if (loggerFactory == null)
        {
            loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
        }

        return loggerFactory;
    }
}