namespace StatsIO
{
    public class StatsIOClient : StatsIOBase
    {
        public Statistics Statistics { get; }

        public StatsIOClient(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            Statistics = new Statistics();
        }
    }
}