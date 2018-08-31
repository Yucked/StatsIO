namespace StatsIO
{
    public class StatsIOClient
    {
        public Statistics Statistics { get; }
        internal static string ClientId;
        internal static string ClientSecret;

        public StatsIOClient(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            Statistics = new Statistics();
        }
    }
}