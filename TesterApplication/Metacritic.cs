using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TitanicCrawler;
using TitanicCrawler.Albums;

namespace TesterApplication
{
    class Metacritic:WebSite
    {
        private List<MetacriticAlbum> albums = new List<MetacriticAlbum>();

        public Metacritic():base("http://www.metacritic.com/browse/albums/score/metascore/all/filtered?sort=desc")
        {
            
        }
        /// <summary>
        /// A List of Albums on Metacritic
        /// </summary>
        public List<MetacriticAlbum> Albums
        {
            get{return albums;}
        }

        public void processRatings()
        {
            string artist = "";
            string album = "";
            int metaRating = 0;
            double userRating = 0;
            MetacriticAlbum objAlbum;
            HtmlElementCollection rawData = document.GetElementsByTagName("div");
            for(int i=0;i<rawData.Count;i++)
            {
                if(rawData[i].GetAttribute("className").StartsWith("product_row release"))
                {
                    HtmlElementCollection AlbumData = rawData[i].GetElementsByTagName("div");

                    for (int k = 0; k < AlbumData.Count; k++)
                        if (AlbumData[k].GetAttribute("className").StartsWith("metascore"))
                            metaRating = Convert.ToInt32(AlbumData[k].InnerHtml);

                    AlbumData = rawData[i].GetElementsByTagName("a");
                    album = AlbumData[0].InnerHtml;
                    artist = AlbumData[1].InnerHtml;

                    AlbumData = rawData[i].GetElementsByTagName("span");
                    userRating = Convert.ToDouble(AlbumData[1].InnerHtml);

                    objAlbum = new MetacriticAlbum(artist, album, metaRating, userRating);
                    this.albums.Add(objAlbum);
                }
            }
        }

        protected override void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            pageLoaded = true;
            document = browser.Document;
            links = document.Links;
            MessageBox.Show("MetaCritic Loaded");
        }

    }
}
