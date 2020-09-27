using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;

namespace Altium_Database_Libraries.Lib
{
    class SQLData
    {

        private SQLiteConnection connect = new SQLiteConnection();
        private SQLiteCommand cmd;
        private string dbName = string.Empty;
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
                " ([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Time nvarchar(50), IN_Va varchar(10) , IN_Vb varchar(10), IN_Vc varchar(10), V_DC varchar(10), Freq varchar(10), OUT_Va varchar(10), OUT_Vb varchar(10), " +
                "OUT_Vc varchar(10), OUT_Ia varchar(10), OUT_Ib varchar(10), OUT_Ic varchar(10))";
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
            
        }

        public string Database
        {
            get { return dbName; }
            set { dbName = value; }
        }

    }
}
