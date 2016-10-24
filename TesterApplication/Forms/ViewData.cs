using System;
using System.Drawing;
using System.Windows.Forms;
using TitanicCrawler.Albums;
using TesterApplication.DatabaseConnections;
using System.Windows.Forms.DataVisualization.Charting;

namespace TesterApplication.Forms
{
    public partial class ViewData : UserControl
    {
        private MetacriticAlbum[] metaArray;
        public ViewData()
        {
            InitializeComponent();
            dataChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            dataChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
        }

        public void sorting()
        {
            metaArray = new MetacriticAlbum[OracleConnect.dataAlbums.Count];

            for(int i=0;i<metaArray.Length;i++)
            {
                metaArray[i] = OracleConnect.dataAlbums[i];
            }

            for(int i=0; i<metaArray.Length-1;i++)
                for(int j=i+1;j<metaArray.Length;j++)
                {
                    if(metaArray[j].MetaScore>metaArray[i].MetaScore)
                    {
                        MetacriticAlbum tmp = metaArray[i];
                        metaArray[i] = metaArray[j];
                        metaArray[j] = tmp;
                    }
                }
            foreach (MetacriticAlbum ass in metaArray)
                Console.WriteLine(ass.MetaScore);
        }

        public void perfectAlbum()
        {
            sorting();

            bill = new MongoConnection(1).getBillboard();

            Series dataSeries = new Series();

            dataSeries.ChartType = SeriesChartType.Point;

            Random rndm = new Random();
            for (int i = 0; i <= 20; i++)
            {
                foreach (BillboardAlbum bilboard in bill)
                {
                    if (metaArray[i].AlbumTitle.Trim().Equals(bilboard.AlbumTitle.Trim()))
                    {
                        DataPoint point = new DataPoint(metaArray[i].MetaScore, bilboard.WeeksOnChart);
                        point.Color = Color.FromArgb(rndm.Next(256), rndm.Next(256), rndm.Next(256));
                        point.Label = bilboard.Artist + "-" + bilboard.AlbumTitle;
                        dataSeries.Points.Add(point);
                    }
                }
                dataChart.Series.Clear();
                dataChart.Series.Add(dataSeries);
            }
        }

        public void underratedAlbum()
        {
            sorting();

            bill = new MongoConnection(1).getBillboard();

            Series dataSeries = new Series();

            dataSeries.ChartType = SeriesChartType.Point;

            Random rndm = new Random();
            for (int i = metaArray.Length-1; i >=metaArray.Length-20; i--)
            {
                foreach (BillboardAlbum bilboard in bill)
                {
                    if (metaArray[i].AlbumTitle.Trim().Equals(bilboard.AlbumTitle.Trim()))
                    {
                        DataPoint point = new DataPoint(metaArray[i].MetaScore, bilboard.WeeksOnChart);
                        point.Color = Color.FromArgb(rndm.Next(256), rndm.Next(256), rndm.Next(256));
                        point.Label = bilboard.Artist + "-" + bilboard.AlbumTitle;
                        dataSeries.Points.Add(point);
                    }
                }
                dataChart.Series.Clear();
                dataChart.Series.Add(dataSeries);
            }
        }

        public void overratedAlbum()
        {
            sorting();

            bill = new MongoConnection(1).getBillboard();

            Series dataSeries = new Series();

            dataSeries.ChartType = SeriesChartType.Point;

            Random rndm = new Random();
            for (int i = metaArray.Length - 1; i >= metaArray.Length - 20; i--)
            {
                foreach (BillboardAlbum bilboard in bill)
                {
                    if (metaArray[i].AlbumTitle.Trim().Equals(bilboard.AlbumTitle.Trim()))
                    {
                        DataPoint point = new DataPoint(metaArray[i].MetaScore, 200-bilboard.PostionOnChart);
                        point.Color = Color.FromArgb(rndm.Next(256), rndm.Next(256), rndm.Next(256));
                        point.Label = bilboard.Artist + "-" + bilboard.AlbumTitle;
                        dataSeries.Points.Add(point);
                    }
                }
                dataChart.Series.Clear();
                dataChart.Series.Add(dataSeries);
            }
        }

        private void dataSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch((sender as ComboBox).SelectedIndex)
            {
                case 0:perfectAlbum();break;
                case 2:underratedAlbum();break;
                case 1:overratedAlbum();break;
            }
        }
    }
}
