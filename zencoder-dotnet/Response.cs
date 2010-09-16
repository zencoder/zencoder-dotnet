using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace ZencoderDotNet
{
    public class Response
    {
        private string responseBody;
        public string body
        {
            get { return responseBody; }
        }

        private string responseFormat;
        public string format { get { return responseFormat; } }
        
        
        public Response(HttpWebResponse response, string Format)
        {
            if (Format == "xml")
            {
                responseFormat = Format;
            }
            else {
                responseFormat = "json";
            }
            setResponseBody(response);
            response.Close();
        }

        private void setResponseBody(HttpWebResponse response)
        {
            string bodyText = String.Empty;
            using (Stream responseStream = response.GetResponseStream())
            {
                Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
                using (StreamReader readStream = new StreamReader(responseStream, encode))
                {
                    Char[] read = new Char[256];
                    int count = readStream.Read(read, 0, 256);
                    while (count > 0)
                    {
                        string str = new String(read, 0, count);
                        bodyText += str;
                        count = readStream.Read(read, 0, 256);
                    }
                }
            }
            responseBody = bodyText;
        }
    }
}
