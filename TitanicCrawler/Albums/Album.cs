namespace TitanicCrawler.Albums
{
    public class Album
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
        /// <summary>
        /// The artist name of the album
        /// </summary>
        public string Artist
        {
            get { return artist; }
            set { artist = value; }
        }
        /// <summary>
        /// The title of the album
        /// </summary>
        public string AlbumTitle
        {
            get { return album; }
            set { album = value; }
        }
    }
}
