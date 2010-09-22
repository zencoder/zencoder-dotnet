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
        public static string library_name { get { return "ZencoderDotNet"; } }
        public static string library_version { get { return "1.0.0.0"; } }
        public static string base_url = "https://app.zencoder.com/api";
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
            return deserialize(type, response.body, response.format);
        }

        public static object deserialize(Type type, string body, string format)
        {
            if (format == "xml")
            {
                return deserializeXml(type, body);
            }
            else
            {
                return deserializeJson(type, body);
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
