using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace Altium_Database_Libraries.Lib
{
    public class SQLData
    {

        private SQLiteConnection connect = new SQLiteConnection();
        private SQLiteCommand cmd;
        private string dbName = string.Empty;

        public SQLData(string database)
        {
            dbName = database;
            SQLCreate();
        }

        private void SQLConnect(string database)
        {
            string strConnect = "Data Source=" + database + ";Version=3;";
            connect.ConnectionString = strConnect;
            connect.Open();
        }

        private void SQLDisconnect()
        {
            connect.Close();
        }

        private void SQLCreate()
        {
            if (dbName == "") return;
            string sql = "CREATE TABLE IF NOT EXISTS AltiumTable" +
                " ([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Time nvarchar(50), PartNumber varchar(50), PartType varchar(20), Manufacturer varchar(30), ManufacturePart varchar(30), Description varchar(30), LeadTime varchar(20), Categories varchar(20), Temperature varchar(20), " +
                "MountingType varchar(20), Package varchar(20), SupplierPackage varchar(20))";
            if (!File.Exists(dbName))
            {
                SQLiteConnection.CreateFile(dbName);
            }
            SQLConnect(dbName);
            cmd = new SQLiteCommand(sql, connect);
            cmd.ExecuteNonQuery();
            SQLDisconnect();
        }

        public void SQLAdd(List<DataList> list)
        {
            string time = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00");
            SQLConnect(dbName);
            using (cmd = new SQLiteCommand(connect))
            using ( var transaction = connect.BeginTransaction())
            {
                foreach(DataList item in list)
                {
                    cmd.CommandText = string.Format("INSERT INTO AltiumTable (Time, PartNumber, PartType, Manufacturer, ManufacturePart, Description, LeadTime, Categories, Temperature, MountingType, Package, SupplierPackage) VALUES" +
                    "('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}')", time, item.PartNumber, item.PartType, item.Manufacturer, item.ManufacturerPartNumber, item.Description, item.LeadTime, item.Categories, item.Temperature, item.MountingType, item.Package, item.SupplierPackage);
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
            }
            SQLDisconnect();
        }

        public DataSet SQLDataSet(string table)
        {
            DataSet ds = new DataSet();
            SQLConnect(dbName);
            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM AltiumTable", connect);
            da.Fill(ds, table);
            SQLDisconnect();
            return ds;
        }

        public DataTable SQLDataTable(string table)
        {
            DataTable dt = new DataTable();
            dt = SQLDataSet(table).Tables[table].Copy();
            return dt;
        }

        public DataGridView SQLDataView()
        {
            DataGridView dgw = new DataGridView();
            dgw.DataSource = SQLDataSet("Altium").Tables[0];
            return dgw;
        }

        public string Database
        {
            get { return dbName; }
            set
            {
                dbName = value;
                SQLCreate();
            }
        }

    }
}
