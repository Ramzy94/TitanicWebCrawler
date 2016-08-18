using System;
using System.Net;
using System.IO;

namespace TitanicCrawler
{
    class RequestHandler
    {
        private Stream stream;

        public Stream Stream
        {
            get {return stream;}
            set {stream = value;}
        }

        public RequestHandler(string address)
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp(address);
            request.Proxy = WebProxy.GetDefaultProxy();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            stream = response.GetResponseStream();
        }
    }
}
