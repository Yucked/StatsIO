using System;
using System.IO;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using GlobalSharp.Objects;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace GlobalSharp
{
    public abstract class GlobalBase
    {
        internal string ClientId;
        internal string ClientSecret;

        internal readonly HttpClient Client;
        internal IOAccessToken IOAccessToken;
        internal readonly JsonSerializer Serializer;

        protected GlobalBase()
        {
            Client = new HttpClient
            {
                BaseAddress = new Uri("https://api.globalstats.io/")
            };
            Client.DefaultRequestHeaders.Clear();
            Serializer = new JsonSerializer();
        }

        protected async Task<bool> LoginAsync()
        {
            var content = new StringContent(
                $"grant_type=client_credentials&scope=endpoint_client&client_id={ClientId}&client_secret={ClientSecret}",
                Encoding.UTF8, "application/x-www-form-urlencoded");
            var post = await Client.PostAsync("oauth/access_token", content);
            if (!post.IsSuccessStatusCode)
                throw new Exception(post.ReasonPhrase);
            IOAccessToken = Deserialize<IOAccessToken>(await post.Content.ReadAsStreamAsync());
            content.Dispose();
            post.Content.Dispose();
            Client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(IOAccessToken.TokenType, IOAccessToken.Token);
            return string.IsNullOrWhiteSpace(IOAccessToken.Token);
        }

        protected T Deserialize<T>(Stream stream)
        {
            using (stream)
            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
                return Serializer.Deserialize<T>(jsonReader);
        }
    }
}