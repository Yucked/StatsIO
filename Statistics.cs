using System;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using GlobalSharp.Objects;
using System.Threading.Tasks;

namespace GlobalSharp
{
    public class Statistics : GlobalBase
    {
        internal string Id;
        internal readonly Random Random;
        internal string GenerateUsername => $"IO-{Random.Next(9999)}";

        internal Statistics()
        {
            Random = new Random();
        }

        public async Task<IOStatistics> AddOrUpdateAsync(string id = null, string name = null)
        {
            var login = await LoginAsync();
            if (!login || !IOAccessToken.IsValid)
                return default(IOStatistics);
            id = string.IsNullOrWhiteSpace(id) && !string.IsNullOrWhiteSpace(Id) ? Id : string.Empty;
            var requestUrl = !string.IsNullOrWhiteSpace(id) ? $"v1/statistics/{id}" : "v1/statistics/";
            
            var content = new StringContent(JsonConvert.SerializeObject(new InitialStats
            {
                Name = string.IsNullOrWhiteSpace(name) ? GenerateUsername : name,
                Values = new Values {Notes = 100}
            }), Encoding.UTF8, "application/json");
            var post = await Client.PostAsync("v1/statistics", content);
            if (!post.IsSuccessStatusCode)
                throw new Exception(post.ReasonPhrase);
            var responseContent = Deserialize<IOStatistics>(await post.Content.ReadAsStreamAsync());
        }
    }
}