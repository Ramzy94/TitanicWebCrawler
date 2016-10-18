using System;
using System.Windows.Forms;
using TitanicCrawler.Websites;
using TesterApplication.Forms;
using TesterApplication.DatabaseConnections;

namespace TesterApplication
{
    public partial class TitanicDash : Form
    {
        private Billboard billBoard;
        private Metacritic metacritic;
        private MongoConnection mongo = new MongoConnection(1);
        private UserControl[] uControl = { new Crawler(), new Databases(), new ViewData() };
        private int form = 0;


        public TitanicDash()
        {
            InitializeComponent();
        }
        
 
        private void TitanicDash_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Add(uControl[form], 0, 0);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (form == 1)
                btnPrev.Enabled = false;
            else
            {
                form--;
                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel1.Controls.Add(uControl[form], 0, 0);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
           // if (form == 1)
                //btnNext.Enabled = false;
                
            //else
            {
                form++;
                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel1.Controls.Add(uControl[form], 0, 0);

                if(form==1)
                {
                    Crawler c = (Crawler)uControl[0];
                    billBoard = c.BillBoard;
                    metacritic = c.Metacritic;
                }
            }
        }
    }
}
