using System;
using TitanicCrawler.Websites;
using TitanicCrawler.Albums;
using TesterApplication.DatabaseConnections;
using System.Windows.Forms;

namespace TesterApplication.Forms
{
    public partial class Crawler : UserControl
    {
        private Billboard billBoard;
        private Metacritic metacritic;
        private MongoConnection mongo = new MongoConnection(1);

        public Billboard BillBoard
        {
            get { return billBoard; }
            set { billBoard = value; }
        }

        public Metacritic Metacritic
        {
            get { return metacritic; }
            set { metacritic = value; }
        }

        public Crawler()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void fancyButton1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 1: billBoard = new Billboard(); break;
                case 0: metacritic = new Metacritic(); break;
                default: MessageBox.Show("Make A Selection"); break;
            }
        }

        private void btnBillboard_Click(object sender, EventArgs e)
        {
            billBoard.processBillboard200();

            dataGridView1.DataSource = billBoard.Albums;

            for (int col = 0; col < dataGridView1.Columns.Count; col++)
                dataGridView1.AutoResizeColumn(col);
        }

        private void btnMetacritic_Click(object sender, EventArgs e)
        {
            metacritic.processRatings();

            dataGridView1.DataSource = metacritic.Albums;

            for (int col = 0; col < dataGridView1.Columns.Count; col++)
                dataGridView1.AutoResizeColumn(col);
        }

        private void btnMongo_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (BillboardAlbum bAlbum in billBoard.Albums)
                    mongo.insert(bAlbum);

                foreach (MetacriticAlbum mAlbum in metacritic.Albums)
                    mongo.insert(mAlbum);

            }
            catch(NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnOracle_Click(object sender, EventArgs e)
        {

        }
    }
}
