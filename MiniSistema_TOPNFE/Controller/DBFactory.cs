using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSistema_TOPNFE.Resources;
using MySql.Data.MySqlClient;
using FirebirdSql.Data.FirebirdClient;

namespace MiniSistema_TOPNFE.Controller
{
    public class DBFactory
    {
        private FbConnection conn;

        public FbConnection GetConnection() => conn = new FbConnection(ConnectionString());
        

        public string ConnectionString()
        {
            string connString = @"User=SYSDBA;Password=masterkey;Database=C:\Users\Rafael\Documents\BD_TopNFE\BD.FDB;DataSource=localhost;Port=3050;Dialect=3;Charset=NONE;Role=;Connection lifetime=15;Pooling=true;MinPoolSize=0;MaxPoolSize=50;Packet Size=8192;ServerType = 0;";
            return connString;
        }

      
        public FbConnection OpenConnection(FbConnection conn)
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }

            return conn;
        }

        public void CloseConnection(FbConnection conn)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }    
            
        }


    }

   
}
