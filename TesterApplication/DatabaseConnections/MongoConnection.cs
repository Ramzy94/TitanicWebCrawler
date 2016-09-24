﻿using MongoDB.Bson;
using MongoDB.Driver;
using System;
using TitanicCrawler.Albums;

namespace TesterApplication.DatabaseConnections
{
    public class MongoConnection
    {
        private MongoClient client;
        private IMongoDatabase mongoDatabase;
        private IMongoCollection<BsonDocument> collection;
        private BsonDocument document;


        /// <summary>
        /// Initialises a connection to a MongoDB Sever and gets the audioalbums Database 
        /// </summary>
        /// <param name="server">Selects the server to connect to. 1 connects to a localhost (127.0.0.1) server. Any other value connects to the mLab online server</param>
        public MongoConnection(int server)
        {
            switch (server)
            {
                case 0: { client = new MongoClient("mongodb://Titanic:password@ds147975.mlab.com:47975/audioalbums"); break; }
                case 1: { client = new MongoClient("mongodb://localhost:27017"); break; }
                default: { client = new MongoClient("mongodb://Titanic:password@ds147975.mlab.com:47975/audioalbums"); break; }
            }
            mongoDatabase = client.GetDatabase("audioalbums");
        }

        /// <summary>
        /// Inserts An Album Into the Selected MongoDB Database
        /// </summary>
        /// <param name="album">The Album object to be inserted</param>
        public void insert(Album album)
        {
            document = new BsonDocument();

            document.Add("Artist", BsonValue.Create(album.Artist));
            document.Add("Album", BsonValue.Create(album.AlbumTitle));

            if (album is MetacriticAlbum)
            {
                MetacriticAlbum metaAlbum = (MetacriticAlbum)album;
                document.Add("MetaScore", BsonValue.Create(metaAlbum.MetaScore));
                document.Add("UserScore", BsonValue.Create(metaAlbum.UserScore));
            }
            else if (album is BillboardAlbum)
            {
                BillboardAlbum album200 = (BillboardAlbum)album;
                document.Add("PostionOnChart", BsonValue.Create(album200.PostionOnChart));
                document.Add("PreviousPosition", BsonValue.Create(album200.PositionPreviousWeek));
                document.Add("PeakPostion", BsonValue.Create(album200.PeakPostion));
                document.Add("WeeksOnChart", BsonValue.Create(album200.WeeksOnChart));
            }
            else
                throw new ArgumentException("Invalid argument passed to method");

            collection = mongoDatabase.GetCollection<BsonDocument>("Billboard200");
            collection.InsertOne(document);
        }
    }
}