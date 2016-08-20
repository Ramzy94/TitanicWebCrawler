using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TitanicCrawler;

namespace TesterApplication
{
    class Billboard:WebSite
    {
        private List<Album> albums = new List<Album>();

        /// <summary>
        /// Creats new Billboard Music Objects
        /// </summary>
        public Billboard():base("http://www.billboard.com/charts/billboard-200")
        {
            
        }

        internal List<Album> Albums
        {
            get { return albums;}
            set{albums = value;}
        }
        /// <summary>
        /// Extracts Billboard200 Albums from the HTMLDocument. Should only be called after base class browser.DocumentCompleted event has fired.
        /// </summary>
        public void processBillboard200()
        {
            string theArtist = "";
            int position = 0;
            int previous = 0;
            int peakPosition = 0;
            int weeks = 0;

            HtmlElementCollection rawData = base.document.GetElementsByTagName("article");
            for (int i = 0; i < rawData.Count; i++)
            {
                HtmlElement element = rawData[i];
                if (element.GetAttribute("className").StartsWith("chart-row"))
                {
                    HtmlElementCollection albums = element.GetElementsByTagName("h2");
                    HtmlElementCollection artists = element.GetElementsByTagName("a");
                    HtmlElementCollection altArtists = element.GetElementsByTagName("h3");
                    HtmlElementCollection chartPosition = element.GetElementsByTagName("span");
                    HtmlElementCollection peak = element.GetElementsByTagName("div");

                    for (int k = 0; k < chartPosition.Count; k++)
                    {
                        if(chartPosition[k].GetAttribute("className") == "chart-row__current-week")
                            position = Convert.ToInt32(chartPosition[k].InnerHtml);
                        if(chartPosition[k].GetAttribute("className") == "chart-row__last-week")
                        {
                            string[] a = chartPosition[k].InnerHtml.Split(':');
                            if (!(a[1].Trim() == "--"))
                                previous = Convert.ToInt32(a[1].Trim());
                            else
                                previous = 0;
                        }   
                    }
                    for(int j = 0; j < peak.Count; j++)
                    {
                        if(peak[j].GetAttribute("className")== "chart-row__top-spot")
                        {
                            HtmlElementCollection realPeak = peak[j].GetElementsByTagName("span");
                            peakPosition = Convert.ToInt32(realPeak[1].InnerHtml.Trim());
                        }else
                        if (peak[j].GetAttribute("className") == "chart-row__weeks-on-chart")
                        {
                            HtmlElementCollection realWeeks = peak[j].GetElementsByTagName("span");
                            weeks = Convert.ToInt32(realWeeks[1].InnerHtml.Trim());
                        }
                    }

                    if(artists[0].InnerHtml.Trim().Contains("<i"))
                        theArtist = altArtists[0].InnerHtml.Trim();
                    else
                        theArtist = artists[0].InnerHtml.Trim();

                    Albums.Add(new Album(position, theArtist, albums[0].InnerHtml,peakPosition,previous,weeks));
                }
            }   
        }
        #region Inner Album Class for storing Album Objects
        public class Album
        {
            private string artist;
            private string album;
            private int postion;
            private int peakPostion;
            private int prevPosition;
            private int weeks;

            /// <summary>
            /// Creates a new Album class which takes all 8 arguments
            /// </summary>
            /// <param name="Position">The current chart position of the albums</param>
            /// <param name="artist">The artist name of the album</param>
            /// <param name="albumTitle">The title of the album</param>
            /// <param name="Peakposition">The albums highest postion on the billboard 200 charts</param>
            /// <param name="Previous">The album's chart position for the previous week</param>
            /// <param name="Weeks">The collective number of weeks the album has been on the charts</param>
            public Album(int Position,string artist, string albumTitle,int Peakposition, int Previous,int Weeks)
            {
                PostionOnChart = Position;
                Artist = artist;
                AlbumTitle = albumTitle;
                PeakPostion = Peakposition;
                PositionPreviousWeek = Previous;
                WeeksOnChart = Weeks;
            }
            /// <summary>
            /// The artist name of the album
            /// </summary>
            public string Artist
            {
                get {return artist;}
                set{artist = value;}
            }
            /// <summary>
            /// The title of the album
            /// </summary>
            public string AlbumTitle
            {
                get {return album;}
                set{album = value;}
            }
            /// <summary>
            /// The albums highest postion on the billboard 200 charts
            /// </summary>
            public int PostionOnChart
            {
                get{return postion;}
                set{postion = value;}
            }
            /// <summary>
            /// The collective number of weeks the album has been on the charts
            /// </summary>
            public int WeeksOnChart
            {
                get{return weeks;}
                set{weeks = value;}
            }
            /// <summary>
            /// The album's chart position for the previous week
            /// </summary>
            public int PositionPreviousWeek
            {
                get{return prevPosition;}
                set{prevPosition = value;}
            }
            /// <summary>
            /// The albums highest postion on the billboard 200 charts
            /// </summary>
            public int PeakPostion
            {
                get{return peakPostion;}
                set{peakPostion = value;}
            }
        }
        #endregion

    }
}
