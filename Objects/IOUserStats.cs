using Newtonsoft.Json;
using System.Collections.Generic;

namespace StatsIO.Objects
{
    public struct IOUserStats
    {
        [JsonProperty("name")] 
        public string Name { get; internal set; }

        [JsonProperty("statistics")] 
        public IReadOnlyCollection<IOStatsValue> Statistics { get; internal set; }
    }
}