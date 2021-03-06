﻿using System.Text;
using StatsIO.Objects;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace StatsIO
{
    public class StatsIOClient : StatsIOBase
    {
        public Statistics Statistics { get; }
        public Achievements Achievements { get; }

        internal static string ClientId;
        internal static string ClientSecret;

        public StatsIOClient(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            Statistics = new Statistics();
            Achievements = new Achievements();
        }

        public async Task<IOLink> LinkAsync(string id, string email)
        {
            var content = new StringContent(JsonConvert.SerializeObject(new
            {
                email
            }), Encoding.UTF8, "application/json");

            var post = await Client.PostAsync($"/v1/statisticlinks/{id}/request", content);
            if (!post.IsSuccessStatusCode)
                throw new APIException(EvaluateException((int) post.StatusCode));
            var responseContent = Deserialize<IOLink>(await post.Content.ReadAsStreamAsync());
            content.Dispose();
            post.Content.Dispose();
            return responseContent;
        }
    }
}