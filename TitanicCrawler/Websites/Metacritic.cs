﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TitanicCrawler.Albums;

namespace TitanicCrawler.Websites
{
    public class Metacritic : WebSite
    {
        private List<MetacriticAlbum> albums = new List<MetacriticAlbum>();
        private int page = 1;
        public Metacritic() : base("http://www.metacritic.com/browse/albums/score/metascore/all/filtered?sort=desc&page=100")
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

            string artist = "";
            string album = "";
            int metaRating = 0;
            double userRating = 0;
            MetacriticAlbum objAlbum;
            Albums.Clear();

            foreach (HtmlDocument document in documents)
            {

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
                            userRating = 0;
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
            {
                if (documents.Count == 0)
                    documents.Add(browser.Document);

                for (int i = 0; i < documents.Count; i++)
                {
                    try
                    {
                        if (!ReferenceEquals(browser.Document.Body.InnerHtml, null))
                            if (documents[i].Body == browser.Document.Body)
                                documents[i] = browser.Document;
                            else
                            if (i + 1 == documents.Count)
                                documents.Add(browser.Document);
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("The value is indeed null");
                    }
                }
                Console.WriteLine(documents.Count);
                requestHandler.nullify();
                browser.Dispose();
                browser = null;
                if (documents.Count < 50)
                {
                    WebAddress = "http://www.metacritic.com/browse/albums/score/metascore/all/filtered?sort=desc&page=" + (100+documents.Count).ToString();
                    navigateTo();
                    //page++;
                }
            }
        }
    }
}