using System;
using System.Windows.Forms;
using TitanicCrawler;

namespace TesterApplication
{
    public partial class Form1 : Form
    {
        private Billboard billBoard;
        public Form1()
        {
            InitializeComponent();
            billBoard = new Billboard();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            billBoard.harvestAlbums();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("ChartPosition", "#");
            dataGridView1.Columns.Add("Artist", "Artist");
            dataGridView1.Columns.Add("Albums", "Albums");
            for (int i = 0; i <billBoard.Albums.Count; i++)
            {
                object[] tmp = {i+1, billBoard.Albums[i].Artist.ToString(), billBoard.Albums[i].AlbumTitle.ToString() };
                dataGridView1.Rows.Add(tmp);
            }
        }
    }
}
