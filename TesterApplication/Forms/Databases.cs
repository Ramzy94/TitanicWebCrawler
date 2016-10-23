using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesterApplication.DatabaseConnections;
using MongoDB.Bson;
using System.Windows.Forms;
using TitanicCrawler.Albums;

namespace TesterApplication.Forms
{
    public partial class Databases : UserControl
    {
        private List<BsonDocument> a;
        private MongoConnection mongo;
        public Databases()
        {
            InitializeComponent();
        }

        private void btnOracleBilloard_Click(object sender, EventArgs e)
        {
            mongo = new MongoConnection(1);
            List<BillboardAlbum> meta = mongo.getBillboard();
            OracleConnect oracleConn = new OracleConnect();

            foreach (BillboardAlbum album in meta)
                oracleConn.insertAlbum(album);


        }

        private void btnOracle_Click(object sender, EventArgs e)
        {

            mongo = new MongoConnection(1);
            List<MetacriticAlbum> meta = mongo.getMetacritic();
            OracleConnect oracleConn = new OracleConnect();

            foreach (MetacriticAlbum album in meta)
                oracleConn.insertAlbum(album);
        }
    }
}
