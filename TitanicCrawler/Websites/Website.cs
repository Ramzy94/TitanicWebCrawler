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
        private string webAddress;

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
            webAddress = Address;
            browser = new WebBrowser();
            browser.DocumentCompleted += Browser_DocumentCompleted;
            browser.ScriptErrorsSuppressed = true;
            navigateTo();
        }
        /// <summary>
        /// Navigates to a specified address
        /// </summary>
        protected void navigateTo()
        {
            pageLoaded = false;
            requestHandler = new RequestHandler(webAddress);
            browser.DocumentStream = requestHandler.HTMLDocument;
            pageLoaded = requestHandler.Successfull;
        }

        public void getDocument()
        {
            
            document = browser.Document;
            links = document.Links;
        }

        protected abstract void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e);
    }
}
