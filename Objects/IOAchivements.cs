using System.Collections.Generic;
using Newtonsoft.Json;

namespace StatsIO.Objects
{
    public struct IOAchivements
    {
        [JsonProperty("achievements")]
        public IReadOnlyCollection<IOAchievement> Achievements { get; internal set; }
    }
}