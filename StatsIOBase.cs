﻿using System;
using System.IO;
using System.Text;
using StatsIO.Objects;
using Newtonsoft.Json;
using System.Net.Http;
using System.Globalization;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json.Converters;

namespace StatsIO
{
    public abstract class StatsIOBase
    {
        internal readonly HttpClient Client;
        internal IOAccessToken IOAccessToken;
        private readonly JsonSerializer Serializer;

        protected StatsIOBase()
        {
            Client = new HttpClient
            {
                BaseAddress = new Uri("https://api.globalstats.io/")
            };
            Client.DefaultRequestHeaders.Clear();
            Serializer = new JsonSerializer
            {
                DateParseHandling = DateParseHandling.None,
                NullValueHandling = NullValueHandling.Ignore,
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                Converters =
                {
                    new IsoDateTimeConverter
                    {
                        DateTimeStyles = DateTimeStyles.AssumeUniversal
                    }
                }
            };
        }

        protected async Task LoginAsync()
        {
            if (IOAccessToken != null && IOAccessToken.IsValid)
                return;
            var content = new StringContent(
                $"grant_type=client_credentials&scope=endpoint_client&client_id={StatsIOClient.ClientId}&client_secret={StatsIOClient.ClientSecret}",
                Encoding.UTF8, "application/x-www-form-urlencoded");
            var post = await Client.PostAsync("oauth/access_token", content);
            if (!post.IsSuccessStatusCode)
                throw new APIException(EvaluateException((int) post.StatusCode));
            IOAccessToken = Deserialize<IOAccessToken>(await post.Content.ReadAsStreamAsync());
            content.Dispose();
            post.Content.Dispose();
            Client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(IOAccessToken.TokenType, IOAccessToken.Token);
        }

        protected string EvaluateException(int errorCode)
        {
            switch (errorCode)
            {
                case 400: return "Either the OAuth token or request content is invalid.";
                case 403: return "You are not allowed to access this resource!";
                case 404: return "Woops, couldn't find anything here. Is the URL address correct?";
                case 405: return "You aren't allowed to access this feature.";
                case 503: return "Woah! Slow down. Rate limit reached.";
                default: return string.Empty;
            }
        }

        protected T Deserialize<T>(Stream stream)
        {
            using (stream)
            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
                return Serializer.Deserialize<T>(jsonReader);
        }
    }
}