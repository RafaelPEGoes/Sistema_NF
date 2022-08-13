using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;

namespace MiniSistema_TOPNFE.Controller
{
    public class daoFirebird
    {
        private static readonly daoFirebird instanceFirebird = new daoFirebird();

        private daoFirebird()
        {
        
        }

        public static daoFirebird GetInstance()
        {
            return instanceFirebird;
        }

        public string GetConnectionString()
        {
            string connString = @"User=SYSDBA;Password=masterkey;Database=C:\Users\Rafael\Documents\BD_TopNFE\BD.FDB;DataSource=localhost;Port=3050;Dialect=3;Charset=NONE;Role=;Connection lifetime=15;Pooling=true;MinPoolSize=0;MaxPoolSize=50;Packet Size=8192;ServerType = 0;";
            return connString;
        }
        public FbConnection GetConnection()
        {
            return new FbConnection(GetConnectionString());
        }
        
    }
}
