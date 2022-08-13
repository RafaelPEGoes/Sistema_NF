
using MiniSistema_TOPNFE.Resources;
using MiniSistema_TOPNFE.Controller;
using FirebirdSql.Data.FirebirdClient;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MiniSistema_TOPNFE;

public partial class CadastroNovoPedidoView : Form
{
    public CadastroNovoPedidoView()
    {
        InitializeComponent();
        txtIdVendedor.Focus();
        this.WindowState = FormWindowState.Maximized;
    }

    #region metodos
    public FbConnection Connection()
    {

        FbConnection conn = null;

        try
        {
            DBFactory dbFactory = new DBFactory();
            conn = dbFactory.GetConnection();
            conn.Open();

        }
        catch (Exception e)
        {
            MessageBox.Show($"ERRO NA CONEXÃO AO BANCO DE DADOS: {e.Message}");
            conn.Close();
        }

        return conn;

    }

    public bool isTxtIdVendedorEmpty()
    {
        if (txtIdVendedor.Text.Length == 0)
        {
            return true;
        }

        return false;
    }

    public void Pesquisa(string query)
    {
        using (FbConnection conn = Connection())
        {
            using(FbCommand cmd = new FbCommand(query, conn))
            {
                using (FbDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        //do something
                    }
                }
            }
        }
    }

    public void PesquisaVendedorPorID()
    {

        using (FbConnection conn = Connection())
        {
            string query = $"SELECT NOME FROM CLIENTE WHERE CODIGO_CLIENTE={Int32.Parse(GetIDVendedor())}";

            using (FbCommand cmd = new FbCommand(query, conn))
            {
                using (FbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        txtVendedor.Text = reader.GetString(0);
                    }

                    reader.Close();
                }


            }


        }


    }
    private string RegexValidacao(string str)
    {
        return Regex.Replace(str, "[^0-9a-zA-Z]+", "");
    }
    public void PesquisaVendedorPorNome()
    {
        isTxtIdVendedorEmpty();

        using (FbConnection conn = Connection())
        {
            //PRESTAR ATENÇÃO: APARENTEMENTE INSERIR UMA ASPAS MESMO QUE SEM INTENÇÃO QUEBRA A QUERY
            string query = $"SELECT NOME FROM CLIENTE WHERE NOME LIKE '%{RegexValidacao(GetIDVendedor().ToUpper())}%';";

            using (FbCommand cmd = new FbCommand(query, conn))
            {

                using (FbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        txtVendedor.Text = reader.GetString(0);
                    }

                    reader.Close();
                }


            }


        }


    }

    public void PesquisaClientePorID()
    {
        using (FbConnection conn = Connection())
        {
            //PRESTAR ATENÇÃO: APARENTEMENTE INSERIR UMA ASPAS MESMO QUE SEM INTENÇÃO QUEBRA A QUERY
            string query = $"SELECT NOME, FANTASIA, ENDERECO1 FROM CLIENTE WHERE CODIGO_CLIENTE={Int32.Parse(RegexValidacao(GetIDCliente()))};";

            using (FbCommand cmd = new FbCommand(query, conn))
            {

                using (FbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        txtNomeCliente.Text = reader.GetString(0);
                        txtRazaoSocial.Text = reader.GetString(1);
                        txtEndereco.Text = reader.GetString(2);
                    }

                    reader.Close();
                }


            }


        }
        //OR CNPJ_CPF LIKE '%{Int32.Parse(GetIDCliente())}%'
    }

    public void PesquisaClientePorNome()
    {
        using (FbConnection conn = Connection())

        {
            //PRESTAR ATENÇÃO: APARENTEMENTE INSERIR UMA ASPAS MESMO QUE SEM INTENÇÃO QUEBRA A QUERY
            string query = $"SELECT NOME, FANTASIA, ENDERECO1 FROM CLIENTE WHERE NOME LIKE '%{RegexValidacao(GetIDCliente().ToUpper())}%';";

            using (FbCommand cmd = new FbCommand(query, conn))
            {

                using (FbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        txtNomeCliente.Text = reader.GetString(0);
                        txtRazaoSocial.Text = reader.GetString(1);
                        txtEndereco.Text = reader.GetString(2);
                    }

                    reader.Close();
                }


            }


        }
    }

    public void PesquisaProdutoPorID()
    {
        using (FbConnection conn = Connection())
        {
            //PRESTAR ATENÇÃO: APARENTEMENTE INSERIR UMA ASPAS MESMO QUE SEM INTENÇÃO QUEBRA A QUERY
            string query = $"SELECT DESCRICAO, PRECO1 FROM PRODUTO WHERE CODIGO_PRODUTO LIKE '%{RegexValidacao(GettxtCodProdText())}%';";

            using (FbCommand cmd = new FbCommand(query, conn))
            {
                using (FbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        txtNomeProd.Text = reader.GetString(0);
                        txtPreco.Text = reader.GetString(1);
                    }
                }
            }
        }

        //retorna os dados do produto pesquisado na tela
        //consulta produto

    }

    public void SetTxtValorProdutosText(double valor)
    {
        double totalProdutos;
        if(!txtValorProdutos.Text.Equals(""))
        {
            txtValorProdutos.Text.Replace("R$ ", "");
            totalProdutos = Double.Parse(txtValorProdutos.Text);
            totalProdutos += valor;
            txtValorProdutos.Text = $"R$ {totalProdutos}";
        } else
        {
            totalProdutos = valor;
            txtValorProdutos.Text = $"R$ {totalProdutos}";
        }
        
    }

    public void SetTxtValorTotalText(double valor)
    {
        //melhorar os dois, está causando exception
        double totalProdutos;
        if (!txtValorProdutos.Text.Equals(""))
        {
            txtValorProdutos.Text.Replace("R$ ", "");
            totalProdutos = Double.Parse(txtValorTotal.Text);
            totalProdutos += valor;
            txtValorTotal.Text = $"R$ {totalProdutos}";
        }
        else
        {
            totalProdutos = valor;
            txtValorTotal.Text = $"R$ {totalProdutos}";
        }
    }

    public void AdicionaProdutoAoDataGrid()
    {


        if (txtCodProd.Text.Length > 0 && txtQuantidade.Text.Length > 0 && txtPreco.Text.Length > 0)
        {

            DataGridViewRow row = tabelaAddProdutos.Rows[tabelaAddProdutos.Rows.Add()];
            try
            {
                double precoTotal = Double.Parse(txtPreco.Text) * Double.Parse(txtQuantidade.Text);
                row.Cells[0].Value = Int32.Parse(txtCodProd.Text);
                row.Cells[1].Value = txtNomeProd.Text;
                row.Cells[2].Value = Int32.Parse(txtQuantidade.Text);
                row.Cells[3].Value = Double.Parse(txtPreco.Text);
                row.Cells[4].Value = Double.Parse(txtPreco.Text) * Double.Parse(txtQuantidade.Text);

                //SetTxtValorProdutosText(precoTotal);
                //SetTxtValorTotalText(precoTotal);
                txtCodProd.Focus();
                txtCodProd.Clear();
                txtQuantidade.Clear();
            } catch(Exception ex)
            {
                
                MessageBox.Show(Text, ex.Message);

            } finally
            {
                txtCodProd.Clear();
                txtCodProd.Clear();
                txtQuantidade.Clear();
                txtCodProd.Focus();
            }
            
        }
        else
        {

            if (txtCodProd.Text.Length == 0 && txtQuantidade.Text.Length == 0)
            {
                MessageBox.Show("Código do produto e quantidade não informados!");
                txtCodProd.Focus();
            }

            else if (txtCodProd.Text.Length == 0)
            {
                MessageBox.Show("Código do produto não informado!");
                txtCodProd.Focus();
            }

            else if (txtQuantidade.Text.Length == 0)
            {
                MessageBox.Show("Quantidade do produto não informado!");
                txtQuantidade.Focus();
            }
            else if (txtPreco.Text.Length == 0)
            {
                MessageBox.Show("Preço do produto não informado!");
                txtPreco.Focus();
            }
        }

    }
    public void SetCamposComDadosProduto(string nome, string preco)
    {
        txtNomeProd.Text = nome;
        txtCodProd.Text = preco;

    }

    public int PesquisaUltimoIDNoBanco()
    {
        int last_id = 0;

        using (FbConnection conn = Connection())
        {
            conn.Open();

            string query = $"SELECT ID_PEDIDO FROM TABELA_PEDIDO ORDER BY ID_PEDIDO DESC";

            using (FbCommand cmd = new FbCommand(query, conn))
            {
                using (FbDataReader reader = cmd.ExecuteReader())
                {
                    last_id = reader.GetInt32(0);
                }
            }
        }

        last_id++;
        return last_id;
    }

    public int PesquisaUltimoIDNoBancoMySQL()
    {
        int last_id = 0;

        using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1;database=test_minisistema_topnfe;uid=root;pwd=jujuba99;"))
        {

            string query = $"SELECT ID_PEDIDO FROM TABELA_PEDIDO ORDER BY ID_PEDIDO DESC LIMIT 1";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        last_id = reader.GetInt32(0);
                    }

                    conn.Close();
                }
            }
        }

        last_id += 1;
        return last_id;
    }

    public void InsereProdutoNoBD()
    {
        //Insere o 
        using (FbConnection conn = Connection())
        {
            using (FbDataAdapter adapter = new FbDataAdapter())
            {

                foreach (DataGridViewRow row in tabelaAddProdutos.Rows)
                {

                    int last_id = PesquisaUltimoIDNoBanco();

                    string query = "INSERT INTO TABELA_PEDIDO (ID_PEDIDO, ID_PROD, NOME_PRODUTO, QUANTIDADE, PRECO, VALOR_TOTAL) VALUES(@ID_PEDIDO, @ID_PROD, @NOME_PRODUTO, @QUANTIDADE, @PRECO, @VALOR_TOTAL)";

                    using (FbCommand cmd = new FbCommand(query, conn))
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@ID_PEDIDO", last_id);
                        cmd.Parameters.AddWithValue("@ID_PROD", row.Cells[0].Value);
                        cmd.Parameters.AddWithValue("@NOME_PRODUTO", row.Cells[1].Value);
                        cmd.Parameters.AddWithValue("@QUANTIDADE", row.Cells[2].Value);
                        cmd.Parameters.AddWithValue("@PRECO", row.Cells[3].Value);
                        cmd.Parameters.AddWithValue("@VALOR_TOTAL", row.Cells[4].Value);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }

            }

        }
    }
    public void InsereProdutoNoBDMySQL()
    {
        //Insere o 
        using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1;database=test_minisistema_topnfe;uid=root;pwd=jujuba99;"))
        {

            int last_id = PesquisaUltimoIDNoBancoMySQL();

            try
            {
                foreach (DataGridViewRow row in tabelaAddProdutos.Rows)
                {

                    string query = "INSERT INTO TABELA_PEDIDO (ID_PEDIDO, ID_PROD, NOME_PRODUTO, QUANTIDADE, PRECO, VALOR_TOTAL) VALUES(@ID_PEDIDO, @ID_PROD, @NOME_PRODUTO, @QUANTIDADE, @PRECO, @VALOR_TOTAL)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        conn.Open();

                        //int idProduto = Int32.Parse(row.Cells[0].Value.ToString());
                        //string nomeProduto = row.Cells[1].Value.ToString();
                        //int quantidade = Int32.Parse(row.Cells[2].Value.ToString());
                        //double preco = Double.Parse(row.Cells[3].Value.ToString());
                        //double valorTotal = Double.Parse(row.Cells[4].Value.ToString());

                        cmd.Parameters.AddWithValue("@ID_PEDIDO", last_id);
                        cmd.Parameters.AddWithValue("@ID_PROD", row.Cells[0].Value);
                        cmd.Parameters.AddWithValue("@NOME_PRODUTO", row.Cells[1].Value);
                        cmd.Parameters.AddWithValue("@QUANTIDADE", row.Cells[2].Value);
                        cmd.Parameters.AddWithValue("@PRECO", row.Cells[3].Value);
                        cmd.Parameters.AddWithValue("@VALOR_TOTAL", row.Cells[4].Value);
                        cmd.ExecuteNonQuery();

                        conn.Close();

                    }

                }

                MessageBox.Show("Pedido inserido no banco de dados com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            } catch(Exception e)
            {
                MessageBox.Show($"Erro: {e.Message}", "Falha!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }
    }

    #endregion

    #region getters and setters
    public string GetNumero()
    {
        return txtNumeroPed.Text;
    }

    public string GetIDVendedor()
    {
        string idVendedor = txtIdVendedor.Text;
        return idVendedor;
    }
    public void SetIDVendedor(int id)
    {
        string str = id.ToString();
        txtIdVendedor.Text = str;
    }
    public string GettxtCodProdText()
    {
        return txtCodProd.Text;
    }

    public void SettxtCodProdText(string text)
    {
        txtCodProd.Text = text;
    }

    public string GetTxtNomeProd()
    {
        return txtNomeProd.Text;
    }

    public void SetTxtNomeProd(string str)
    {
        txtNomeProd.Text = str;
    }
    public int GetQuantidade()
    {
        //APRIMORAR AINDA
        try
        {
            int qnt = Int32.Parse(txtQuantidade.Text);
            return qnt;
        }
        catch
        {
            return -1;
        }


    }

    public double GetPreco()
    {
        double preco = Double.Parse(txtPreco.Text);
        return preco;
    }

    public void SetPreco(string str)
    {
        double preco = Double.Parse(str);
    }

    public string GetIDCliente()
    {
        string id = txtIdCpfCliente.Text;
        return id;
    }


    #endregion

    #region eventos
    private void txtVendedor_TextChanged(object sender, EventArgs e)
    {

    }

    private void txtIdVendedor_KeyPress(object sender, KeyEventArgs e)
    {

    }

    public void ReceberDadosDeProdutoCopiado(Produto produto)
    {
        if(produto.GetID != null)
        {
            txtCodProd.Clear();

            txtCodProd.Text = produto.GetID().ToString();
        }
    }
    private void txtIdVendedor_TextChanged(object sender, EventArgs e)
    {

        if (Int32.TryParse(txtIdVendedor.Text, out int id))
        {

            PesquisaVendedorPorID();

        }
        else
        {

            PesquisaVendedorPorNome();

        }

    }

    private void button1_Click(object sender, EventArgs e)
    {
        //VER SE HÁ MELHORIAS A SEREM FEITAS

        if((txtIdVendedor.Text.Length > 0 && txtVendedor.Text.Length > 0 && txtIdCpfCliente.Text.Length > 0 && txtNomeCliente.Text.Length > 0))
        {
            InsereProdutoNoBDMySQL();
            tabelaAddProdutos.Rows.Clear();
        } else
        {
            MessageBox.Show("Há campos que não foram preenchidos!", "Campos Vazios!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        
    }

    private void Form2_Load(object sender, EventArgs e)
    {

    }

    private void label3_Click(object sender, EventArgs e)
    {

    }

    private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
    {

    }

    private void label3_Click_1(object sender, EventArgs e)
    {

    }

    private void panel1_Paint(object sender, PaintEventArgs e)
    {

    }

    private void CadastroNovoPedido_Load(object sender, EventArgs e)
    {

    }

    private void label4_Click(object sender, EventArgs e)
    {

    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void btnPesquisaPorNomeID_Click(object sender, EventArgs e)
    {
        ConsultaProdutoView view = new();
        view.SetTxtDescCodCodBarrasText(txtCodProd.Text);
        view.Show();
    }
    private void txtIdCpfCliente_TextChanged(object sender, EventArgs e)
    {
        if (Int32.TryParse(txtIdCpfCliente.Text, out int id))
        {
            PesquisaClientePorID();
        }
        else
        {
            PesquisaClientePorNome();
        }

    }


    #endregion

    private void txtCodProd_TextChanged(object sender, EventArgs e)
    {
        PesquisaProdutoPorID();
    }

    private void btnAdicionar_Click(object sender, EventArgs e)
    {
        AdicionaProdutoAoDataGrid();
    }

    private void CadastroNovoPedidoView_Load(object sender, EventArgs e)
    {

    }
    private void CadastroNovoPedidoView_Shown(object sender, EventArgs e)
    {
        txtIdVendedor.Focus();
    }

    private void panel2_Paint(object sender, PaintEventArgs e)
    {

    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }
}
