using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GlobalSharp
{
    public class GlobalClient
    {
        internal HttpClient Client;
        internal readonly string ClientId;
        internal readonly string ClientSecret;
        public GlobalClient(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            Client = new HttpClient
            {
                BaseAddress = new Uri("https://api.globalstats.io/")
            };
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.CacheControl.NoCache = true;

        }

        public async Task LoginAsync()
        {
            var get = await Client.GetAsync("oauth/access_token");
            get.Headers.Add("grant_type", "client_credentials");
            get.Headers.Add("scope", "endpoint_client");
            get.Headers.Add("client_id", ClientId);
            get.Headers.Add("client_secret", ClientSecret);
            if (!get.IsSuccessStatusCode)
                throw new Exception(get.ReasonPhrase);

        }
    }
}