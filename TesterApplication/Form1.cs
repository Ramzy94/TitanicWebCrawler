using System;
using System.Windows.Forms;

namespace TesterApplication
{
    public partial class Form1 : Form
    {
        private Billboard billBoard;
        private Metacritic metacritic;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void btn200_Click(object sender, EventArgs e)
        {
            billBoard.processBillboard200();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("ChartPosition", "Current Chart Postion");
            dataGridView1.Columns.Add("Artist", "Artist");
            dataGridView1.Columns.Add("Albums", "Albums");
            dataGridView1.Columns.Add("Peak", "Peak Position");
            dataGridView1.Columns.Add("Prev", "Previous Position");
            dataGridView1.Columns.Add("Week", "Weeks On Charts");
            for (int i = 0; i <billBoard.Albums.Count; i++)
            {
                object[] tmp = { billBoard.Albums[i].PostionOnChart, billBoard.Albums[i].Artist, billBoard.Albums[i].AlbumTitle,billBoard.Albums[i].PeakPostion,billBoard.Albums[i].PositionPreviousWeek,billBoard.Albums[i].WeeksOnChart };
                dataGridView1.Rows.Add(tmp);
            }
            for (int column = 0; column < dataGridView1.ColumnCount; column++)
                dataGridView1.AutoResizeColumn(column);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            switch(cmbSites.SelectedIndex)
            {
                case 0:metacritic = new Metacritic();break;
                case 1:billBoard = new Billboard();break;
                default:MessageBox.Show("Make A Selection");break;
            }
        }

        private void btnMetacritic_Click(object sender, EventArgs e)
        {
            metacritic.processRatings();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Album", "Album Title");
            dataGridView1.Columns.Add("Artist", "Artist");
            dataGridView1.Columns.Add("Metascore", "Metascore");
            dataGridView1.Columns.Add("Userscore", "Userscore");
            for (int i = 0; i < metacritic.Albums.Count; i++)
            {
                object[] tmp = {metacritic.Albums[i].AlbumTitle,metacritic.Albums[i].Artist,metacritic.Albums[i].MetaScore,metacritic.Albums[i].UserScore};
                dataGridView1.Rows.Add(tmp);
            }
            for (int column = 0; column < dataGridView1.ColumnCount; column++)
                dataGridView1.AutoResizeColumn(column);
        }
    }
}
