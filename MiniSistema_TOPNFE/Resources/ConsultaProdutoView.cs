using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using MiniSistema_TOPNFE.Controller;

namespace MiniSistema_TOPNFE.Resources
{
    public partial class ConsultaProdutoView : Form
    {
        public void PesquisaProdutoPorIDOuCodigoDeBarras()
        {
            DBFactory dbf = new DBFactory();
            using (FbConnection conn = dbf.GetConnection())
            {
                conn.Open();
                string query = $"SELECT CODIGO_PRODUTO, CODIGO_BARRA, REFERENCIA, DESCRICAO FROM PRODUTO WHERE CODIGO_PRODUTO LIKE '{Int32.Parse(GettxtDescCodCodBarrasText())}%';";

                using (FbCommand cmd = new FbCommand(query, conn))
                {
                    using (FbDataAdapter adapter = new FbDataAdapter(cmd))
                    {
                        SetTabelaConsultaProdutoDataSource(adapter);
                    }

                }

            }
        }

        public void PesquisaProdutoPorNome()
        {
            DBFactory dbf = new DBFactory();
            using (FbConnection conn = dbf.GetConnection())
            {
                conn.Open();
                string query = $"SELECT CODIGO_PRODUTO, CODIGO_BARRA, REFERENCIA, DESCRICAO FROM PRODUTO WHERE DESCRICAO LIKE '%{GettxtDescCodCodBarrasText()}%';";

                using (FbCommand cmd = new FbCommand(query, conn))
                {
                    using (FbDataAdapter adapter = new FbDataAdapter(cmd))
                    {
                        SetTabelaConsultaProdutoDataSource(adapter);
                    }
                }
            }
        }

        public void PassarInformacoesParaTelaNovoPedido()
        {
            string cell = tabelaConsultaProduto.CurrentCell.Value.ToString();


            CadastroNovoPedidoView view = (CadastroNovoPedidoView)Application.OpenForms["CadastroNovoPedidoView"];

            view.ReceberDadosDeProdutoCopiado(CreateNewObjectProduto());
            view.SettxtCodProdText(cell);
            view.SettxtCodProdText(tabelaConsultaProduto.CurrentCell.Value.ToString());

            this.Hide();
            this.Close();

        }
        public ConsultaProdutoView()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public void SettxtDescCodCodBarrasText(string str)
        {
            txtDescCodCodBarras.Text = str;
        }

        public string GettxtDescCodCodBarrasText()
        {
            string str = txtDescCodCodBarras.Text.ToUpper();
            return str;
        }

        public void SettxtReferenciaText(string str)
        {
            txtReferencia.Text = str;
        }

        public string GettxtReferenciaText()
        {
            return txtReferencia.Text;
        }

        public void SettxtLoteText(string str)
        {
            txtLote.Text = str;
        }

        public string GettxtLoteText()
        {
            return txtLote.Text;
        }

        public void SettxtAplicacaoText(string str)
        {
            txtAplicacao.Text = str;
        }

        public string GettxtAplicacaoText()
        {
            return txtAplicacao.Text;
        }

        private void txtDescCodCodBarras_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(GettxtDescCodCodBarrasText(), out int id))
            {
                PesquisaProdutoPorIDOuCodigoDeBarras();

            }
            else
            {
                PesquisaProdutoPorNome();
            }

        }
        public void SetTabelaConsultaProdutoDataSource(FbDataAdapter adapter)
        {
            DataTable dt = new();
            adapter.Fill(dt);
            tabelaConsultaProduto.DataSource = dt;
        }
        private void tabelaConsultaProduto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PassarInformacoesParaTelaNovoPedido();

        }

        private void tabelaConsultaProduto_KeyPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PassarInformacoesParaTelaNovoPedido();
            }
        }

        private void tabelaConsultaProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == 13)
            {
                PassarInformacoesParaTelaNovoPedido();
            }
        } 

        public Produto CreateNewObjectProduto()
        {

            Produto prod = new Produto();
            prod.SetID(Int32.Parse(tabelaConsultaProduto.CurrentCell.Value.ToString()));
            return prod;

        }
        private void tabelaConsultaProduto_RowEnter(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void txtDescCodCodBarras_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                tabelaConsultaProduto.Focus();
            }
        }
    }


}
