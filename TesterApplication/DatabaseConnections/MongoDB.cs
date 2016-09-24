using MongoDB.Driver;
using MongoDB.Bson;
using TitanicCrawler.Albums;
using System;

namespace TesterApplication.DatabaseConnections
{
    public class MongoDB
    {
        private MongoClient client;
        private IMongoDatabase mongoDatabase;
        private IMongoCollection<BsonDocument> collection;
        private BsonDocument document;

        public MongoDB(int option)
        {
            switch (option)
            {
                case 0: { client = new MongoClient("mongodb://Titanic:password@ds147975.mlab.com:47975/audioalbums"); break; }
                case 1: { client = new MongoClient("mongodb://localhost:27017"); break; }
            }

            mongoDatabase = client.GetDatabase("audioalbums");
            
        }

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