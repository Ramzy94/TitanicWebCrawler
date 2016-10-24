using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using TesterApplication.audioAlbumsTableAdapters;
using System.Data;
using System.Windows.Forms;
using TitanicCrawler.Albums;

namespace TesterApplication.DatabaseConnections
{
    class OracleConnect
    {
        private OracleConnection oConnection;
        public static List<MetacriticAlbum> dataAlbums = new List<MetacriticAlbum>();
        private OracleDataAdapter oAdapter;
        private OracleCommand oCommand;
        private string sqlQuery;
        private DataTable table = new DataTable();
        private TableAdapterManager manager;
        private audioAlbums dataSet;
        int i = 0;

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
            sqlQuery = "select AUTO_INCREMENT.currval from user_sequences";

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
                #region Metacritic album
                if (album is MetacriticAlbum)
                {
                    List<BillboardAlbum> albumBill = new MongoConnection(1).getBillboard();

                    for (int i = 0; i < albumBill.Count; i++)
                        if (albumBill[i].AlbumTitle.Trim() == album.AlbumTitle.Trim())
                        {
                            Console.WriteLine(albumBill[i].AlbumTitle + "\t" + album.AlbumTitle);
                            MetacriticAlbum metaAlbum = (MetacriticAlbum)album;

                            

                            for (int io = 0; io < dataSet.ALBUM.Rows.Count; io++)
                            {
                                string q = dataSet.ALBUM.Rows[io][1].ToString();
                                Console.WriteLine(q);
                                if (q == metaAlbum.AlbumTitle)
                                    MessageBox.Show("sfb");
                            }

                            /*sqlQuery = "UPDATE ALBUM SET RATING_ID=:v0 WHERE ALBUM_NAME = :v1";

                            initCommand();
                            oCommand.BindByName = true;

                            oCommand.Parameters.Add(":v0", fk);
                            oCommand.Parameters.Add(":v1", metaAlbum.AlbumTitle.Trim());*/
                            //closeExecute();
                            updateDataSet();
                            fillData();

                        }

                }
                #endregion
                #region Billboard album
                else if (album is BillboardAlbum)
                {
                    BillboardAlbum aLbum = (BillboardAlbum)album;

                    sqlQuery = "INSERT INTO CHART(CHART_TYPE,CHART_DATE,POSITION,PEAK_POSITION,PREVIOUS_POSITION,WEEKS_ON_CHART,CHART_ID)VALUES(:v0,:v1,:v2,:v3,:v4,:v5,:v6)";

                    initCommand();
                    oCommand.BindByName = true;

                    oCommand.Parameters.Add(":v0", "Billboard200");
                    oCommand.Parameters.Add(":v1", DateTime.Now);
                    oCommand.Parameters.Add(":v2", aLbum.PostionOnChart);
                    oCommand.Parameters.Add(":v3", aLbum.PeakPostion);
                    oCommand.Parameters.Add(":v4", aLbum.PositionPreviousWeek);
                    oCommand.Parameters.Add(":v5", aLbum.WeeksOnChart);
                    oCommand.Parameters.Add(":v6", 9);

                    closeExecute();
                    updateDataSet();
                    fillData();

                    int chartID = Convert.ToInt32(dataSet.CHART.Rows[dataSet.CHART.Rows.Count - 1][6]);
                    sqlQuery = "INSERT INTO ARTIST(ARTIST_ID, NAME, DESCRIPTION) VALUES (:v0, :v1, :v2)";

                    initCommand();

                    oCommand.Parameters.Add(":v0", 9);
                    oCommand.Parameters.Add(":v1", aLbum.Artist);
                    oCommand.Parameters.Add(":v2", null);

                    closeExecute();
                    updateDataSet();
                    fillData();

                    int artistID = Convert.ToInt32(dataSet.ARTIST.Rows[dataSet.ARTIST.Rows.Count - 1][0]);

                    List<MetacriticAlbum> metaAlbum = new MongoConnection(1).getMetacritic();
                    int radtingID = 0;
                    foreach (MetacriticAlbum alb in metaAlbum)
                    {
                        

                        if (alb.AlbumTitle.Trim().Equals(aLbum.AlbumTitle.Trim()))
                        {
                            dataAlbums.Add(alb);
                            sqlQuery = "INSERT INTO RATING(RATING_ID,RATING_METASCORE,RATING_USERSCORE,RATING_DATE)VALUES(:v0,:v1,:v2,:v3)";

                            initCommand();

                            oCommand.BindByName = true;

                            oCommand.Parameters.Add(":v0", 9);
                            oCommand.Parameters.Add(":v1", alb.MetaScore);
                            oCommand.Parameters.Add(":v2", alb.UserScore);
                            oCommand.Parameters.Add(":v3", DateTime.Now);

                            closeExecute();
                            updateDataSet();
                            fillData();

                            radtingID = Convert.ToInt32(dataSet.RATING.Rows[dataSet.RATING.Rows.Count - 1][0]);
                        }
                        
                    }


                    sqlQuery = "INSERT INTO ALBUM(ALBUM_ID,ALBUM_NAME,ALBUM_DATE_RELEASE,ALBUM_GENRE,ARTIST_ID,RATING_ID,CHART_ID,ALBUM_ART)VALUES(:v0,:v1,:v2,:v3,:v4,:v5,:v6,:v7)";

                    initCommand();

                    oCommand.Parameters.Add(":v0", 9);
                    oCommand.Parameters.Add(":v1", aLbum.AlbumTitle.Trim());
                    oCommand.Parameters.Add(":v2", null);
                    oCommand.Parameters.Add(":v3", null);
                    oCommand.Parameters.Add(":v4", artistID);
                    if (radtingID == 0)
                        oCommand.Parameters.Add(":v5", null);
                    else
                        oCommand.Parameters.Add(":v5", radtingID);
                    oCommand.Parameters.Add(":v6", chartID);
                    oCommand.Parameters.Add(":v7", aLbum.ImagePath);
                    closeExecute();
                    updateDataSet();
                    fillData();

                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nHo Rough");
                oConnection.Close();
            }
        }

        public void updateDataSet()
        {
            manager.UpdateAll(dataSet);
        }

        #region nothing to see here
        public void initCommand()
        {
            oConnection.Open();
            oCommand = new OracleCommand(sqlQuery, oConnection);
        }

        public void closeExecute()
        {
            oCommand.ExecuteNonQuery();
            oConnection.Close();
        }
        #endregion
    }

}
