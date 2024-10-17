using System;
using Newtonsoft.Json;

namespace BuildingBlocks.Logger.Models
{
    public class LogJsonDataModel
    {
        [JsonProperty(PropertyName = "log_level", NullValueHandling = NullValueHandling.Ignore)]
        public string? LogLevel { get; set; }        

        [JsonProperty(PropertyName = "flow", NullValueHandling = NullValueHandling.Ignore)]
        public string? Flow { get; set; }
        
        [JsonProperty(PropertyName = "@timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Timestamp { get; set; }

        [JsonProperty(PropertyName = "message", NullValueHandling = NullValueHandling.Ignore)]
        public string? Message { get; set; }

        [JsonProperty(PropertyName = "data", NullValueHandling = NullValueHandling.Ignore)]
        public object? Data { get; set; }

        [JsonProperty(PropertyName = "exception", NullValueHandling = NullValueHandling.Ignore)]
        public object? Exception { get; set; }
    }
}
