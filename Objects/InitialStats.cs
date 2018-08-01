using Newtonsoft.Json;

namespace GlobalSharp.Objects
{
    public struct InitialStats
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("values")]
        public Values Values { get; set; }
    }

    public struct Values
    {
        [JsonProperty("Notes")]
        public int Notes { get; set; }
    }
}
