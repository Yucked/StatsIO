using Newtonsoft.Json;
using System.Collections.Generic;

namespace StatsIO.Objects
{
    public struct IOStatSection
    {
        [JsonProperty("better_ranks")] 
        public Ranks BetterRanks { get; set; }

        [JsonProperty("user_rank")] 
        public IOUser UserRank { get; set; }

        [JsonProperty("worse_ranks")] 
        public Ranks WorseRanks { get; set; }
    }

    public class Ranks
    {
        [JsonProperty("data")] 
        public List<IOUser> Data { get; set; }
    }
}