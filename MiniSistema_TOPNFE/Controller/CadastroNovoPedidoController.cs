using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MiniSistema_TOPNFE.Resources;
using FirebirdSql.Data.FirebirdClient;
namespace MiniSistema_TOPNFE.Controller
{
    class CadastroNovoPedidoController
    {
        private FirebirdClientFactory fbcf;
        private MySqlConnection conn;
        private string connString;

        public MySqlConnection SetNewConnection()
        {
            try
            {
                /*DBFactory dbFactory = new DBFactory();
                connString = dbFactory.ConnectionString();
                conn = dbFactory.GetNewConnection(connString);
                dbFactory.OpenConnection(conn);
                return conn;*/
                return conn;
            } catch (Exception e)
            {
                Console.WriteLine($"Falha na conexão ao banco de dados! Erro: {e}");
                return conn;
            }
        }
        public void PesquisarProduto(string str)
        {
            ConsultaProdutoView view = new ConsultaProdutoView();
            view.SettxtDescCodCodBarrasText(str);
            view.ShowDialog();
            view.SetFocusOnFirstTextBox();
            
        } public void CopiaProduto(Produto produto)
        {

        }
    }

    }

