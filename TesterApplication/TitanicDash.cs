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
            btnNext.Text = "Databases";
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {

            form--;
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.Controls.Add(uControl[form], 0, 0);

            this.buttons(form);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            form++;
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.Controls.Add(uControl[form], 0, 0);

            this.buttons(form);

        }

        public void buttons(int formIndex)
        {
            switch(formIndex)
            {
                case 0:
                    {
                        btnNext.Enabled = true;
                        btnPrev.Enabled = false;

                        btnNext.Text = "Databases";
                        //btnPrev.Text = "Web Crawler";
                    } break;
                case 1:
                    {
                        btnNext.Enabled = true;
                        btnPrev.Enabled = true;

                        btnNext.Text = "View Data/Stats";
                        btnPrev.Text = "Web Crawler";

                        if (form == 1 && billBoard == null && metacritic == null)
                        {
                            Crawler c = (Crawler)uControl[0];
                            billBoard = c.BillBoard;
                            metacritic = c.Metacritic;
                        }
                    }
                    break;
                case 2:
                    {
                        btnNext.Enabled = false;
                        btnPrev.Enabled = true;

                        //btnNext.Text = "View Data/Stats";
                        btnPrev.Text = "Databases";
                    }
                    break;
            }
        }
    }
}
