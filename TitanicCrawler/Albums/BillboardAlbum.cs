using System.ComponentModel;

namespace TitanicCrawler.Albums
{
    public class BillboardAlbum:Album
    {
        private int postion;
        private int peakPostion;
        private int prevPosition;
        private int weeks;
        private string imgHref;

        /// <summary>
        /// Creates a new Album class which takes all 6 arguments
        /// </summary>
        /// <param name="Position">The current chart position of the albums</param>
        /// <param name="artist">The artist name of the album</param>
        /// <param name="albumTitle">The title of the album</param>
        /// <param name="Peakposition">The albums highest postion on the billboard 200 charts</param>
        /// <param name="Previous">The album's chart position for the previous week</param>
        /// <param name="Weeks">The collective number of weeks the album has been on the charts</param>
        /// <param name="Image">The path to the album cover art image</param>
        public BillboardAlbum(int Position, string artist, string albumTitle, int Peakposition, int Previous, int Weeks, string Image):base(artist, albumTitle)
        {
            PostionOnChart = Position;
            Artist = artist;
            AlbumTitle = albumTitle;
            peakPostion = Peakposition;
            PositionPreviousWeek = Previous;
            WeeksOnChart = Weeks;
            ImagePath = Image;
        }

        /// <summary>
        /// The albums current postion on the billboard 200 charts
        /// </summary>
        [DisplayName("Chart Position")]
        public int PostionOnChart
        {
            get { return postion; }
            set { postion = value; }
        }

        /// <summary>
        /// The collective number of weeks the album has been on the charts
        /// </summary>
        [DisplayName("Weeks On Chart")]
        public int WeeksOnChart
        {
            get { return weeks; }
            set { weeks = value; }
        }

        /// <summary>
        /// The album's chart position for the previous week
        /// </summary>
        [DisplayName("Previous Chart Position")]
        public int PositionPreviousWeek
        {
            get { return prevPosition; }
            set { prevPosition = value; }
        }

        /// <summary>
        /// The albums highest postion on the billboard 200 charts
        /// </summary>
        [DisplayName("Peak Chart Position")]
        public int PeakPostion
        {
            get { return peakPostion; }
            set { peakPostion = value; }
        }

        [DisplayName("Image Link")]
        public string ImagePath
        {
            get { return imgHref; }
            set { imgHref = value; }
        }
    }
}
