using System.Windows.Forms;
using System.Collections.Generic;

namespace TitanicCrawler.Websites
{
    public abstract class WebSite
    {
        protected RequestHandler requestHandler;
        protected List <HtmlDocument> documents;
        protected WebBrowser browser;
        protected Stack<HtmlElement> links;
        protected bool pageLoaded = false;
        private string webAddress;

        public bool PageLoaded
        {
            get { return pageLoaded; }
        }

        public string WebAddress
        {
            get{return webAddress;}
            set{webAddress = value;}
        }

        /// <summary>
        /// Creates a new Instance of a Website to crawl
        /// </summary>
        /// <param name="Address">Initial Address to navigate to</param>
        public WebSite(string Address)
        {
            WebAddress = Address;
            documents = new List<HtmlDocument>();
            navigateTo();
        }
        /// <summary>
        /// Navigates to a specified address
        /// </summary>
        protected void navigateTo()
        {
            pageLoaded = false;
            browser = new WebBrowser();
            browser.DocumentCompleted += Browser_DocumentCompleted;
            browser.ScriptErrorsSuppressed = true;
            requestHandler = new RequestHandler(WebAddress);
            browser.DocumentStream = requestHandler.Stream;
            pageLoaded = requestHandler.Successfull;
        }

        protected abstract void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e);
    }
}
