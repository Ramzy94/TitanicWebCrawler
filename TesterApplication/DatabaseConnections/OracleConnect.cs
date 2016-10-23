using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using TesterApplication.audioAlbumsTableAdapters;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TitanicCrawler.Albums;

namespace TesterApplication.DatabaseConnections
{
    class OracleConnect
    {
        private OracleConnection oConnection;
        private OracleDataAdapter oAdapter;
        private OracleCommand oCommand;
        private string sqlQuery;
        private DataTable table = new DataTable();
        private TableAdapterManager manager;
        private audioAlbums dataSet;

        public DataTable Table
        {
            set { table = value; }
            get { return table; }
        }

        public OracleConnect()
        {
            oConnection = new OracleConnection("DATA SOURCE=127.0.0.1:1521/xe;PASSWORD=tss;USER ID=TSS");
            manager = new TableAdapterManager();

            manager.Connection = oConnection;
            dataSet = new audioAlbums();
            fillData();
            
        }

        public void fillData()
        {
            manager.ALBUMTableAdapter = new ALBUMTableAdapter();
            manager.ALBUMTableAdapter.Fill(dataSet.ALBUM);

            manager.ARTISTTableAdapter = new ARTISTTableAdapter();
            manager.ARTISTTableAdapter.Fill(dataSet.ARTIST);

            manager.CHARTTableAdapter = new CHARTTableAdapter();
            manager.CHARTTableAdapter.Fill(dataSet.CHART);

            manager.RATINGTableAdapter = new RATINGTableAdapter();
            manager.RATINGTableAdapter.Fill(dataSet.RATING);
        }

        public int lastInserted()
        {
            sqlQuery = "select AUTO_INCREMENT.currval from user_sequences;";

            oConnection.Open();
            oCommand = new OracleCommand(sqlQuery, oConnection);

            oAdapter = new OracleDataAdapter(oCommand);
            oCommand.ExecuteNonQuery();

            oAdapter.Fill(table);
            oConnection.Close();

            return Convert.ToInt32(table.Rows[0][0]);
        }

        public void insertAlbum(Album album)
        {
            try
            {
                if (album is MetacriticAlbum)
                {
                    MetacriticAlbum aLbum = (MetacriticAlbum)album;
                    manager.RATINGTableAdapter.Insert(1, aLbum.MetaScore, (decimal)aLbum.UserScore, DateTime.Now);
                    updateDataSet();
                    fillData();

                    int ratingsID = lastInserted();

                    manager.ARTISTTableAdapter.Insert(1, aLbum.Artist, null);
                    updateDataSet();
                    fillData();

                    int artistID = lastInserted();

                    manager.ALBUMTableAdapter.Insert(1, aLbum.AlbumTitle, null, null, artistID, (decimal)ratingsID, null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+"\nHo Rough");
            }
        }

        public void updateDataSet()
        {
            manager.UpdateAll(dataSet);
        }
    }
}
