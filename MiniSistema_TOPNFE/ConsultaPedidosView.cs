using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using MiniSistema_TOPNFE.Controller;
using MiniSistema_TOPNFE.Resources;
using MySql.Data.MySqlClient;
using Microsoft.VisualBasic;

namespace MiniSistema_TOPNFE
{
    public partial class ConsultaPedidosView : Form
    {
        public int rowIndex = 0;
        public string connString = "server=127.0.0.1;database=test_minisistema_topnfe;uid=root;pwd=jujuba99;";
        public ConsultaPedidosView()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            tabelaConsultaPedido.Columns.Add("ID_PEDIDO", "ID Pedido");
            tabelaConsultaPedido.Columns.Add("DATA_PEDIDO", "Data");
            tabelaConsultaPedido.Columns.Add("NOME_CLIENTE", "NOME_CLIENTE");
            tabelaConsultaPedido.Columns.Add("ID_PROD", "ID_PROD");
            tabelaConsultaPedido.Columns.Add("NOME_PRODUTO", "NOME_PRODUTO");
            tabelaConsultaPedido.Columns.Add("QUANTIDADE", "QUANTIDADE");
            tabelaConsultaPedido.Columns.Add("PRECO", "PRECO");
            tabelaConsultaPedido.Columns.Add("VALOR_TOTAL", "VALOR_TOTAL");
            this.tabelaConsultaPedido.Columns["PRECO"].DefaultCellStyle.Format = "c";
            this.tabelaConsultaPedido.Columns["VALOR_TOTAL"].DefaultCellStyle.Format = "c";
            tabelaConsultaPedido.Columns["ID_PEDIDO"].Width = 60;
            tabelaConsultaPedido.Columns["ID_PROD"].Width = 60;
            tabelaConsultaPedido.Columns["DATA_PEDIDO"].Width = 65;
            tabelaConsultaPedido.Columns["QUANTIDADE"].Width = 100;
            tabelaConsultaPedido.Columns["PRECO"].Width = 120;
            tabelaConsultaPedido.Columns["VALOR_TOTAL"].Width = 120;
            CriarTabelaPedidoNoBD();
            CriarTabelaPedidoItemsNoDB();

            PesquisarComDataReaderFirebird(testNewQueries("default"));
            //gambiarraParaOutrosCampos();

        }

        private string GerarQueryComFiltros()
        {
            string query = "";

            if (!String.IsNullOrEmpty(txtCliente.Text))
            {
                query = $"SELECT TABELA_PEDIDO_ITEMS.* " +
                $"FROM TABELA_PEDIDO_ITEMS LEFT JOIN TABELA_PEDIDO ON TABELA_PEDIDO_ITEMS.ID_PEDIDO = TABELA_PEDIDO.ID_PEDIDO " +
                $"WHERE TABELA_PEDIDO.ID_VENDEDOR IN (SELECT CODIGO_CLIENTE FROM CLIENTE WHERE NOME LIKE '%{RegexValidacao(txtCliente.Text.ToUpper())}%')";

                if (!String.IsNullOrEmpty(txtVendedor.Text))
                {
                    query += $" AND TABELA_PEDIDO.ID_CLIENTE IN (SELECT CODIGO_CLIENTE WHERE NOME LIKE '%{RegexValidacao(txtCliente.Text.ToUpper())}%'";

                    if (!String.IsNullOrEmpty(dtpDataIni.Text))
                    {
                        if (!String.IsNullOrEmpty(dtpDataFim.Text))
                        {
                            query += $" AND TABELA_PEDIDO.DATA_VENDA BETWEEN '{dtpDataIni.Text.Replace("/", ".")}' AND '{dtpDataFim.Text.Replace("/", ".")}'";

                        }
                        else
                        {
                            query += $" AND TABELA_PEDIDO.DATA_VENDA >= '{dtpDataIni.Text.Replace("/", ".")}'";
                        }
                    }
                }

            }

            return query;
        }

        public void ClearTabelaPedidos()
        {
            tabelaConsultaPedido.Rows.Clear();
        }
        private void ConsultaPedidosView_Enter(object sender, EventArgs e)
        {
            PesquisarComDataReaderFirebird(testNewQueries("default"));
        }

        private void CriarTabelaPedidoNoBD()
        {
            DBFactory dbf = new DBFactory();
            using (FbConnection conn = dbf.GetConnection())
            {
                conn.Open();
                FbTransaction transaction = conn.BeginTransaction();
                string query = "SELECT 1 FROM RDB$RELATIONS WHERE RDB$RELATION_NAME = 'TABELA_PEDIDO'";

                using (FbCommand cmd = new FbCommand(query, conn, transaction))
                {
                    object doesTableExist = cmd.ExecuteScalar();

                    if (doesTableExist != null)
                    {
                        return;
                    }
                    else
                    {
                        string queryCriaTabela = $"CREATE TABLE TABELA_PEDIDO (" +
                        $"ID_PEDIDO INT NOT NULL," +
                        $"ID_VENDEDOR INT," +
                        $"ID_CLIENTE INT," +
                        $"DATA_VENDA DATE);";

                        try
                        {
                            using (FbCommand cmd2 = new FbCommand(queryCriaTabela, conn, transaction))
                            {
                                cmd2.ExecuteNonQuery();
                                transaction.Commit();
                                MessageBox.Show("Tabela TABELA_PEDIDO criada com sucesso!");
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao criar tabela TABELA_PEDIDO no banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            MessageBox.Show(ex.Message);
                            transaction.Rollback();
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }


                }
            }
        }

        private void CriarTabelaPedidoNoBDMySQL()
        {

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                MySqlTransaction transaction = conn.BeginTransaction();
                string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'test_minisistema_topnfe' AND TABLE_NAME = 'TABELA_PEDIDO';";
                using (MySqlCommand cmd = new MySqlCommand(query, conn, transaction))
                {

                    object doesTableExists = cmd.ExecuteScalar();

                    if (doesTableExists != null)
                    {
                        MessageBox.Show("Tabela já existe, early return");
                        return;

                    }
                    else
                    {
                        string queryCriaTabela = $"CREATE TABLE TABELA_PEDIDO (" +
                        $"ID_PEDIDO INT NOT NULL," +
                        $"ID_VENDEDOR INT," +
                        $"ID_CLIENTE INT," +
                        $"DATA_VENDA DATE);";

                        try
                        {
                            using (MySqlCommand cmd2 = new MySqlCommand(queryCriaTabela, conn, transaction))
                            {
                                cmd2.ExecuteNonQuery();
                                transaction.Commit();
                                MessageBox.Show("Tabela TABELA_PEDIDO criada com sucesso");
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao criar tabela TABELA_PEDIDO no banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            MessageBox.Show(ex.Message);
                            transaction.Rollback();
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }


                }
            }
        }

        private void CriarTabelaPedidoItemsNoDBMySQL()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                MySqlTransaction transaction = conn.BeginTransaction();
                string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'test_minisistema_topnfe' AND TABLE_NAME = 'TABELA_PEDIDO_ITEMS'";
                using (MySqlCommand cmd = new MySqlCommand(query, conn, transaction))
                {
                    object doesTableExist = cmd.ExecuteScalar();


                    if (doesTableExist != null)
                    {
                        return;
                    }
                    else
                    {
                        string queryCriaTabela = $"CREATE TABLE TABELA_PEDIDO_ITEMS (" +
                        $"ID_PEDIDO INT NOT NULL," +
                        $"ID_PRODUTO INT NOT NULL," +
                        $"NOME_PRODUTO VARCHAR(100)," +
                        $"QUANTIDADE DOUBLE PRECISION," +
                        $"PRECO DOUBLE PRECISION," +
                        $"VALOR_TOTAL DOUBLE PRECISION" +
                        $");";

                        try
                        {
                            using (MySqlCommand cmd2 = new MySqlCommand(queryCriaTabela, conn, transaction))
                            {
                                cmd2.ExecuteNonQuery();
                                transaction.Commit();


                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao criar tabela TABELA_PEDIDO no banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            MessageBox.Show(ex.Message);
                            transaction.Rollback();
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }


                }
            }
        }

        private void CriarTabelaPedidoItemsNoDB()
        {
            DBFactory dbf = new DBFactory();

            using (FbConnection conn = dbf.GetConnection())
            {
                conn.Open();
                FbTransaction transaction = conn.BeginTransaction();

                string query = "SELECT 1 FROM RDB$RELATIONS WHERE RDB$RELATION_NAME = 'TABELA_PEDIDO_ITEMS'";

                using (FbCommand cmd = new FbCommand(query, conn, transaction))
                {
                    object doesTableExist = cmd.ExecuteScalar();

                    if (doesTableExist != null)
                    {
                        return;
                    }
                    else
                    {
                        string queryCriaTabela = "CREATE TABLE TABELA_PEDIDO_ITEMS(" +
                            "ID_PEDIDO INT NOT NULL," +
                            "ID_PRODUTO INT NOT NULL," +
                            "NOME_PRODUTO VARCHAR(100)," +
                            "QUANTIDADE DOUBLE PRECISION," +
                            "PRECO DOUBLE PRECISION," +
                            "VALOR_TOTAL DOUBLE PRECISION" +
                            ");";
                        try
                        {
                            using (FbCommand cmd2 = new FbCommand(queryCriaTabela, conn, transaction))
                            {
                                cmd2.ExecuteNonQuery();
                                transaction.Commit();
                                MessageBox.Show("Tabela TABELA_PEDIDO_ITEMS criada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.None);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao criar tabela TABELA_PEDIDO_ITEMS no banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            MessageBox.Show(ex.Message);
                            transaction.Rollback();
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CadastroNovoPedidoView t1 = new CadastroNovoPedidoView();
            t1.ShowDialog();

        }

        public string GetCliente()
        {
            return txtCliente.Text;
        }

        public string GetVendedor()
        {
            return txtVendedor.Text;
        }

        public string GetDataInicio()
        {
            return dtpDataIni.Text;
        }

        public string GetDataFim()
        {
            return dtpDataFim.Text;
        }

        public string GetNumero()
        {
            string num = txtNumero.Text;
            Int16.Parse(num);
            return num;

        }

        public string GetSituacao()
        {
            return cbSituacao.Text;
        }

        public string GetOrdenacao()
        {
            return cbOrdenaPor.Text;
        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            tabelaConsultaPedido.Rows.Clear();

            if (!String.IsNullOrEmpty(txtCliente.Text))
            {
                PesquisarComDataReaderFirebird(testNewQueries("nome_cli"));
            }
        }

        public void Pesquisar(string str)
        {
            DBFactory dbf = new DBFactory();

            using (FbConnection conn = dbf.GetConnection())
            {
                string query = str;
                conn.Open();
                using (FbCommand cmd = new FbCommand(query, conn))
                {
                    using (FbDataAdapter adapter = new FbDataAdapter(cmd))
                    {

                        SetTabelaPedidosDataSource(adapter);
                        conn.Close();

                    }
                }
            }
        }

        public void PesquisarComDataReader(string str)
        {

            using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1;database=test_minisistema_topnfe;uid=root;pwd=jujuba99;"))
            {
                string query = str;
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {


                        while (reader.Read())
                        {
                            int rowIndex = tabelaConsultaPedido.Rows.Add();
                            tabelaConsultaPedido.Rows[rowIndex].Cells["ID_PEDIDO"].Value = Int32.Parse(reader.GetString(0));
                            tabelaConsultaPedido.Rows[rowIndex].Cells["DATA_PEDIDO"].Value = reader.GetString(1);
                            tabelaConsultaPedido.Rows[rowIndex].Cells["NOME_CLIENTE"].Value = reader.GetString(2);
                            tabelaConsultaPedido.Rows[rowIndex].Cells["ID_PROD"].Value = Int32.Parse(reader.GetString(3));
                            tabelaConsultaPedido.Rows[rowIndex].Cells["NOME_PRODUTO"].Value = reader.GetString(4);
                            tabelaConsultaPedido.Rows[rowIndex].Cells["QUANTIDADE"].Value = Double.Parse(reader.GetString(5));
                            tabelaConsultaPedido.Rows[rowIndex].Cells["PRECO"].Value = double.Parse(reader.GetString(6));
                            tabelaConsultaPedido.Rows[rowIndex].Cells["VALOR_TOTAL"].Value = double.Parse(reader.GetString(7));

                            rowIndex++;
                        }
                    }
                }
            }
        }

        public void PesquisarComDataReaderFirebird(string str)
        {
            DBFactory dbf = new DBFactory();

            using (FbConnection conn = dbf.GetConnection())
            {
                conn.Open();

                using (FbTransaction transaction = conn.BeginTransaction())
                {
                    string query = str;


                    using (FbCommand cmd = new FbCommand(query, conn, transaction))

                    {

                        using (FbDataReader reader = cmd.ExecuteReader())
                        {
                            try
                            {
                                while (reader.Read())
                                {
                                    int rowIndex = tabelaConsultaPedido.Rows.Add();
                                    tabelaConsultaPedido.Rows[rowIndex].Cells["ID_PEDIDO"].Value = Int32.Parse(reader.GetString(0));
                                    tabelaConsultaPedido.Rows[rowIndex].Cells["DATA_PEDIDO"].Value = DateTime.Parse(reader.GetString(1));
                                    tabelaConsultaPedido.Rows[rowIndex].Cells["NOME_CLIENTE"].Value = reader.GetString(2);
                                    tabelaConsultaPedido.Rows[rowIndex].Cells["ID_PROD"].Value = Int32.Parse(reader.GetString(3));
                                    tabelaConsultaPedido.Rows[rowIndex].Cells["NOME_PRODUTO"].Value = reader.GetString(4);
                                    tabelaConsultaPedido.Rows[rowIndex].Cells["QUANTIDADE"].Value = Double.Parse(reader.GetString(5));
                                    tabelaConsultaPedido.Rows[rowIndex].Cells["PRECO"].Value = double.Parse(reader.GetString(6));
                                    tabelaConsultaPedido.Rows[rowIndex].Cells["VALOR_TOTAL"].Value = double.Parse(reader.GetString(7));

                                    rowIndex++;
                                }
                                transaction.Commit();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                transaction.Rollback();
                            }
                        }

                    }
                }

            }
        }

        public void PesquisarMySQL(string str)
        {
            DBFactory dbf = new DBFactory();

            using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1;database=test_minisistema_topnfe;uid=root;pwd=jujuba99;"))
            {
                string query = str;
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        SetTabelaPedidosDataSourceMySQL(adapter);
                        conn.Close();

                    }
                }
            }
        }

        private string RegexValidacao(string str)
        {
            return Regex.Replace(str, "[^0-9a-zA-Z]+", "");
        }

        private string RegexValidaNumero(string str)
        {
            return Regex.Replace(str, "[^0-9]+", "");

        }
        public string GerarQueryParaPesquisa(int opcao)
        {

            string query = opcao switch
            {
                1 => $"SELECT ID_PROD, NOME_PRODUTO, QUANTIDADE, PRECO, VALOR_TOTAL FROM TABELA_PEDIDO WHERE NOME LIKE '%{RegexValidacao(txtCliente.Text.ToUpper())}%'",
                2 => $"SELECT ID_PROD, NOME_PRODUTO, QUANTIDADE, PRECO, VALOR_TOTAL FROM TABELA_PEDIDO_ITEMS WHERE NOME_VENDEDOR LIKE '%{RegexValidacao(txtVendedor.Text)}%'",
                3 => $"SELECT ID_PROD, NOME_PRODUTO, QUANTIDADE, PRECO, VALOR_TOTAL FROM TABELA_PEDIDO_ITEMS WHERE (SELECT ID_PEDIDO FROM TABELA_PEDIDO WHERE DATA_VENDA => '{dtpDataIni.Text.Replace("/", ".")})'",
                4 => $"SELECT ID_PROD, NOME_PRODUTO, QUANTIDADE, PRECO, VALOR_TOTAL FROM TABELA_PEDIDO_ITEMS WHERE (SELECT ID_PEDIDO FROM TABELA_PEDIDO WHERE DATA_VENDA <= '{dtpDataFim.Text.Replace("/", ".")})'",
                5 => $"SELECT ID_PROD, NOME_PRODUTO, QUANTIDADE, PRECO, VALOR_TOTAL FROM TABELA_PEDIDO_ITEMS WHERE (SELECT ID_PEDIDO FROM TABELA_PEDIDO WHERE DATA BETWEEN'{dtpDataIni.Text.Replace("/", ".")}' AND '{dtpDataFim.Text.Replace("/", ".")})'",
                6 => $"SELECT ID_PEDIDO, ID_PROD, NOME_PRODUTO, QUANTIDADE, PRECO, VALOR_TOTAL FROM TABELA_PEDIDO_ITEMS WHERE ID_PEDIDO LIKE '{RegexValidaNumero(txtNumero.Text)}%'",
                _ => $"SELECT ID_PEDIDO, ID_PROD, NOME_PRODUTO, QUANTIDADE, PRECO, VALOR_TOTAL FROM TABELA_PEDIDO_ITEMS WHERE (SELECT ID_PEDIDO FROM TABELA_PEDIDO WHERE DATA = '{DateTime.Now}')"

            };


            return query;

        }

        public string testNewQueries(string opcao)
        {
            string query = opcao switch
            {
                "nome_cli" => $"SELECT TABELA_PEDIDO_ITEMS.ID_PEDIDO," +
                $"TABELA_PEDIDO.DATA_VENDA," +
                $"CLIENTE.NOME," +
                $"TABELA_PEDIDO_ITEMS.ID_PRODUTO," +
                $"TABELA_PEDIDO_ITEMS.NOME_PRODUTO," +
                $"TABELA_PEDIDO_ITEMS.QUANTIDADE," +
                $"TABELA_PEDIDO_ITEMS.PRECO," +
                $"TABELA_PEDIDO_ITEMS.VALOR_TOTAL " +
                $"FROM TABELA_PEDIDO " +
                $"INNER JOIN CLIENTE ON TABELA_PEDIDO.ID_CLIENTE = CLIENTE.CODIGO_CLIENTE " +
                $"INNER JOIN TABELA_PEDIDO_ITEMS ON TABELA_PEDIDO.ID_PEDIDO = TABELA_PEDIDO_ITEMS.ID_PEDIDO " +
                $"WHERE TABELA_PEDIDO.ID_CLIENTE IN (SELECT CODIGO_CLIENTE FROM CLIENTE WHERE NOME LIKE '%{RegexValidacao(txtCliente.Text.ToUpper())}%');",

                "nome_vendedor" => $"SELECT TABELA_PEDIDO_ITEMS.ID_PEDIDO," +
                $"TABELA_PEDIDO.DATA_VENDA," +
                $"CLIENTE.NOME," +
                $"TABELA_PEDIDO_ITEMS.ID_PRODUTO," +
                $"TABELA_PEDIDO_ITEMS.NOME_PRODUTO," +
                $"TABELA_PEDIDO_ITEMS.QUANTIDADE," +
                $"TABELA_PEDIDO_ITEMS.PRECO," +
                $"TABELA_PEDIDO_ITEMS.VALOR_TOTAL " +
                $"FROM TABELA_PEDIDO " +
                $"INNER JOIN CLIENTE ON TABELA_PEDIDO.ID_CLIENTE = CLIENTE.CODIGO_CLIENTE " +
                $"INNER JOIN TABELA_PEDIDO_ITEMS ON TABELA_PEDIDO.ID_PEDIDO = TABELA_PEDIDO_ITEMS.ID_PEDIDO " +
                $"WHERE TABELA_PEDIDO.ID_VENDEDOR IN (SELECT CODIGO_CLIENTE FROM CLIENTE WHERE NOME LIKE '%{RegexValidacao(txtVendedor.Text.ToUpper())}%');",

                "data_ini" => $"SELECT TABELA_PEDIDO_ITEMS.ID_PEDIDO," +
                $"TABELA_PEDIDO.DATA_VENDA," +
                $"CLIENTE.NOME," +
                $"TABELA_PEDIDO_ITEMS.ID_PRODUTO," +
                $"TABELA_PEDIDO_ITEMS.NOME_PRODUTO," +
                $"TABELA_PEDIDO_ITEMS.QUANTIDADE," +
                $"TABELA_PEDIDO_ITEMS.PRECO," +
                $"TABELA_PEDIDO_ITEMS.VALOR_TOTAL " +
                $"FROM TABELA_PEDIDO " +
                $"INNER JOIN CLIENTE ON TABELA_PEDIDO.ID_CLIENTE = CLIENTE.CODIGO_CLIENTE " +
                $"INNER JOIN TABELA_PEDIDO_ITEMS ON TABELA_PEDIDO.ID_PEDIDO = TABELA_PEDIDO_ITEMS.ID_PEDIDO " +
                $"WHERE TABELA_PEDIDO.DATA_VENDA = '{dtpDataIni.Text.Replace("/", ".")}';",

                "data_fim" => $"SELECT TABELA_PEDIDO_ITEMS.ID_PEDIDO," +
                $"TABELA_PEDIDO.DATA_VENDA," +
                $"CLIENTE.NOME," +
                $"TABELA_PEDIDO_ITEMS.ID_PRODUTO," +
                $"TABELA_PEDIDO_ITEMS.NOME_PRODUTO," +
                $"TABELA_PEDIDO_ITEMS.QUANTIDADE," +
                $"TABELA_PEDIDO_ITEMS.PRECO," +
                $"TABELA_PEDIDO_ITEMS.VALOR_TOTAL " +
                $"FROM TABELA_PEDIDO " +
                $"INNER JOIN CLIENTE ON TABELA_PEDIDO.ID_CLIENTE = CLIENTE.CODIGO_CLIENTE " +
                $"INNER JOIN TABELA_PEDIDO_ITEMS ON TABELA_PEDIDO.ID_PEDIDO = TABELA_PEDIDO_ITEMS.ID_PEDIDO " +
                $"WHERE TABELA_PEDIDO.DATA_VENDA <= '{dtpDataFim.Text.Replace("/", ".")}';",

                "periodo" => $"SELECT TABELA_PEDIDO_ITEMS.ID_PEDIDO," +
                $"TABELA_PEDIDO.DATA_VENDA," +
                $"CLIENTE.NOME," +
                $"TABELA_PEDIDO_ITEMS.ID_PRODUTO," +
                $"TABELA_PEDIDO_ITEMS.NOME_PRODUTO," +
                $"TABELA_PEDIDO_ITEMS.QUANTIDADE," +
                $"TABELA_PEDIDO_ITEMS.PRECO," +
                $"TABELA_PEDIDO_ITEMS.VALOR_TOTAL " +
                $"FROM TABELA_PEDIDO " +
                $"INNER JOIN CLIENTE ON TABELA_PEDIDO.ID_CLIENTE = CLIENTE.CODIGO_CLIENTE " +
                $"INNER JOIN TABELA_PEDIDO_ITEMS ON TABELA_PEDIDO.ID_PEDIDO = TABELA_PEDIDO_ITEMS.ID_PEDIDO " +
                $"WHERE TABELA_PEDIDO.DATA_VENDA BETWEEN '{dtpDataIni.Text.Replace("/", ".")}' AND '{dtpDataFim.Text.Replace("/", ".")}';",

                "id_pedido" => $"SELECT TABELA_PEDIDO_ITEMS.ID_PEDIDO," +
                $"TABELA_PEDIDO.DATA_VENDA," +
                $"CLIENTE.NOME," +
                $"TABELA_PEDIDO_ITEMS.ID_PRODUTO," +
                $"TABELA_PEDIDO_ITEMS.NOME_PRODUTO," +
                $"TABELA_PEDIDO_ITEMS.QUANTIDADE," +
                $"TABELA_PEDIDO_ITEMS.PRECO," +
                $"TABELA_PEDIDO_ITEMS.VALOR_TOTAL " +
                $"FROM TABELA_PEDIDO " +
                $"INNER JOIN CLIENTE ON TABELA_PEDIDO.ID_CLIENTE = CLIENTE.CODIGO_CLIENTE " +
                $"INNER JOIN TABELA_PEDIDO_ITEMS ON TABELA_PEDIDO.ID_PEDIDO = TABELA_PEDIDO_ITEMS.ID_PEDIDO " +
                $"WHERE TABELA_PEDIDO.ID_PEDIDO = {txtNumero.Text}" +
                $" ORDER BY TABELA_PEDIDO.ID_PEDIDO;",

                _ => $"SELECT TABELA_PEDIDO_ITEMS.ID_PEDIDO," +
                $"TABELA_PEDIDO.DATA_VENDA," +
                $"CLIENTE.NOME," +
                $"TABELA_PEDIDO_ITEMS.ID_PRODUTO," +
                $"TABELA_PEDIDO_ITEMS.NOME_PRODUTO," +
                $"TABELA_PEDIDO_ITEMS.QUANTIDADE," +
                $"TABELA_PEDIDO_ITEMS.PRECO," +
                $"TABELA_PEDIDO_ITEMS.VALOR_TOTAL " +
                $"FROM TABELA_PEDIDO " +
                $"INNER JOIN CLIENTE ON TABELA_PEDIDO.ID_CLIENTE = CLIENTE.CODIGO_CLIENTE " +
                $"INNER JOIN TABELA_PEDIDO_ITEMS ON TABELA_PEDIDO.ID_PEDIDO = TABELA_PEDIDO_ITEMS.ID_PEDIDO " +
                $"WHERE TABELA_PEDIDO.DATA_VENDA = '{DateTime.Now.ToString("dd.MM.yyyy")}' ORDER BY ID_PEDIDO DESCENDING;"

            };

            return query;
        }

        public string GetTipoOrdenacao()
        {
            string ordenacao = "";

            //dar um switch nos items do cbOrdenaPor

            return ordenacao;
        }

        public DataGridView GetDataGridView()
        {
            return tabelaConsultaPedido;
        }

        public List<ProdutoPedido> ListaParaImpressao3()
        {
            List<ProdutoPedido> lista = new();

            foreach (DataGridViewRow row in tabelaConsultaPedido.Rows)
            {
                ProdutoPedido produto = new ProdutoPedido();
                //retorna null ao pegar o valor

                produto.SetID(Int32.Parse(row.Cells["ID_PROD"].Value.ToString()));
                produto.SetNome(row.Cells["NOME_PRODUTO"].Value.ToString());
                produto.SetQuantidade(Double.Parse((row.Cells["QUANTIDADE"].Value.ToString())));
                produto.SetPreco(double.Parse(row.Cells["PRECO"].Value.ToString()));
                produto.SetValorTotal(double.Parse(row.Cells["VALOR_TOTAL"].Value.ToString()));
                lista.Add(produto);
            }

            return lista;

        }

        public void SetTabelaPedidosDataSourceMySQL(MySqlDataAdapter adapter)
        {
            DataTable dt = new();
            adapter.Fill(dt);
            tabelaConsultaPedido.DataSource = dt;
        }

        public void SetTabelaPedidosDataSource(FbDataAdapter adapter)
        {

            DataTable dt = new();
            adapter.Fill(dt);
            tabelaConsultaPedido.DataSource = dt;

        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {
            RegexValidaNumero(txtNumero.Text);
            tabelaConsultaPedido.Rows.Clear();

            if (!String.IsNullOrEmpty(txtNumero.Text))
            {
                PesquisarComDataReaderFirebird(testNewQueries("id_pedido"));

            }
        }

        private void txtNumero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Back)
            {
                PesquisarComDataReaderFirebird(GerarQueryParaPesquisa(6));

            }

        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ESTÁ ACESSANDO ESSA PARTE MESMO QUE NÃO TENHA DADOS NO DATAGRID

            //CONTORNAR ESSA PARTE COM ALGUM OUTRO MÉTODO QUE CHEQUE SE ESTÁ VAZIO OU NÃO
            if (true)
            {

                List<ProdutoPedido> lista = new List<ProdutoPedido>(ListaParaImpressao3());

                //List<ProdutoPedido> lista = new List<ProdutoPedido>(ListaParaImpressao(GerarQueryParaPesquisa(4)));
                TesteImpressao impressao = new TesteImpressao();
                impressao.lista = new List<ProdutoPedido>(lista);
            }
            if (!tabelaConsultaPedido.SelectedRows.Equals(""))
            {
                DataGridViewRow row = new DataGridViewRow();

                //string str2 = tabelaConsultaPedido.Rows[rowIndex].Cells[0].Value.ToString();
                //string str = tabelaConsultaPedido.SelectedCells[0].Value.ToString();
                TesteImpressao impressao = new TesteImpressao();
                impressao.lista = new List<ProdutoPedido>(ListaParaImpressao3());
                //MessageBox.Show(str2);
                impressao.Show();

            }
            else
            {

                MessageBox.Show("Nenhuma linha selecionada!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }

        public List<ProdutoPedido> ListaParaImpressaoMySQL(string str)
        {
            List<ProdutoPedido> lista = new List<ProdutoPedido>();

            using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1;database=test_minisistema_topnfe;uid=root;pwd=jujuba99;"))
            {
                string query = str;
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (reader.Read())
                            {
                                ProdutoPedido produto = new ProdutoPedido();
                                produto.SetID(Int32.Parse(reader.GetString(0)));
                                produto.SetNome(reader.GetString(1));
                                produto.SetQuantidade(double.Parse(reader.GetString(2)));
                                produto.SetPreco(Double.Parse(reader.GetString(3)));
                                produto.SetValorTotal(produto.GetValorTotal());

                                lista.Add(produto);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }

            return lista;
        }

        public List<ProdutoPedido> ListaParaImpressao(string str)
        {
            List<ProdutoPedido> lista = new List<ProdutoPedido>();
            DBFactory dbf = new DBFactory();

            using (FbConnection conn = dbf.GetConnection())
            {
                string query = str;
                conn.Open();

                using (FbCommand cmd = new FbCommand(query, conn))
                {
                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (reader.Read())
                            {

                                ProdutoPedido produto = new ProdutoPedido();
                                produto.SetID(Int32.Parse(reader.GetString(0)));
                                produto.SetNome(reader.GetString(1));
                                produto.SetQuantidade(double.Parse(reader.GetString(2)));
                                produto.SetPreco(Double.Parse(reader.GetString(3)));
                                produto.SetValorTotal(produto.GetValorTotal());

                                lista.Add(produto);


                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }


                        conn.Close();
                    }
                }
            }

            return lista;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            TesteImpressao impressao = new TesteImpressao();
            List<ProdutoPedido> lista = new List<ProdutoPedido>(ListaParaImpressaoMySQL(GerarQueryParaPesquisa(1)));
            impressao.GerarNovaLista(lista);
            //impressao.SetIdParaImpressao(1);
            impressao.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            if (DateTime.Parse(dtpDataIni.Text) <= DateTime.Parse(DateTime.Now.ToString("dd-MM-yyyy")))
            {
                //Pesquisar(GerarQueryParaPesquisa(3));
                PesquisarComDataReaderFirebird(GerarQueryParaPesquisa(3));
            }
            else
            {
                MessageBox.Show("Data de início inserida é maior que a data atual!", "Data Inválida!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void dtpDataFim_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Parse(dtpDataFim.Text) <= DateTime.Parse(DateTime.Now.ToString("dd-MM-yyyy")))
            {
                PesquisarComDataReaderFirebird(testNewQueries("data_fim2"));
            }
            else
            {
                MessageBox.Show("Data final inserida é maior que a data atual!", "Data inválida!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpDataFim.Text = DateTime.Now.ToShortDateString();
            }

        }

        private void ConsultaPedidosView_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control.GetType().ToString() == "System.Windows.Form.TextBox")
                    if (control.GetType().ToString() == "System.Windows.Form.TextBox")
                    {
                        if (e.KeyCode == Keys.Enter)
                        {
                            tabelaConsultaPedido.Focus();
                        }
                    }
            }
        }

        private void AtualizarProdutoNoDB(DataGridViewCell cell)
        {
            DBFactory dbf = new DBFactory();

            using (FbConnection conn = dbf.GetConnection())
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string query = "UPDATE BLABLABLA";
                using (FbTransaction transaction = conn.BeginTransaction())
                {
                    using (FbCommand cmd = new FbCommand(query, conn, transaction))
                    {
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                }
            }
        }

        private void txtVendedor_TextChanged(object sender, EventArgs e)
        {
            tabelaConsultaPedido.Rows.Clear();

            if (!String.IsNullOrEmpty(txtVendedor.Text))
            {
                PesquisarComDataReaderFirebird(testNewQueries("nome_vendedor"));
            }

        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            PesquisarComDataReaderFirebird(GerarQueryComFiltros());
        }

        private void ConsultaPedidosView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.N)
            {
                MessageBox.Show("N pressed");
            }
        }

        private LinhaDataGridVIew LinhaParaAlterar()
        {
            LinhaDataGridVIew linha = new LinhaDataGridVIew();

            linha.SetIDPedido(Int32.Parse(tabelaConsultaPedido.Rows[rowIndex].Cells["ID_PEDIDO"].Value.ToString()));
            linha.SetData(tabelaConsultaPedido.Rows[rowIndex].Cells["DATA_PEDIDO"].Value.ToString());
            linha.SetIdCliente(PesquisaIDCliente(rowIndex));
            linha.SetNomeCliente(tabelaConsultaPedido.Rows[rowIndex].Cells["NOME_CLIENTE"].Value.ToString());
            linha.SetIDProduto(Int32.Parse(tabelaConsultaPedido.Rows[rowIndex].Cells["ID_PROD"].Value.ToString()));
            linha.SetNomeProduto(tabelaConsultaPedido.Rows[rowIndex].Cells["NOME_PRODUTO"].Value.ToString());
            linha.SetQuantidade(double.Parse(tabelaConsultaPedido.Rows[rowIndex].Cells["QUANTIDADE"].Value.ToString()));
            linha.SetPreco(double.Parse(tabelaConsultaPedido.Rows[rowIndex].Cells["PRECO"].Value.ToString()));

            return linha;
        }

        private int PesquisaIDCliente(int rowIndex)
        {
            DBFactory dbf = new DBFactory();
            int id = 0;
            using (FbConnection conn = dbf.GetConnection())
            {
                conn.Open();
                string query = $"SELECT CODIGO_CLIENTE FROM CLIENTE WHERE NOME = @NOME";

                using (FbCommand cmd = new FbCommand(query, conn))
                {
                    string str = tabelaConsultaPedido.Rows[rowIndex].Cells["NOME_CLIENTE"].Value.ToString();
                    cmd.Parameters.AddWithValue("@NOME", str);

                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        
                        try
                        {
                            if (reader.Read())
                            {
                                id = reader.GetInt32(0);
                            } else
                            {
                                MessageBox.Show("Não há correspondência de ID para o nome informado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                }
            }

            return id;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (this.tabelaConsultaPedido.SelectedCells.Count > 0)
            {
                LinhaDataGridVIew linha = LinhaParaAlterar();

                //MessageBox.Show(tabelaConsultaPedido.CurrentRow.Cells[3].Value.ToString());
                //MessageBox.Show(tabelaConsultaPedido.CurrentCell.Value.ToString());
                //string id = Interaction.InputBox("Enter", "Tìtulo", "1", 10, 10);
                //string id1 = Interaction.InputBox("Enter", "Tìtulo", "1", 10, 10);
                //string id2 = Interaction.InputBox("Enter", "Tìtulo", "1", 10, 10);
                //string id3 = Interaction.InputBox("Enter", "Tìtulo", "1", 10, 10);
                CadastroNovoPedidoView view = new CadastroNovoPedidoView();
                view.linha = linha;
                view.InsereLinhaNoForm();
                view.Show();
                //AlteraInfoPedido aip = new AlteraInfoPedido();
                //aip.linha = linha;
                //aip.Show();


                for (int i = tabelaConsultaPedido.CurrentCell.ColumnIndex; i < tabelaConsultaPedido.Columns.Count; i++)
                {



                }

                //AtualizarProdutoNoDB();
            }
            else
            {
                MessageBox.Show("Não há linhas selecionadas!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void tabelaConsultaPedido_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Down)
            {

                rowIndex++;
                MessageBox.Show(rowIndex.ToString());
            }
            else if (e.KeyCode == Keys.Up)
            {

                rowIndex--;
                MessageBox.Show(rowIndex.ToString());
            }
        }

        //private void tabelaConsultaPedido_KeyDown(object sender, KeyEventArgs e)
        //{
        //    MessageBox.Show(e.KeyCode.ToString());

        //    if (tabelaConsultaPedido.SelectedRows.Count > 0)
        //    {
        //        if (e.KeyCode == Keys.V)
        //        {
        //            //this.tabelaConsultaPedido.Columns[0].Edi
        //        }
        //    }


        //}
    }
}
