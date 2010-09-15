using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZencoderDotNet
{
    public class Zencoder
    {
        public static string BaseUrl = "https://zencoder-qa.heroku.com/api";
        public static string format = "json";
        private static string apiKey;

        public static string ApiKey
        {
            get
            {
                if (apiKey == null)
                {
                    return Environment.GetEnvironmentVariable("ZENCODER_API_KEY");
                }
                else
                {
                    return apiKey;
                }
            }
            set { apiKey = value; }
        }
    }
}
