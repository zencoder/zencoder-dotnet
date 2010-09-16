using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZencoderDotNet
{
    public class Zencoder
    {
        public static string base_url = "https://zencoder-qa.heroku.com/api";
        public static string format = "json";
        private static string apiKey;

        public static string api_key
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
