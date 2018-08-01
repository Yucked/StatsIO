using System;
using Newtonsoft.Json;

namespace GlobalSharp.Objects
{
    public class IOAccessToken
    {
        [JsonProperty("expires_in")]
        public int ExpiresIn;
        [JsonProperty("token_type")]
        public string TokenType;
        [JsonProperty("access_token")]
        public string AccessToken;
        [JsonIgnore]
        public int CreatedAt = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        [JsonIgnore]
        public bool IsValid => (CreatedAt + ExpiresIn - 120) > (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
    }
}