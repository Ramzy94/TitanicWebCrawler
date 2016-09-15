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
        private bool successfull;

        public Stream Stream
        {
            get {return stream;}
        }

        public bool Successfull
        {
            get {return successfull;}
        }

        public RequestHandler(string address)
        {
            try
            {
                HttpWebRequest request = WebRequest.CreateHttp(address);
                //request.ServicePoint.ConnectionLimit = 1;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                stream = response.GetResponseStream();
                successfull = true;
            }
            catch (System.Exception ex)
            {
                successfull = false;
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
