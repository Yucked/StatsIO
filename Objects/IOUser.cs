using Newtonsoft.Json;

namespace StatsIO.Objects
{
    public struct IOUser
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    
        [JsonProperty("user_profile")]
        public string UserProfile { get; set; }

        [JsonProperty("user_icon")]
        public string UserIcon { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }
    }
}