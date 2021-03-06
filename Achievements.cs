using StatsIO.Objects;
using System.Threading.Tasks;

namespace StatsIO
{
    public class Achievements : StatsIOBase
    {
        public async Task<IOAchievements> GetAllAsync()
        {
            await LoginAsync();
            var get = await Client.GetAsync("/v1/achievements");
            if (!get.IsSuccessStatusCode)
                throw new APIException(EvaluateException((int) get.StatusCode));
            var content = Deserialize<IOAchievements>(await get.Content.ReadAsStreamAsync());
            get.Content.Dispose();
            return content;
        }

        public async Task<IOAchievement> ManualAsync(string id, string achivementKey)
        {
            await LoginAsync();
            var get = await Client.GetAsync($"/v1/statistics/{id}/achievements/{achivementKey}/accomplish");
            if (!get.IsSuccessStatusCode)
                throw new APIException($"{achivementKey} already accomplished.");
            var content = Deserialize<IOAchievement>(await get.Content.ReadAsStreamAsync());
            get.Content.Dispose();
            return content;
        }

        public async Task<IOAchievements> DisplayUsersAsync(string id)
        {
            await LoginAsync();
            var get = await Client.GetAsync($"/v1/statistics/{id}/achievements");
            if (!get.IsSuccessStatusCode)
                throw new APIException(EvaluateException((int) get.StatusCode));
            var content = Deserialize<IOAchievements>(await get.Content.ReadAsStreamAsync());
            get.Content.Dispose();
            return content;
        }
    }
}