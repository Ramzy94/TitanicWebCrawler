﻿using System;
using System.ComponentModel;
using MongoDB.Bson;

namespace TitanicCrawler.Albums
{
    public class MetacriticAlbum:Album
    {
        private int metaScore;
        private double userScore;

        /// <summary>
        /// Creates a new Album class which takes all 4 arguments 
        /// </summary>
        /// <param name="albumTitle">The title of the album</param>
        /// <param name="artist">The artist name of the album</param>
        /// <param name="metaScore">The Rating of The Album according to Metacritic</param>
        /// <param name="userScore">The Rating of The Album according to users of Metacritic</param>
        public MetacriticAlbum(string artist, string albumTitle, int metaScore, double userScore):base(artist,albumTitle)
        {
            MetaScore = metaScore;
            UserScore = userScore;
        }

        /// <summary>
        /// Creates a new Album object from a BSON Document
        /// </summary>
        /// <param name="albumDoc"></param>
        public MetacriticAlbum(BsonDocument albumDoc):base(albumDoc)
        {
            MetaScore = Convert.ToInt32(albumDoc["Metascore"].ToString());
            UserScore = Convert.ToDouble(albumDoc["Userscore"].ToString());
        }

        /// <summary>
        /// The Rating of The Album according to Metacritic
        /// </summary>
        [DisplayName("Metascore")]
        public int MetaScore
        {
            get { return metaScore; }
            set { metaScore = value; }
        }

        /// <summary>
        /// The Rating of The Album according to users of Metacritic
        /// </summary>
        [DisplayName("Userscore")]
        public double UserScore
        {
            get { return userScore; }
            set { userScore = value; }
        }


        /// <summary>
        /// Returns a BSON Representation of the Album Object
        /// </summary>
        /// <returns>BSON representation of Album</returns>
        public override BsonDocument BsonDocument
        {
            get
            {
                return new BsonDocument()
            {
                { "Artist",Artist },
                { "Album",AlbumTitle },
                { "Metascore",MetaScore },
                { "Userscore",UserScore }
            };
            }
        }
    }
}
