// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Logging;
using System;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using OpenTSDB_Producer;

// init logger
//
ILogger logger = SingleFactory.GetLoggerFactory().CreateLogger<Program>();

// init service provider
//
var provider = new ServiceCollection()
    .AddSingleton<IWriter, InfluxDbWriter>()
    .AddSingleton<DemoDataAppender>()
    .BuildServiceProvider();

logger.LogInformation("Application starting at {Time}.", DateTime.Now);

var appender = provider.GetService<DemoDataAppender>();
appender?.WriteDemo(10000);

Console.WriteLine("Press enter key to end the program.");
Console.ReadLine();

