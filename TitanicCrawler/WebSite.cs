using System;
using System.Windows.Forms;

namespace TitanicCrawler
{
    public class WebSite
    {
        private RequestHandler requestHandler;
        protected HtmlDocument document;
        private WebBrowser browser;
        protected HtmlElementCollection links;

        public WebSite(string address)
        {
            browser = new WebBrowser();
            browser.DocumentCompleted += Browser_DocumentCompleted;
            requestHandler = new RequestHandler(address);
            browser.DocumentStream = requestHandler.Stream;
            browser.ScriptErrorsSuppressed = true;
            browser.Refresh();
        }

        private void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            document = browser.Document;
            links = document.Links;
            MessageBox.Show("Site Loaded");
        }
    }
}
