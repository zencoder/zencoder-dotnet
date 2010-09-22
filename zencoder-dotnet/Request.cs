using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace ZencoderDotNet
{
    public class Request
    {
        // update the request object whenever a public field is changed
        private string requestBody;
        public string body
        {
            get { return requestBody; }
            set 
            { 
                requestBody = value;
                setupRequest();
            }
        }

        private string requestMethod;
        public string method
        {
            get { return requestMethod; }
            set
            {
                requestMethod = value;
                setupRequest();
            }
        }

        private string requestFormat;
        public string format
        {
            get
            {
                if (requestFormat == null)
                {
                    return Zencoder.format;
                }
                else
                {
                    return requestFormat;
                }
            }
            set
            {
                requestFormat = value;
                setupRequest();
            }
        }

        private string requestUrl;
        public string url
        {
            get
            {
                return requestUrl;
                
            }
            set
            {
                requestUrl = value;
                setupRequest();
            }
        }

        private HttpWebRequest webRequest;

        public Request(string Url, string Method, string Body = null, string Format = null)
        {
            // Setting private variables directly so setupRequest() isn't called each time
            requestUrl = Url;
            requestBody = Body;
            requestMethod = Method;
            requestFormat = Format;
            setupRequest();
        }

        public Response getResponse()
        {
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            return new Response(response, format);
        }

        private void setupRequest()
        {
            webRequest = (HttpWebRequest)WebRequest.Create(Zencoder.base_url + "/" + requestUrl);
            webRequest.Proxy = null;
            webRequest.Method = method;
            setRequestHeaders();
            if (body != null && method != "GET")
            {
                setRequestBody();
            }
            
        }

        private void setRequestHeaders()
        {
            if (format == "xml")
            {
                webRequest.Accept = "application/xml";
                webRequest.ContentType = "application/xml";
            }
            else
            {
                webRequest.Accept = "application/json";
                webRequest.ContentType = "application/json";            
            }
            webRequest.Headers.Add("Zencoder-Library-Name: " + Zencoder.library_name);
            webRequest.Headers.Add("Zencoder-Library-Version: " + Zencoder.library_version);
        }

        private void setRequestBody()
        {
            byte[] reqData = Encoding.UTF8.GetBytes(body);
            webRequest.ContentLength = reqData.Length;
            using (Stream reqStream = webRequest.GetRequestStream())
            {
                reqStream.Write(reqData, 0, reqData.Length);
            }
        }
    }
}
