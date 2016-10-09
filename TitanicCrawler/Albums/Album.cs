using System.ComponentModel;
using System.Web.Script.Serialization;
using MongoDB.Bson;


namespace TitanicCrawler.Albums
{
    public abstract class Album
    {
        private string artist;
        private string album;

        /// <summary>
        /// Creates a new Album class which takes all 6 arguments
        /// </summary>
        /// <param name="artist">The artist name of the album</param>
        /// <param name="albumTitle">The title of the album</param>
        protected Album(string artist, string albumTitle)
        {
            Artist = artist;
            AlbumTitle = albumTitle;
        }

        public Album(BsonDocument albumDocuement)
        {
            Artist = albumDocuement["Artist"].ToString();
            AlbumTitle = albumDocuement["Album"].ToString();
        }


        /// <summary>
        /// The artist name of the album
        /// </summary>
        [DisplayName("Artist")]
        public string Artist
        {
            get { return artist; }
            set { artist = value; }
        }

        /// <summary>
        /// The title of the album
        /// </summary>
        [DisplayName("Album Title")]
        public string AlbumTitle
        {
            get { return album; }
            set { album = value; }
        }
        /// <summary>
        /// Returns a JSON string of the object
        /// </summary>
        /// <returns></returns>
        public string toJSON()
        {
            return new JavaScriptSerializer().Serialize(this);
        }

        /// <summary>
        /// Returns a BSON Representation of the Album Object
        /// </summary>
        /// <returns>BSON representation of Album</returns>
        public abstract BsonDocument BsonDocument
        {
            get;
        }
    }
}
