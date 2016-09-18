using System;
using System.Windows.Forms;

namespace TitanicCrawler
{
    /// <summary>
    /// Class To Handle webrequests for the crawler
    /// </summary>
    class RequestHandler
    {
        private WebBrowser browser;
        private bool completed = false;

        public RequestHandler(string address)
        {

            browser = new WebBrowser();
            Browser.ScriptErrorsSuppressed = true;

            Browser.Navigated += Browser_Navigated;

            try
            {
                Browser.Navigate(address);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public WebBrowser Browser
        {
            get { return browser; }
        }

        public bool Completed
        {
            get { return completed; }
        }

        private void Browser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (!Browser.IsBusy)
            {
                Browser.Stop();
                MessageBox.Show("Completed");
                completed = true;
                browser.Dispose();
            }
        }
    }
}
