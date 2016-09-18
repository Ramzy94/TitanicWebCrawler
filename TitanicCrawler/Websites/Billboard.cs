using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TitanicCrawler.Albums;

namespace TitanicCrawler.Websites
{
    public class Billboard:WebSite
    {
        private List<BillboardAlbum> albums = new List<BillboardAlbum>();

        /// <summary>
        /// Creats new Billboard Music Objects
        /// </summary>
        public Billboard():base("http://www.billboard.com/charts/billboard-200")
        {
            
        }

        /// <summary>
        /// A List of The Albums on the Billboard200
        /// </summary>
        public List<BillboardAlbum> Albums
        {
            get { return albums;}
        }

        /// <summary>
        /// Extracts Billboard200 Albums from the HTMLDocument. Should only be called after base class browser.DocumentCompleted event has fired.
        /// </summary>
        public void processBillboard200()
        {

            loadDocument();

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

                    Albums.Add(new BillboardAlbum(position, theArtist, albums[0].InnerHtml,peakPosition,previous,weeks));
                }
            }   
        }
    }
}
