using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TitanicCrawler;

namespace TesterApplication
{
    class Metacritic:WebSite
    {
        private List<Album> albums = new List<Album>();

        public Metacritic():base("http://www.metacritic.com/browse/albums/score/metascore/all/filtered?sort=desc")
        {
            
        }
        /// <summary>
        /// A List of Albums on Metacritic
        /// </summary>
        public List<Album> Albums
        {
            get{return albums;}
        }

        public void processRatings()
        {
            string artist = "";
            string album = "";
            int metaRating = 0;
            double userRating = 0;
            Album objAlbum;
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

                    objAlbum = new Album(artist, album, metaRating, userRating);
                    this.albums.Add(objAlbum);
                }
            }
        }

        protected override void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            pageLoaded = true;
            document = base.browser.Document;
            links = document.Links;
            MessageBox.Show("MetaCritic Loaded");
        }

        #region Inner Album Class for storing Album Objects
        public class Album
        {
            private string artist;
            private string album;
            private int metaScore;
            private double userScore;

            /// <summary>
            /// Creates a new Album class which takes all 4 arguments 
            /// </summary>
            /// <param name="albumTitle">The title of the album</param>
            /// <param name="artist">The artist name of the album</param>
            /// <param name="metaScore">The Rating of The Album according to Metacritic</param>
            /// <param name="userScore">The Rating of The Album according to users of Metacritic</param>
            public Album(string artist, string albumTitle, int metaScore, double userScore)
            {
                Artist = artist;
                AlbumTitle = albumTitle;
                MetaScore = metaScore;
                UserScore = userScore;
            }
            /// <summary>
            /// The artist name of the album
            /// </summary>
            public string Artist
            {
                get { return artist; }
                set { artist = value; }
            }
            /// <summary>
            /// The title of the album
            /// </summary>
            public string AlbumTitle
            {
                get { return album; }
                set { album = value; }
            }
            /// <summary>
            /// The Rating of The Album according to Metacritic
            /// </summary>
            public int MetaScore
            {
                get {return metaScore;}
                set {metaScore = value;}
            }
            /// <summary>
            /// The Rating of The Album according to users of Metacritic
            /// </summary>
            public double UserScore
            {
                get {return userScore;}
                set {userScore = value;}
            }
        }
        #endregion
    }
}
