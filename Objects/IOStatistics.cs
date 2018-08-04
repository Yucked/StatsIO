using Newtonsoft.Json;
using System.Collections.Generic;

namespace StatsIO.Objects
{
    public struct IOStatistics
    {
        [JsonProperty("name")] 
        public string Name { get; internal set; }

        [JsonProperty("_id")] 
        public string Id { get; internal set; }

        [JsonProperty("values")] 
        public IReadOnlyCollection<IOStatsValue> Values { get; internal set; }

        [JsonProperty("achievements")] 
        public IReadOnlyCollection<IOAchievement> Achievements { get; internal set; }
    }
}