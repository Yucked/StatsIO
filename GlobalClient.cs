using System;
using System.IO;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using GlobalSharp.Objects;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Collections.Generic;

namespace GlobalSharp
{
    public class GlobalClient
    {
        internal HttpClient Client;
        internal readonly string ClientId;
        private JsonSerializer Serializer;
        internal readonly string ClientSecret;
        internal IOAccessToken IOAccessToken;

        public GlobalClient(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            Client = new HttpClient
            {
                BaseAddress = new Uri("https://api.globalstats.io/")
            };
            Client.DefaultRequestHeaders.Clear();
            Serializer = new JsonSerializer();
        }

        public async Task<bool> LoginAsync()
        {
            var content = new StringContent(
                $"grant_type=client_credentials&scope=endpoint_client&client_id={ClientId}&client_secret={ClientSecret}",
                Encoding.UTF8, "application/x-www-form-urlencoded");
            var post = await Client.PostAsync("oauth/access_token", content);
            if (!post.IsSuccessStatusCode)
                throw new Exception(post.ReasonPhrase);
            IOAccessToken = DeserializeAsync<IOAccessToken>(await post.Content.ReadAsStreamAsync());
            content.Dispose();
            post.Content.Dispose();
            Client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(IOAccessToken.TokenType, IOAccessToken.AccessToken);
            return string.IsNullOrWhiteSpace(IOAccessToken.AccessToken);
        }

        public async Task CreateStatisticsAsync()
        {
            if (!IOAccessToken.IsValid) return;
            var content = new StringContent(JsonConvert.SerializeObject(new
            {
                name = "Yucked",
                values = new KeyValuePair<string, int>("Notes", 50)
            }), Encoding.UTF8, "application/json");
            var post = await Client.PostAsync("v1/statistics", content);
            if (!post.IsSuccessStatusCode)
                throw new Exception(post.ReasonPhrase);
        }


        protected T DeserializeAsync<T>(Stream stream)
        {
            using (stream)
            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
                return Serializer.Deserialize<T>(jsonReader);
        }
    }
}