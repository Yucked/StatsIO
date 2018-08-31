using Newtonsoft.Json;
using System.Collections.Generic;

namespace StatsIO.Objects
{
    public class IOLeaderboards
    {
        [JsonProperty("data")]
        public IReadOnlyCollection<UserInfo> Data { get; internal set; }
    }   

    public class UserInfo : IOUser
    {
        [JsonProperty("additionals")]
        public List<Additional> Additionals { get; internal set; }
    }

    public struct Additional
    {
        [JsonProperty("key")]
        public string Key { get; internal set; }

        [JsonProperty("value")]
        public long Value { get; internal set; }

        [JsonProperty("rank")]
        public long Rank { get; internal set; }
    }
}