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

        public MongoDB()
        {
            client = new MongoClient("mongodb://localhost:27017");
            mongoDatabase = client.GetDatabase("TitanicBllboard");
            //mongoDatabase.CreateCollection("albums");

            collection = mongoDatabase.GetCollection<BsonDocument>("albums");

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

            collection.InsertOne(document);
        }

        public MongoClientSettings setUpConnection(int option)
        {
            MongoClientSettings settings = new MongoClientSettings();

            settings.ConnectionMode = ConnectionMode.Automatic;
            settings.Server = new MongoServerAddress("ds147975.mlab.com", 47975);
            settings.

            return new MongoClientSettings();
        }
    }
}