using System;
using System.Windows.Forms;
using TitanicCrawler.Websites;
using TesterApplication.DatabaseConnections;

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

        private void btnPrev_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }
    }
}
