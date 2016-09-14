using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TitanicCrawler.Albums;

namespace TitanicCrawler.Websites
{
    public class Metacritic:WebSite
    {
        private List<MetacriticAlbum> albums = new List<MetacriticAlbum>();
        public Metacritic():base("http://www.metacritic.com/browse/albums/score/metascore/all/filtered?sort=desc")
        {
            
        }

        public List<MetacriticAlbum> Albums
        {
            get
            {
                return albums;
            }

            set
            {
                albums = value;
            }
        }

        public void processRatings() {
            string theArtist="", theAlbum="";
            double userRating=0;
            int metaRating=0;

            MetacriticAlbum metaAlbum;

            HtmlElementCollection rawData = document.GetElementsByTagName("div");
            foreach(HtmlElement albumField in rawData)
            {
                if(albumField.GetAttribute("className").StartsWith("product_row release"))
                {
                    userRating = Convert.ToInt32(albumField.GetElementsByTagName("span")[1].InnerHtml);

                    theArtist = albumField.GetElementsByTagName("a")[1].InnerHtml;
                    theAlbum = albumField.GetElementsByTagName("a")[0].InnerHtml;

                    HtmlElementCollection collection = albumField.GetElementsByTagName("div");

                    foreach (HtmlElement element in collection)
                    {
                        if (element.GetAttribute("className").StartsWith("metascore"))
                        {
                            metaRating = int.Parse(element.InnerHtml);
                        }
                        userRating = int.Parse(element.GetElementsByTagName("span")[1].InnerHtml);

                        theArtist = element.GetElementsByTagName("a")[1].InnerHtml;
                        theAlbum = element.GetElementsByTagName("a")[0].InnerHtml;
                    }
                    metaAlbum = new MetacriticAlbum(theArtist, theAlbum, metaRating, userRating);
                    Albums.Add(metaAlbum);
                }
            }
        }

        protected override void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            base.document = base.browser.Document;
            links = document.Links;
            MessageBox.Show("Metacritic Loaded");
        }
    }
}
