using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TesterApplication.Forms
{
    public partial class ViewData : UserControl
    {
        public ViewData()
        {
            InitializeComponent();
            dataChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            dataChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
        }

        public void perfectAlbum()
        {
            Series dataSeries = new Series();

            dataSeries.ChartType = SeriesChartType.Point;
            Color color = new Color();

            Random rndm = new Random();
            for(int i =0;i<=20; i++)
            {
                DataPoint point = new DataPoint(rndm.NextDouble() * 10, rndm.NextDouble() * 20);
                point.Color = Color.FromArgb(rndm.Next(256), rndm.Next(256), rndm.Next(256));
                point.Label = rndm.Next().ToString();
                dataSeries.Points.Add(point);
            }
            dataChart.Series.Clear();
            dataChart.Series.Add(dataSeries);
        }

        public void underratedAlbum()
        {

        }

        public void overratedAlbum()
        {

        }

        private void dataSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch((sender as ComboBox).SelectedIndex)
            {
                case 0:perfectAlbum();break;
                case 1:underratedAlbum();break;
                case 2:overratedAlbum();break;
            }
        }
    }
}
