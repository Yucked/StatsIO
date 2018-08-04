using System;
using Newtonsoft.Json;

namespace StatsIO.Objects
{
    public struct IOStatsValue
    {
        [JsonProperty("key")] 
        public string Key { get; internal set; }

        [JsonProperty("value")] 
        public int Value { get; internal set; }

        [JsonProperty("sorting")] 
        public string Sorting { get; internal set; }

        [JsonProperty("rank")] 
        public int Rank { get; internal set; }

        [JsonProperty("updated_at")] 
        public DateTimeOffset UpdatedAt { get; internal set; }
    }
}