namespace GlobalSharp
{
    public class GlobalClient : GlobalBase
    {
        public Statistics Statistics { get; }

        public GlobalClient(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            Statistics = new Statistics();
        }
    }
}