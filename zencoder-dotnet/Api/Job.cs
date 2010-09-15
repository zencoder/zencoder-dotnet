using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace ZencoderDotNet.Api
{
    public class Job
    {
        public string create(string body)
        {
            string jobUrl = Zencoder.BaseUrl + "/jobs";
            
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(jobUrl);
            req.Proxy = null;
            
            if (Zencoder.format == "xml")
            {
                req.ContentType = "application/xml";
                req.Accept = "application/xml";
            }
            else
            {
                req.Accept = "application/json";
                req.ContentType = "application/json";
            }
            byte[] reqData = Encoding.UTF8.GetBytes(body);
            req.ContentLength = reqData.Length;
            req.Method = "POST";

            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(reqData, 0, reqData.Length);
            }
            HttpWebResponse response = (HttpWebResponse)req.GetResponse();

            string responseBody = String.Empty;
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
                        responseBody += str;
                        count = readStream.Read(read, 0, 256);
                    }
                }
            }

            response.Close();
            return responseBody;
        }
    }
}
