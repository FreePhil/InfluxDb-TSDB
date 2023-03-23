using Microsoft.Extensions.Logging;

namespace OpenTSDB_Producer;

using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;

public class InfluxDbWriter: IWriter
{
    private const string url = "http://localhost:8086";
    private const string token = "henge";
    private const string org = "henge";
    private const string bucket = "my-bucket";

    private ILogger logger = SingleFactory.GetLoggerFactory().CreateLogger<InfluxDbWriter>();
    
    public void Write(string location, double value, double height)
    {
        using (var influxDBClient = new InfluxDBClient(url, token))
        using (var writeApi = influxDBClient.GetWriteApi())
        {
            var temperature = new Temperature
            {
                Location = location,
                Value = value,
                Height = height,
                Time = DateTime.UtcNow
            };
            logger.LogInformation("Record value {Value}, {Height} at {Location} on {Time}", 
                temperature.Value, temperature.Height, temperature.Location, temperature.Time, temperature.Height);
            writeApi.WriteMeasurement(temperature, WritePrecision.Ns, bucket, org);
        }
    }
}