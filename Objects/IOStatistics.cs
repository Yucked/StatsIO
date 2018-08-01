using Newtonsoft.Json;
using System.Collections.Generic;

namespace GlobalSharp.Objects
{
    public struct IOStatistics
    {
        [JsonProperty("name")] 
        public string Name { get; internal set; }

        [JsonProperty("_id")] 
        public string Id { get; internal set; }

        [JsonProperty("values")] 
        public IReadOnlyCollection<StatsValue> Values { get; internal set; }

        [JsonProperty("achievements")] 
        public IReadOnlyCollection<IOAchievement> Achievements { get; internal set; }
    }

    public struct StatsValue
    {
        [JsonProperty("key")] 
        public string Key { get; internal set; }

        [JsonProperty("value")] 
        public long Value { get; internal set; }

        [JsonProperty("sorting")] 
        public string Sorting { get; internal set; }

        [JsonProperty("rank")] 
        public int Rank { get; internal set; }
    }
}