using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitanicCrawler.Websites;
using System.Windows.Forms;

namespace TesterApplication.Forms
{
    public partial class Crawler : UserControl
    {
        public Billboard billBoard;
        public Metacritic metacritic;
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
                default: MessageBox.Show("make A Selection"); break;
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
    }
}
