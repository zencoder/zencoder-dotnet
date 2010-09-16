using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

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

        public static object deserializeJson(Type type, string json)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(json);

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(type);
            object job;
            using (MemoryStream s = new MemoryStream(bytes))
            {
                job = serializer.ReadObject(s);
            }

            return job;
        }
    }
}
