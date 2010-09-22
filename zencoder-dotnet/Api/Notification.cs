using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ZencoderDotNet.Api
{
    [DataContract]
    [XmlRoot("hash")]
    public class Notification
    {
        public static Notification deserialize(string body, string format)
        {
            return (Notification)Zencoder.deserialize(typeof(Notification), body, format);
        }

        [DataMember]
        [XmlElement]
        public Job job;

        [DataMember]
        [XmlElement]
        public Output output;


        public class Job
        {
            public string state;
            public bool test;
            public int id;
        }

        public class Output
        {
            public string label;
            public string url;
            public string state;
            public int id;
        }
    }
}
