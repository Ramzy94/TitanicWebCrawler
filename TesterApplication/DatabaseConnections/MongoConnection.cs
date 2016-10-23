using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
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
                collection = mongoDatabase.GetCollection<BsonDocument>("Metacritic");
                document = metaAlbum.BsonDocument;
            }
            else if (album is BillboardAlbum)
            {
                BillboardAlbum album200 = (BillboardAlbum)album;
                collection = mongoDatabase.GetCollection<BsonDocument>("Billboard200");
                document = album200.BsonDocument;
            }
            else
                throw new ArgumentException("Invalid argument passed to method");
            
            collection.InsertOne(document);
        }

        public List<MetacriticAlbum> getMetacritic()
        {

            collection = mongoDatabase.GetCollection<BsonDocument>("Metacritic");
            List<BsonDocument> documents = collection.Find<BsonDocument>(_ => true).ToList<BsonDocument>();
            List<MetacriticAlbum> albums = new List<MetacriticAlbum>();
            foreach (BsonDocument doc in documents)
                albums.Add(new MetacriticAlbum(doc));
            return albums;
        }


        public List<BillboardAlbum> getBillboard()
        {
            collection = mongoDatabase.GetCollection<BsonDocument>("Billboard200");
            List<BsonDocument> documents = collection.Find<BsonDocument>(_ => true).ToList<BsonDocument>();
            List<BillboardAlbum> albums = new List<BillboardAlbum>();
            foreach (BsonDocument doc in documents)
                albums.Add(new BillboardAlbum(doc));
            return albums;
        }



        public void close()
        {
            client = null;
        }

    }
}