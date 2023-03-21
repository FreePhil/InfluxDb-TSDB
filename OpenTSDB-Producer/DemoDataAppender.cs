using Microsoft.Extensions.Logging;

namespace OpenTSDB_Producer;

public class DemoDataAppender
{
    private IWriter writer;
    private ILogger logger = SingleFactory.GetLoggerFactory().CreateLogger<DemoDataAppender>();
    
    private string[] locations = new string[] {"south", "north", "west", "east"};

    public DemoDataAppender(IWriter writer)
    {
        this.writer = writer;
    }
    
    public void WriteDemo(int dataCount)
    {
        var randomizer = new Random();
        for (int i = 0; i < dataCount; i++)
        {
            var location = locations[randomizer.Next(4)];
            var value = randomizer.Next(20) + 20.0;
            
            writer.Write(location, value);
            Thread.Sleep(200);
        }            
    }
}