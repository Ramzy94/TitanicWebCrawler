using System.Collections.Generic;
using System.Windows.Forms;

namespace TitanicCrawler.Websites
{
    public abstract class WebSite
    {
        private RequestHandler requestHandler;
        protected HtmlDocument document;
        protected Stack<HtmlElement> links;
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
        }

        protected void loadDocument()
        {
            document = requestHandler.Browser.Document;

            links = new Stack<HtmlElement>();

            for (int i = document.Links.Count-1; i > 0; i--)
            {
                links.Push(document.Links[i]);
            }        
        }
    }
}
