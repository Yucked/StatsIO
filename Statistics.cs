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
        internal readonly Random Random;
        internal string GenerateUsername => $"IO-{Random.Next(9999)}";

        internal Statistics()
        {
            Random = new Random();
        }

        /// <summary>
        /// Creates a new entry in your GTD
        /// </summary>
        /// <param name="name">Name of the user</param>
        /// <exception cref="GlobalException"></exception>
        public async Task<IOStatistics> CreateAsync(string name = null)
        {
            var login = await LoginAsync();
            if (!login || !IOAccessToken.IsValid)
                return default(IOStatistics);
            var content = new StringContent(JsonConvert.SerializeObject(new InitialStats
            {
                Name = string.IsNullOrWhiteSpace(name) ? GenerateUsername : name,
                Values = new Values {Notes = 100}
            }), Encoding.UTF8, "application/json");
            var post = await Client.PostAsync("v1/statistics", content);
            if (!post.IsSuccessStatusCode)
                throw new GlobalException(EvaluateException((int) post.StatusCode));
            var responseContent = Deserialize<IOStatistics>(await post.Content.ReadAsStreamAsync());
            content.Dispose();
            post.Content.Dispose();
            return responseContent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"><see cref="IOStatistics"/></param>
        /// <returns></returns>
        public async Task UpdateAsync(string Id)
        {
            var put = await Client.PutAsync($"/v1/statistics/{Id}", null);
        }

        public async Task ShowUserStatsAsync(string id)
        {
            
        }
    }
}