using System.Windows.Forms;

namespace TitanicCrawler.Websites
{
    public abstract class WebSite
    {
        private RequestHandler requestHandler;
        protected HtmlDocument document;
        protected WebBrowser browser;
        protected HtmlElementCollection links;
        protected bool pageLoaded = false;

        public bool PageLoaded
        {
            get { return pageLoaded; }
        }

        /// <summary>
        /// Creates a new Instance of a Website to crawl
        /// </summary>
        /// <param name="Address">Initial Address to navigate to</param>
        public WebSite(string Address)
        {
            browser = new WebBrowser();
            browser.DocumentCompleted += Browser_DocumentCompleted;
            browser.ScriptErrorsSuppressed = true;
            navigateTo(Address);

        }
        /// <summary>
        /// Navigates to a specified address
        /// </summary>
        /// <param name="address">Address to navigate to</param>
        protected void navigateTo(string address)
        {
            pageLoaded = false;
            requestHandler = new RequestHandler(address);
            browser.DocumentStream = requestHandler.Stream;
            pageLoaded = requestHandler.Successfull;
        }

        protected abstract void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e);
    }
}
