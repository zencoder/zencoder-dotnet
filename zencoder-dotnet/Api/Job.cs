using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ZencoderDotNet.Api
{
    [DataContract]
    [XmlRoot("api-response")]
    public class Job
    {
        public static Job create(string body, string format = null)
        {
            Request request = new Request("jobs", "POST", body, format);
            Response response = request.getResponse();
            if (response.format == "xml")
            {
                string xml = response.body;
                xml = xml.Replace("<job>", "");
                xml = xml.Replace("</job>", "");
                response.body = xml;
            }
            return (Job)Zencoder.deserialize(typeof(Job), response);
        }

        [DataMember]
        [XmlElement]
        public bool test;

        [DataMember]
        [XmlElement]
        public int id;

        [DataMember]
        [XmlArray("outputs")]
        [XmlArrayItem("output")]
        public List<output> outputs;

        [DataContract]
        public class output
        {
            [DataMember]
            [XmlElement]
            public string url;

            [DataMember]
            [XmlElement]
            public string label;

            [DataMember]
            [XmlElement]
            public int id;
        }
    }
}
