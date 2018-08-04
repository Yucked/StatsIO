using System;
using Newtonsoft.Json;

namespace StatsIO.Objects
{
    public class IOAccessToken
    {
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; internal set; }
        
        [JsonProperty("token_type")]
        public string TokenType { get; internal set; }
        
        [JsonProperty("access_token")]
        public string Token { get; internal set; }
        
        [JsonIgnore] 
        private readonly int CreatedAt = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        
        [JsonIgnore]
        public bool IsValid => CreatedAt + ExpiresIn - 120 > (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
    }
}