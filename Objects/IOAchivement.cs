using Newtonsoft.Json;

namespace GlobalSharp.Objects
{
    public struct IOAchievement
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("image_active")]
        public string ImageActive { get; set; }

        [JsonProperty("image_inactive")]
        public string ImageInactive { get; set; }
    }
}
