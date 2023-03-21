﻿using InfluxDB.Client.Core;

namespace OpenTSDB_Producer;

[Measurement("temperature")]
public class Temperature
{
    [Column("location", IsTag = true)] 
    public string Location { get; set; } = string.Empty;
    
    [Column("value")]
    public double Value { get; set; }
    
    [Column(IsTimestamp = true)]
    public DateTime Time { get; set; }
}