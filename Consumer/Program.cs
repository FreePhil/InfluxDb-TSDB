// See https://aka.ms/new-console-template for more information

using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;
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
logger.LogInformation("Create query: {Query}", flux);
    
for (int i = 0; i < 1000; i++)
{
    var data = await client.GetQueryApi().QueryAsync<Temperature>(flux, "henge");
    var temperature = data[0];
    logger.LogInformation("Average temperature: {Temperature}", temperature.Value);

    Thread.Sleep(5000);
}

Console.WriteLine("Press enter to end the program.");
Console.ReadLine();