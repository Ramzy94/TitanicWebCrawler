using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TitanicCrawler.Albums;


namespace TitanicCrawler.Websites
{
    public class Metacritic : WebSite
    {
        private List<MetacriticAlbum> albums = new List<MetacriticAlbum>();
        private int page = 1;
        public Metacritic() : base("http://www.metacritic.com/browse/albums/score/metascore/all/filtered?sort=desc")
        {

        }

        /// <summary>
        /// A List of Albums on Metacritic
        /// </summary>
        public List<MetacriticAlbum> Albums
        {
            get { return albums; }
        }

        public void processRatings()
        {
            //base.getDocument();

            string artist = "";
            string album = "";
            int metaRating = 0;
            double userRating = 0;
            MetacriticAlbum objAlbum;

            foreach(HtmlDocument document in documents) { 

            HtmlElementCollection rawData = document.GetElementsByTagName("div");
                for (int i = 0; i < rawData.Count; i++)
                {
                    if (rawData[i].GetAttribute("className").StartsWith("product_row release"))
                    {
                        HtmlElementCollection AlbumData = rawData[i].GetElementsByTagName("div");

                        for (int k = 0; k < AlbumData.Count; k++)
                            if (AlbumData[k].GetAttribute("className").StartsWith("metascore"))
                                metaRating = Convert.ToInt32(AlbumData[k].InnerHtml);

                        AlbumData = rawData[i].GetElementsByTagName("a");
                        album = AlbumData[0].InnerHtml;
                        artist = AlbumData[1].InnerHtml;

                        AlbumData = rawData[i].GetElementsByTagName("span");
                        if (!(AlbumData[1].InnerHtml == "tbd"))
                            userRating = Convert.ToDouble(AlbumData[1].InnerHtml);
                        else
                            userRating = 0;

                        objAlbum = new MetacriticAlbum(artist, album, metaRating, userRating);
                        albums.Add(objAlbum);
                    }
                }
            }
        }
        

        protected override void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // ((sender as WebBrowser).ReadyState == WebBrowserReadyState.Complete)
            {
                if (documents.Count == 0)
                    documents.Add(browser.Document);

                for (int i = 0; i < documents.Count; i++)
                {

                    if (documents[i] == browser.Document)
                        documents[i] = browser.Document;
                    else
                    if (i + 1 == documents.Count)
                        documents.Add(browser.Document);
                }
                Console.WriteLine(documents.Count);
                requestHandler.nullify();
                if (page < 21)
                {
                    WebAddress = "http://www.metacritic.com/browse/albums/score/metascore/all/filtered?sort=desc&page=" + page.ToString();
                    navigateTo();
                    page++;
                }
            }
        }
    }
}
