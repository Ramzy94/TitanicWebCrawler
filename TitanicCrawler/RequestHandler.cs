﻿using System.Net;
using System.IO;
using System.Windows.Forms;
using System;

namespace TitanicCrawler
{
    /// <summary>
    /// Class To Handle webrequests for the crawler
    /// </summary>
    class RequestHandler
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
            try
            {
                client = new WebClient();
                client.OpenReadCompleted += Client_OpenReadCompleted;
                // NO fuckung Idea what this does but it saved my bacon
                client.Headers.Add(HttpRequestHeader.UserAgent, "User - Agent: Mozilla / 5.0(Windows NT 6.1; WOW64; rv: 8.0) Gecko / 20100101 Firefox / 8.0");
                document = client.OpenRead(address);

                successfull = true;
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message + "Its This One Bra");
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message + "Entlek it's This One Bra");
            }
        }

        private void Client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            MessageBox.Show("good to go");
        }
    }
}
