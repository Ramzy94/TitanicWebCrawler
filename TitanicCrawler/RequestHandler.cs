using System.Net;
using System.IO;

namespace TitanicCrawler
{
    /// <summary>
    /// Class To Handle webrequests for the crawler
    /// </summary>
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
            try
            {
                HttpWebRequest request = HttpWebRequest.CreateHttp(address);
                request.Proxy = WebProxy.GetDefaultProxy();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                stream = response.GetResponseStream();
            }
            catch (System.Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
