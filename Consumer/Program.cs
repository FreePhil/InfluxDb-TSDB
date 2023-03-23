// See https://aka.ms/new-console-template for more information

using InfluxDB.Client;
using Microsoft.Extensions.Logging;
using OpenTSDB_Producer;

ILogger logger = SingleFactory.GetLoggerFactory().CreateLogger<Program>();

// create client
//
var endpoint = "http://localhost:8086";
var token = "henge";

logger.LogInformation("Create client for connecting {Url} with token {Token}", endpoint, token);
var client = new InfluxDBClient(endpoint, token);

// create query
//
var flux = "from(bucket:\"my-bucket\") |> range(start: -2m)"
           + "|> filter(fn: (r) => r.location == \"west\")"
           + "|> mean()"
           + "|> yield(name: \"_results\")";

var rawFlux = "from(bucket:\"my-bucket\") |> range(start: -2m)";

logger.LogInformation("Create query: {Query}", flux);
    
for (int i = 0; i < 1000; i++)
{
    var data = await client.GetQueryApi().QueryAsync<Temperature>(flux, "henge");
    var rawData = await client.GetQueryApi().QueryAsync(rawFlux, "henge");
    
    var temperature = data[0];
    logger.LogInformation("Average temperature: {Temperature:0.00}", temperature.Value);

    logger.LogDebug("{DataPoint}: point data for measurement {Measurement}", rawData[0].Records[0].GetTime(), rawData[0].Records[0].GetMeasurement());
    foreach (var table in rawData)
    {
        foreach (var record in table.Records)
        {
            logger.LogDebug("----- data point -----");
            foreach (var field in record.Values)
            {
                logger.LogDebug("{Key}: {Value}", field.Key, field.Value);
            }
        }
    }

    Thread.Sleep(2000);
}

Console.WriteLine("Press enter to end the program.");
Console.ReadLine();