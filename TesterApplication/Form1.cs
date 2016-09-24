using System;
using System.Windows.Forms;
using TitanicCrawler.Websites;
using TesterApplication.DatabaseConnections;

namespace TesterApplication
{
    public partial class Form1 : Form
    {
        private Billboard billBoard;
        private Metacritic metacritic;
        private MongoConnection mongo = new MongoConnection(0);       
        public Form1()
        {
            InitializeComponent();
        }
        
        private void btn200_Click(object sender, EventArgs e)
        {
            billBoard.processBillboard200();

            dataGridView1.DataSource = billBoard.Albums;

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

            dataGridView1.DataSource = metacritic.Albums;

            for (int column = 0; column < dataGridView1.ColumnCount; column++)
                dataGridView1.AutoResizeColumn(column);
        }
    }
}
