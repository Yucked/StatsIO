using System;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using StatsIO.Objects;
using System.Threading.Tasks;

namespace StatsIO
{
    public class Statistics : StatsIOBase
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
        /// <exception cref="APIException"></exception>
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
                throw new APIException(EvaluateException((int) post.StatusCode));
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

        /// <summary>
        /// Get the ranking of a user.
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns></returns>
        /// <exception cref="APIException"></exception>
        public async Task<IOUserStats> ShowUserStatsAsync(string id)
        {
            var get = await Client.GetAsync($"/v1/statistics/{id}");
            if (!get.IsSuccessStatusCode)
                throw new APIException(EvaluateException((int) get.StatusCode));
            var responseContet = Deserialize<IOUserStats>(await get.Content.ReadAsStreamAsync());
            get.Content.Dispose();
            return responseContet;
        }

        /// <summary>
        /// Get a certain section of GTD
        /// </summary>
        /// <param name="id"></param>
        /// <param name="gtdKey"></param>
        /// <returns></returns>
        /// <exception cref="APIException"></exception>
        public async Task<IOStatSection> GetSectionAsync(string id, string gtdKey)
        {
            var get = await Client.GetAsync($"/v1/statistics/{id}/section/{gtdKey}");
            if (!get.IsSuccessStatusCode)
                throw new APIException(EvaluateException((int) get.StatusCode));
            var responseContent = Deserialize<IOStatSection>(await get.Content.ReadAsStreamAsync());
            get.Content.Dispose();
            return responseContent;
        }
    }
}