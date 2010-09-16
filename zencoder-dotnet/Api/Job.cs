using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace ZencoderDotNet.Api
{
    public class Job
    {
        public static Response create(string body, string format = null)
        {
            Request request = new Request("jobs", "POST", body, format);
            return request.getResponse();
        }
    }
}
