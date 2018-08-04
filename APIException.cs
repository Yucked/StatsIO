using System;

namespace StatsIO
{
    public class APIException : Exception
    {
        public APIException(string message) : base(message)
        {
            
        }
    }
}