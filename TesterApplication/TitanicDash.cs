using System;
using System.Windows.Forms;
using TitanicCrawler.Websites;
using TesterApplication.DatabaseConnections;
using TitanicCrawler.Albums;

namespace TesterApplication
{
    public partial class TitanicDash : Form
    {
        private Billboard billBoard;
        private Metacritic metacritic;
        private MongoConnection mongo = new MongoConnection(1);       
        public TitanicDash()
        {
            InitializeComponent();
        }
        
        

        private void TitanicDash_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
