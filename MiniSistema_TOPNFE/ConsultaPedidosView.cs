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

namespace MiniSistema_TOPNFE
{
    public partial class ConsultaPedidosView : Form
    {
        public ConsultaPedidosView()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            tabelaConsultaPedido.Columns.Add("ID_PEDIDO", "ID_PEDIDO");
            tabelaConsultaPedido.Columns.Add("ID_PROD", "ID_PROD");
            tabelaConsultaPedido.Columns.Add("NOME_PRODUTO", "NOME_PRODUTO");
            tabelaConsultaPedido.Columns.Add("QUANTIDADE", "QUANTIDADE");
            tabelaConsultaPedido.Columns.Add("PRECO", "PRECO");
            tabelaConsultaPedido.Columns.Add("VALOR_TOTAL", "VALOR_TOTAL");
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
                //quebrando a query quando aperta backspace
                //Pesquisar(GerarQueryParaPesquisa(1));
                PesquisarMySQL(GerarQueryParaPesquisa(1));
                        
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
                       

                        while(reader.Read())
                        {
                            int rowIndex = tabelaConsultaPedido.Rows.Add();
                            tabelaConsultaPedido.Rows[rowIndex].Cells["ID_PEDIDO"].Value = Int32.Parse(reader.GetString(0));
                            tabelaConsultaPedido.Rows[rowIndex].Cells["ID_PROD"].Value = reader.GetString(1);
                            tabelaConsultaPedido.Rows[rowIndex].Cells["NOME_PRODUTO"].Value = reader.GetString(2);
                            tabelaConsultaPedido.Rows[rowIndex].Cells["QUANTIDADE"].Value = Int32.Parse(reader.GetString(3));
                            tabelaConsultaPedido.Rows[rowIndex].Cells["PRECO"].Value = double.Parse(reader.GetString(4));
                            tabelaConsultaPedido.Rows[rowIndex].Cells["VALOR_TOTAL"].Value = double.Parse(reader.GetString(5));

                            rowIndex++;
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
            //implementar um método único de pesquisa que recebe essa função como parâmetro 
            //atribuir o valor da string de pesquisa nesse método de pesquisa para o retorno dessa função

            string query = opcao switch
            {
                //criar a tabela no banco de dados com as colunas correspondentes

                //usar um join de duas tabelas que serão criadas no firebird para gerar a query
                1 => $"SELECT ID_PROD, NOME_PRODUTO, QUANTIDADE, PRECO, VALOR_TOTAL FROM TABELA_PEDIDO WHERE NOME_CLIENTE LIKE '%{RegexValidacao(txtCliente.Text)}%'",
                2 => $"SELECT ID_PROD, NOME_PRODUTO, QUANTIDADE, PRECO, VALOR_TOTAL FROM TABELA_PEDIDO WHERE NOME_VENDEDOR LIKE '%{RegexValidacao(txtVendedor.Text)}%'",
                3 => $"SELECT ID_PROD, NOME_PRODUTO, QUANTIDADE, PRECO, VALOR_TOTAL FROM TABELA_PEDIDO WHERE DATA = '{dtpDataIni.Text.Replace("/", ".")}'",
                4 => $"SELECT ID_PROD, NOME_PRODUTO, QUANTIDADE, PRECO, VALOR_TOTAL FROM TABELA_PEDIDO WHERE DATA <= '{dtpDataFim.Text.Replace("/", ".")}'",
                5 => $"SELECT ID_PROD, NOME_PRODUTO, QUANTIDADE, PRECO, VALOR_TOTAL FROM TABELA_PEDIDO WHERE DATA BETWEEN'{dtpDataIni.Text.Replace("/", ".")}' AND '{dtpDataFim.Text.Replace("/", ".")}'",
                6 => $"SELECT ID_PEDIDO, ID_PROD, NOME_PRODUTO, QUANTIDADE, PRECO, VALOR_TOTAL FROM TABELA_PEDIDO WHERE ID_PEDIDO LIKE '{RegexValidaNumero(txtNumero.Text)}%'",
                _ => $"SELECT ID_PEDIDO, ID_PROD, NOME_PRODUTO, QUANTIDADE, PRECO, VALOR_TOTAL FROM TABELA_PEDIDO"

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
                produto.SetQuantidade(Int32.Parse(row.Cells["QUANTIDADE"].Value.ToString()));
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

            if(txtNumero.Text.Length > 0)
            {
                PesquisarComDataReader(GerarQueryParaPesquisa(6));

                if (cbOrdenaPor != null)
                {
                
                    string query = GerarQueryParaPesquisa(6);
                    query += $"ORDER BY {cbOrdenaPor.Text}";
                
                }

            } else
            {
                
            }
        }

        private void txtNumero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Back)
            {
                PesquisarComDataReader(GerarQueryParaPesquisa(6));

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

                string str = tabelaConsultaPedido.SelectedCells[11].Value.ToString();
                TesteImpressao impressao = new TesteImpressao();
                impressao.lista = new List<ProdutoPedido>(ListaParaImpressao3());
                MessageBox.Show(str);
                //impressao.SetIdParaImpressao(Int32.Parse(str));
                //impressao.SetIdParaImpressao(1);
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
                    using(MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        try
                        {
                            while(reader.Read())
                            {
                                ProdutoPedido produto = new ProdutoPedido();
                                produto.SetID(Int32.Parse(reader.GetString(0)));
                                produto.SetNome(reader.GetString(1));
                                produto.SetQuantidade(Int32.Parse(reader.GetString(2)));
                                produto.SetPreco(Double.Parse(reader.GetString(3)));
                                produto.SetValorTotal(produto.GetValorTotal());

                                lista.Add(produto);
                            } 
                        } catch (Exception ex)
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
                                produto.SetQuantidade(Int32.Parse(reader.GetString(2)));
                                produto.SetPreco(Double.Parse(reader.GetString(3)));
                                produto.SetValorTotal(produto.GetValorTotal());

                                lista.Add(produto);


                            }
                        } catch (Exception ex)
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
                Pesquisar(GerarQueryParaPesquisa(3));
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
                Pesquisar(GerarQueryParaPesquisa(4));
            }
            else
            {
                MessageBox.Show("Data final inserida é maior que a data atual!", "Data inválida!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
    }
}
