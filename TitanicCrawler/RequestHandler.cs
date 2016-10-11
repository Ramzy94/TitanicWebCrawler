using System.Net;
using System.IO;
using System.Windows.Forms;
using System;

namespace TitanicCrawler
{
    /// <summary>
    /// Class To Handle webrequests for the crawler
    /// </summary>
    public class RequestHandler
    {
        private Stream document;
        private bool successfull;
        private WebClient client;

        public Stream Stream
        {
            get {return document;}
        }

        public bool Successfull
        {
            get {return successfull;}
        }

        public RequestHandler(string address)
        {

            string[] userAgents = { "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.79 Safari/537.36 Edge/14.14393",
                "Mozilla / 5.0(Windows NT 6.1; WOW64; rv: 8.0) Gecko / 20100101 Firefox / 8.0",
                "Mozilla/5.0 (X11; Linux x86_64; rv:17.0) Gecko/20121202 Firefox/17.0 Iceweasel/17.0.1",
                "Opera/9.80 (X11; Linux i686; Ubuntu/14.10) Presto/2.12.388 Version/12.16",
                "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/4.0; WOW64; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; Zune 4.0; InfoPath.3; MS-RTC LM 8; .NET4.0C; .NET4.0E; Maxthon 2.0)",
                "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; AS; rv:11.0) like Gecko",
                "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:40.0) Gecko/20100101 Firefox/40.1",
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_9_3) AppleWebKit/537.75.14 (KHTML, like Gecko) Version/7.0.3 Safari/7046A194A",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:51.0) Gecko/20100101 Firefox/51.0",
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_8_5) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1636.0 Safari/537.36",
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_6_8) AppleWebKit/534.59.8 (KHTML, like Gecko) Version/5.1.9 Safari/534.59.8",
            };

            Random random = new Random();

            try
            {
                client = new WebClient();
                client.OpenReadCompleted += Client_OpenReadCompleted;
                client.Headers.Add(HttpRequestHeader.UserAgent,userAgents[random.Next(0,userAgents.Length)] );
                document = client.OpenRead(address);

                successfull = true;
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message + "Its This One Bra");
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message + "\nEntlek it's This One Bra");
            }
        }

        public void nullify()
        {
            if (document != null)
            {
                document.Flush();
                document.Close();
                document = null;
                client.Dispose();
                client = null;
                Console.WriteLine("Disposed");
            }
        }

        private void Client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            MessageBox.Show("good to go");
        }
    }
}
