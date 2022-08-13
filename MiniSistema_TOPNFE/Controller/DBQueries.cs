using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;

namespace MiniSistema_TOPNFE.Controller
{
    class DBQueries
    {
        FbConnection fbc = daoFirebird.GetInstance().GetConnection();

        public FbConnection OpenConnection()
        {
            try
            {
                fbc.Open();
                
            } catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return fbc;
            
        }

        public void CloseConnection()
        {
            fbc.Close();
        }

             
        public FbCommand NewCommand(string query)
        {
            return new FbCommand(query);
        }
        

     
    }
}
