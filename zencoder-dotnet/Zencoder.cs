using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

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

        public static object deserialize(Type type, Response response)
        {
            if (response.format == "xml")
            {
                Console.WriteLine("Deserializing XML: " + response.body);
                return deserializeXml(type, response.body);
            }
            else
            {
                Console.WriteLine("Deserializing JSON: " + response.body);
                return deserializeJson(type, response.body);
            }
        }
        
        private static object deserializeJson(Type type, string json)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(json);

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(type);
            object obj;
            using (MemoryStream s = new MemoryStream(bytes))
            {
                obj = serializer.ReadObject(s);
            }
            return obj;
        }

        private static object deserializeXml(Type type, string xml)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(xml);

            XmlSerializer serializer = new XmlSerializer(type);
            object obj;
            using (MemoryStream s = new MemoryStream(bytes))
            {
                obj = serializer.Deserialize(s);
            }
            return obj;
        }
    }
}
