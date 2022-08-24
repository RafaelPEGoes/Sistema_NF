using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using FirebirdSql.Data.FirebirdClient;
using MiniSistema_TOPNFE.Controller;

namespace MiniSistema_TOPNFE.Resources
{
    public partial class AlteraInfoPedido : Form
    {

        public LinhaDataGridVIew linha;
        public AlteraInfoPedido()
        {
            InitializeComponent();
        }

        public void SetContents()
        {
            dtpData.Text = linha.GetData();
            txtIdCliente.Text = linha.GetIdCliente().ToString();
            txtNomeCliente.Text = linha.GetNomeCliente();
            txtIdProduto.Text = linha.GetIDProduto().ToString();
            txtNomeProduto.Text = linha.GetNomeProduto();
            txtQuantidade.Text = linha.GetQuantidade().ToString();
            txtPreco.Text = linha.GetPreco().ToString("C", CultureInfo.CurrentCulture);
            txtValorTotal.Text = linha.GetValorTotal().ToString("C", CultureInfo.CurrentCulture);
            dtpData.Focus();

        }
        private void PesquisaClientePorID()
        {
            DBFactory dbf = new DBFactory();

            using (FbConnection conn = dbf.GetConnection())
            {
                string query = $"SELECT NOME FROM CLIENTE WHERE CODIGO_CLIENTE = {txtIdCliente.Text}";
                conn.Open();
                txtNomeCliente.Clear();
                using (FbCommand cmd = new FbCommand(query, conn))
                {


                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            txtNomeCliente.Text = reader.GetString(0);
                        }
                    }
                }
            }
        }

        private void PesquisaClientePorNome()
        {
            DBFactory dbf = new DBFactory();

            using (FbConnection conn = dbf.GetConnection())
            {
                string query = $"SELECT CODIGO_CLIENTE FROM CLIENTE WHERE NOME CONTAINING '{txtNomeCliente.Text}'";
                conn.Open();
                txtIdCliente.Clear();
                using (FbCommand cmd = new FbCommand(query, conn))
                {
                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            txtIdCliente.Text = reader.GetString(0);
                        }
                    }
                }
            }
        }

        private void PesquisaProdutoPorID()
        {
            DBFactory dbf = new DBFactory();

            using (FbConnection conn = dbf.GetConnection())
            {

                string query = $"SELECT DESCRICAO, PRECO1 FROM PRODUTO WHERE CODIGO_PRODUTO = {txtIdProduto.Text}";
                conn.Open();
                txtNomeProduto.Clear();
                txtPreco.Clear();

                using (FbCommand cmd = new FbCommand(query, conn))
                {
                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            txtNomeProduto.Text = reader.GetString(0);
                            txtPreco.Text = reader.GetString(1);
                        }
                    }
                }
            }
        }

        private void PesquisaProdutoPorNome()
        {
            DBFactory dbf = new DBFactory();

            using (FbConnection conn = dbf.GetConnection())
            {

                string query = $"SELECT CODIGO_PRODUTO, PRECO1 FROM PRODUTO WHERE DESCRICAO CONTAINING '{txtNomeProduto.Text.ToUpper()}'";
                conn.Open();
                txtIdProduto.Clear();
                txtPreco.Clear();

                using (FbCommand cmd = new FbCommand(query, conn))
                {
                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            txtIdProduto.Text = reader.GetString(0);
                            txtPreco.Text = reader.GetString(1);
                        }
                    }
                }
            }
        }
        private void AlteraInfoPedido_Load(object sender, EventArgs e)
        {
            SetContents();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtIdCliente_TextChanged(object sender, EventArgs e)
        {
            if (txtIdCliente.Focused)
            {
                if (!String.IsNullOrEmpty(txtIdCliente.Text))
                {
                    PesquisaClientePorID();
                }
                else
                {
                    txtNomeCliente.Clear();
                }
            }

        }

        private void txtNomeCliente_TextChanged(object sender, EventArgs e)
        {
            if (txtNomeCliente.Focused)
            {
                if (!String.IsNullOrEmpty(txtNomeCliente.Text))
                {
                    PesquisaClientePorNome();
                }
                else
                {
                    txtIdCliente.Clear();
                }
            }

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DBFactory dbf = new DBFactory();

            using (FbConnection conn = dbf.GetConnection())
            {
                using (FbTransaction transaction = conn.BeginTransaction())
                {
                    conn.Open();
                    string query = $"UPDATE TABELA_PEDIDO_ITEMS " +
                        $"SET ID_PRODUTO = {Int32.Parse(txtIdProduto.Text)}, " +
                        $"NOME_PRODUTO = '{txtNomeProduto.Text}', " +
                        $"QUANTIDADE = {double.Parse(txtQuantidade.Text)}, " +
                        $"PRECO = {double.Parse(txtPreco.Text)}, " +
                        $"VALOR_TOTAL = {double.Parse(txtValorTotal.Text)} " +
                        $"WHERE ID_PEDIDO = {linha.GetIDPedido()} AND ID_PRODUTO = {linha.GetIDProduto()}";

                    using (FbCommand cmd = new FbCommand(query, conn, transaction))
                    {
                        try
                        {
                            cmd.ExecuteNonQuery();
                            transaction.Commit();


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            transaction.Rollback();
                        }
                    }
                }

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AtualizaValorTotal()
        {
            //txtValorTotal.Text = double.Parse(txtQuantidade.Text);
        }

        private void txtIdProduto_TextChanged(object sender, EventArgs e)
        {
            if(txtIdProduto.Focused)
            {
                if(!String.IsNullOrEmpty(txtIdProduto.Text))
                {
                    PesquisaProdutoPorID();
                } else
                {
                    txtNomeProduto.Clear();
                }
            }
        }

        private void txtNomeProduto_TextChanged(object sender, EventArgs e)
        {
            if(txtNomeProduto.Focused)
            {
                if(!String.IsNullOrEmpty(txtNomeProduto.Text))
                {
                    PesquisaProdutoPorNome();

                } else
                {
                    txtIdProduto.Clear();
                }
            }
        }

        //private void textBox1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if(e.KeyCode == Keys.Enter)
        //    {
        //        List<String> lista = new List<String>();
        //        String[] separator = { "," };

        //        foreach (String str in textBox1.Text.Split(separator, StringSplitOptions.None))
        //        {
        //            lista.Add(str);
        //        }

        //        foreach (String str in lista)
        //        {
        //            MessageBox.Show(str);
        //        }
        //    }
        //}
    }
}
