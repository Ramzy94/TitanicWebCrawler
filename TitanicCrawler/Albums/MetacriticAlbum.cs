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

        public override BsonDocument getBSON()
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
