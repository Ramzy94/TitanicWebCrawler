using System.Collections.Generic;
using System.Windows.Forms;
using TitanicCrawler;

namespace TesterApplication
{
    class Billboard:WebSite
    {
        private List<Album> albums = new List<Album>();

        public Billboard():base("http://www.billboard.com/charts/billboard-200")
        {
            
        }

        internal List<Album> Albums
        {
            get { return albums;}
            set{albums = value;}
        }

        public void harvestAlbums()
        {
            HtmlElementCollection rawData = base.document.GetElementsByTagName("article");
            for (int i = 0; i < rawData.Count; i++)
            {
                HtmlElement element = rawData[i];
                if (element.GetAttribute("className").StartsWith("chart-row"))
                {
                    HtmlElementCollection albums = element.GetElementsByTagName("h2");
                    HtmlElementCollection artists = element.GetElementsByTagName("a");
                    HtmlElementCollection altArtists = element.GetElementsByTagName("h3");

                    foreach (HtmlElement h2 in albums)
                    {
                        string theArtist = "";
                        if (artists[0].InnerHtml.Trim().Contains("<i"))
                            theArtist = altArtists[0].InnerHtml.Trim();
                        else
                            theArtist = artists[0].InnerHtml.Trim();

                        this.Albums.Add(new Album(theArtist, h2.InnerHtml));
                    }
                }

            }   
        }

    public class Album
        {
            private string artist;
            private string album;

            public Album (string artist,string albumTitle)
            {
                this.Artist = artist;
                this.AlbumTitle = albumTitle;
            }

            public string Artist
            {
                get {return artist;}
                set{artist = value;}
            }

            public string AlbumTitle
            {
                get {return album;}
                set{album = value;}
            }
        }

    }
}
