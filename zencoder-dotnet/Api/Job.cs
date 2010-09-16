using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;

namespace ZencoderDotNet.Api
{
    [DataContract]
    public class Job
    {
        public static Job create(string body, string format = null)
        {
            Request request = new Request("jobs", "POST", body, format);
            Response response = request.getResponse();

            return (Job)Zencoder.deserializeJson(typeof(Job), response.body);
        }

        [DataMember(Name="test")]
        private bool Test;
        public bool test { get { return Test; } }

        [DataMember(Name="id")]
        private int Id;
        public int id { get { return Id; } }
    }
}
