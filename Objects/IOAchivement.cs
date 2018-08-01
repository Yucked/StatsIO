using Newtonsoft.Json;

namespace GlobalSharp.Objects
{
    public struct IOAchievement
    {
        [JsonProperty("key")]
        public string Key { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("description")]
        public string Description { get; internal set; }

        [JsonProperty("image_active")]
        public string ImageActive { get; internal set; }

        [JsonProperty("image_inactive")]
        public string ImageInactive { get; internal set; }
    }
}
