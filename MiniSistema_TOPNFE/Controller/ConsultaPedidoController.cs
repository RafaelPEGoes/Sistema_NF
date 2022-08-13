using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSistema_TOPNFE.Resources;
using FirebirdSql.Data.FirebirdClient;


namespace MiniSistema_TOPNFE.Controller


{
    class ConsultaPedidoController
    {
        private string connString;
        private FbConnection conn;


        public string TipoOrdenacao()
        {

            ConsultaPedidosView consultaPedidos = new ConsultaPedidosView();

            string nomeCliente = consultaPedidos.GetCliente();
            string nomeVendedor = consultaPedidos.GetVendedor();
            //string dataInicio = consultaPedidos.GetDataInicio();
            //string dataFim = consultaPedidos.GetDataFim();
            //string numero = consultaPedidos.GetNumero();
            string situacao = consultaPedidos.GetSituacao();
            string ordenacao = consultaPedidos.GetOrdenacao();

            /* switch expression para o ComboBox ordenacao que sera escolhido
            pelo usuario na tela ConsultaPedido
            default: ordenar por numero */

            string tipoOrdenacao = situacao switch
            {

                /* alterar as expressoes conforme o nome
                 das colunas no BD */

                "Cidade" => "cidade",
                "Numero" => "numero",
                "Tipo" => "tipo",
                "Confirmado" => "confirmado",
                "Faturado" => "faturado",
                "Estoque" => "estoque",
                "Data" => "data",
                "Vendedor" => "vendedor",
                "ID Cliente" => "id_cliente",
                "Cliente" => "nome_cliente",
                _ => "numero"
            };

            return tipoOrdenacao;

        }

        public void ConsultaPedido(string tipoOrdenacao) 
        {
            DBFactory dbf = new DBFactory();
            ConsultaPedidosView view = new ConsultaPedidosView();
            string connString = dbf.ConnectionString();
            FbConnection fbConnection = new FbConnection(connString);
            fbConnection.Open();

            tipoOrdenacao = TipoOrdenacao();

            string query = $"SELECT CODIGO_CLIENTE, NOME, FANTASIA, CNPJ_CPF FROM CLIENTE WHERE NOME LIKE %{view.GetCliente()} ORDER BY {tipoOrdenacao}";



        }    

        

        }
}


