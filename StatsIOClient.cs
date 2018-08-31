using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StatsIO.Objects;

namespace StatsIO
{
    public class StatsIOClient : StatsIOBase
    {
        public Statistics Statistics { get; }
        public Achivements Achivements { get; }

        internal static string ClientId;
        internal static string ClientSecret;

        public StatsIOClient(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            Statistics = new Statistics();
            Achivements = new Achivements();
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