using Newtonsoft.Json;

namespace StatsIO.Objects
{
    public struct IOLink
    {
        [JsonProperty("url")]
        public string Url { get; internal set; }

        [JsonProperty("pin")]
        public string Pin { get; internal set; }
    }
}