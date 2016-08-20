using System;
using System.Windows.Forms;

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
    }
}
