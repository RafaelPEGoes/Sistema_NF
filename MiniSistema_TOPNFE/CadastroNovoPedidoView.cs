
using MiniSistema_TOPNFE.Resources;
using MiniSistema_TOPNFE.Controller;
using FirebirdSql.Data.FirebirdClient;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MiniSistema_TOPNFE;

public partial class CadastroNovoPedidoView : Form
{
    public LinhaDataGridVIew linha;

    public void InsereLinhaNoForm()
    {
        DBFactory dbf = new DBFactory();

        using (FbConnection conn = dbf.GetConnection())
        {
            string query = $"SELECT TABELA_PEDIDO.ID_VENDEDOR, " +
                $"TABELA_PEDIDO.ID_CLIENTE, " +
            $"TABELA_PEDIDO_ITEMS.ID_PRODUTO, " +
            $"TABELA_PEDIDO_ITEMS.NOME_PRODUTO, " +
            $"TABELA_PEDIDO_ITEMS.QUANTIDADE, " +
            $"TABELA_PEDIDO_ITEMS.PRECO, " +
            $"TABELA_PEDIDO_ITEMS.VALOR_TOTAL " +
            $"FROM TABELA_PEDIDO_ITEMS, TABELA_PEDIDO ";
            //$"WHERE TABELA_PEDIDO.ID_PEDIDO = {linha.GetIDPedido} " +
            //$"AND TABELA_PEDIDO_ITEMS.ID_PRODUTO = {linha.GetIDProduto()}";

            MessageBox.Show(linha.GetIDPedido().ToString());
            MessageBox.Show(linha.GetIDProduto().ToString());
            using (FbCommand cmd = new FbCommand(query, conn))
            {
                conn.Open();
                using (FbDataReader reader = cmd.ExecuteReader())
                {

                    DataGridViewRow row = tabelaAddProdutos.Rows[tabelaAddProdutos.Rows.Add()];

                    while (reader.Read())
                    {
                        txtIdVendedor.Text = reader.GetString(0);
                        txtIdCpfCliente.Text = reader.GetString(1);
                        txtCodProd.Text = reader.GetString(2);
                        txtQuantidade.Text = reader.GetString(4);
                        row.Cells[0].Value = reader.GetString(2);
                        row.Cells[1].Value = reader.GetString(3);
                        row.Cells[2].Value = reader.GetString(4);
                        row.Cells[3].Value = reader.GetString(5);
                        row.Cells[4].Value = reader.GetString(6);

                    }
                }
            }
        }
    }
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
            using (FbCommand cmd = new FbCommand(query, conn))
            {
                using (FbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
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
            string query = $"SELECT NOME FROM CLIENTE WHERE CODIGO_CLIENTE = {Int32.Parse(txtIdVendedor.Text)}";

            using (FbCommand cmd = new FbCommand(query, conn))
            {
                txtVendedor.Clear();

                using (FbDataReader reader = cmd.ExecuteReader())
                {
                    try
                    {

                        if (reader.HasRows)
                        {
                            //melhorar essa parte ainda
                            //nao chega no messagebox indicando que não tem matches no banco
                            //se não usar o reader.Read() dentro do if

                            while (reader.Read())
                            {
                                txtVendedor.Text = reader.GetString(0);
                            }

                        }
                        else
                        {
                            MessageBox.Show($"Não há vendedor cadastrado no banco de dados com o nome {RegexValidacao(GetIDVendedor().ToUpper())}.", "Vendedor inexistente!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtIdVendedor.Clear();
                            txtVendedor.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Chegou na exception");


                    }
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

        using (FbConnection conn = Connection())
        {
            string query = $"SELECT NOME FROM CLIENTE WHERE NOME LIKE '%{RegexValidacao(GetIDVendedor().ToUpper())}%';";

            using (FbCommand cmd = new FbCommand(query, conn))
            {
                txtVendedor.Clear();

                using (FbDataReader reader = cmd.ExecuteReader())
                {
                    try
                    {
                        if (reader.Read())
                        {
                            while (reader.Read())
                            {
                                txtVendedor.Text = reader.GetString(0);
                            }

                        }
                        else
                        {
                            MessageBox.Show($"Não há vendedor cadastrado no banco de dados com o nome {RegexValidacao(GetIDVendedor().ToUpper())}.", "Vendedor inexistente!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtIdVendedor.Clear();
                            txtVendedor.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Chegou na exception");
                    }
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
                txtNomeCliente.Clear();
                txtRazaoSocial.Clear();
                txtEndereco.Clear();

                using (FbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            txtNomeCliente.Text = reader.GetString(0);
                            txtRazaoSocial.Text = reader.GetString(1);
                            txtEndereco.Text = reader.GetString(2);
                        }
                    }
                    else
                    {
                        MessageBox.Show("ID Inválido!");
                    }


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
                txtNomeCliente.Clear();
                txtRazaoSocial.Clear();
                txtEndereco.Clear();

                using (FbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        txtNomeCliente.Text = reader.GetString(0);
                        txtRazaoSocial.Text = reader.GetString(1);
                        txtEndereco.Text = reader.GetString(2);
                    }


                }


            }


        }
    }

    public void PesquisaProdutoPorID()
    {
        using (FbConnection conn = Connection())
        {

            string query = $"SELECT DESCRICAO, PRECO1 FROM PRODUTO WHERE CODIGO_PRODUTO = {RegexValidacao(GettxtCodProdText())};";

            using (FbCommand cmd = new FbCommand(query, conn))
            {
                using (FbDataReader reader = cmd.ExecuteReader())
                {
                    txtNomeProd.Clear();
                    txtPreco.Clear();

                    while (reader.Read())
                    {

                        if (reader.HasRows)
                        {

                            txtNomeProd.Text = reader.GetString(0);
                            txtPreco.Text = reader.GetString(1);
                        }



                    }
                }
            }
        }

    }

    public FbConnection IsConnectionOpen(FbConnection conn)
    {
        if (conn.State != System.Data.ConnectionState.Open)
        {
            conn.Open();
        }

        return conn;
    }

    public void SetTxtValorProdutosText(double valor)
    {
        double totalProdutos;
        if (!txtValorProdutos.Text.Equals(""))
        {
            txtValorProdutos.Text.Replace("R$ ", "");
            totalProdutos = Double.Parse(txtValorProdutos.Text);
            totalProdutos += valor;
            txtValorProdutos.Text = $"R$ {totalProdutos}";
        }
        else
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
            if (Double.Parse(txtQuantidade.Text) > 0)
            {
                DataGridViewRow row = tabelaAddProdutos.Rows[tabelaAddProdutos.Rows.Add()];
                try
                {

                    row.Cells[0].Value = Int32.Parse(txtCodProd.Text);
                    row.Cells[1].Value = txtNomeProd.Text;
                    row.Cells[2].Value = Int32.Parse(txtQuantidade.Text);
                    row.Cells[3].Value = Double.Parse(txtPreco.Text);
                    row.Cells[4].Value = Double.Parse(txtPreco.Text) * Double.Parse(txtQuantidade.Text);

                    txtCodProd.Focus();
                    txtCodProd.Clear();
                    txtQuantidade.Clear();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(Text, ex.Message);

                }
                finally
                {
                    txtCodProd.Clear();
                    txtCodProd.Clear();
                    txtQuantidade.Clear();
                    txtCodProd.Focus();
                }
            }
            else
            {
                MessageBox.Show("Quantidade não pode ser zero!", "Quantidade Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantidade.Clear();
                txtQuantidade.Focus();
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
            IsConnectionOpen(conn);

            string query = $"SELECT FIRST 1 ID_PEDIDO FROM TABELA_PEDIDO ORDER BY ID_PEDIDO DESC";

            using (FbCommand cmd = new FbCommand(query, conn))
            {
                using (FbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        last_id = reader.GetInt32(0);
                    }
                    else
                    {
                        return 1;
                    }

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

    public string SelecionaIDVendedor()
    {
        string nome = "";
        using (FbConnection conn = Connection())
        {
            using (FbTransaction transaction = conn.BeginTransaction())
            {
                string query = "SELECT CODIGO_CLIENTE FROM CLIENTE WHERE NOME = '@NOME'";

                using (FbCommand cmd = new FbCommand(query, conn, transaction))
                {

                    cmd.Parameters.AddWithValue("@NOME", txtVendedor.Text.ToUpper());
                    using (FbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            nome = reader.GetString(0);
                        }
                    }
                }
            }
        }

        return nome;
    }

    public bool InsereProdutoNaTabelaPedido(int id)
    {
        using (FbConnection conn = Connection())
        {
            using (FbTransaction transaction = conn.BeginTransaction())
            {
                try
                {

                    string query = "INSERT INTO TABELA_PEDIDO (ID_PEDIDO, ID_VENDEDOR, ID_CLIENTE, DATA_VENDA) VALUES(@ID_PEDIDO, @ID_VENDEDOR, @ID_CLIENTE, @DATA_VENDA);";

                    using (FbCommand cmd = new FbCommand(query, conn, transaction))
                    {
                        IsConnectionOpen(conn);
                        cmd.Parameters.AddWithValue("@ID_PEDIDO", id);
                        cmd.Parameters.AddWithValue("@ID_VENDEDOR", txtIdVendedor.Text);
                        cmd.Parameters.AddWithValue("@ID_CLIENTE", txtIdCpfCliente.Text);
                        cmd.Parameters.AddWithValue("@DATA_VENDA", DateTime.Now);
                        cmd.ExecuteNonQuery();

                    }

                    transaction.Commit();
                    return true;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    conn.Close();
                    transaction.Dispose();
                }
            }


        }
    }

    public bool InsereProdutoNaTabelaPedidoItems(int id)
    {
        using (FbConnection conn = Connection())
        {
            using (FbTransaction transaction = conn.BeginTransaction())
            {
                try
                {

                    foreach (DataGridViewRow row in tabelaAddProdutos.Rows)
                    {
                        string query = "INSERT INTO TABELA_PEDIDO_ITEMS (ID_PEDIDO, ID_PRODUTO, NOME_PRODUTO, QUANTIDADE, PRECO, VALOR_TOTAL) VALUES(@ID_PEDIDO, @ID_PROD, @NOME_PRODUTO, @QUANTIDADE, @PRECO, @VALOR_TOTAL);";

                        using (FbCommand cmd = new FbCommand(query, conn, transaction))
                        {

                            IsConnectionOpen(conn);
                            cmd.Parameters.AddWithValue("@ID_PEDIDO", id);
                            cmd.Parameters.AddWithValue("@ID_PROD", row.Cells["colid_prod"].Value);
                            cmd.Parameters.AddWithValue("@NOME_PRODUTO", row.Cells["colProduto"].Value);
                            cmd.Parameters.AddWithValue("@QUANTIDADE", row.Cells["colQuantidade"].Value);
                            cmd.Parameters.AddWithValue("@PRECO", row.Cells["colValorUnitario"].Value);
                            cmd.Parameters.AddWithValue("@VALOR_TOTAL", row.Cells["colValorFinal"].Value);
                            cmd.ExecuteNonQuery();

                        }
                    }


                    MessageBox.Show("Pedido inserido no banco com sucesso!", "Sucesso na operação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    transaction.Commit();
                    return true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;

                }
                finally
                {
                    conn.Close();
                    transaction.Dispose();
                }
            }

        }
    }

    public void InsereProdutoNoBD()
    {
        using (FbConnection conn = Connection())
        {

            foreach (DataGridViewRow row in tabelaAddProdutos.Rows)
            {

                int last_id = PesquisaUltimoIDNoBanco();

                string query = "INSERT INTO TABELA_PEDIDO_ITEMS (ID_PEDIDO, ID_PROD, NOME_PRODUTO, QUANTIDADE, PRECO, VALOR_TOTAL) VALUES(@ID_PEDIDO, @ID_PROD, @NOME_PRODUTO, @QUANTIDADE, @PRECO, @VALOR_TOTAL)";

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

            }
            catch (Exception e)
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
        if (produto.GetID != null)
        {
            txtCodProd.Clear();

            txtCodProd.Text = produto.GetID().ToString();
        }
    }
    private void txtIdVendedor_TextChanged(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(txtIdVendedor.Text))
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
        else
        {
            txtVendedor.Clear();
        }


    }

    private bool ValidaCamposNumericosAntesDeSalvar(TextBox textbox, string nomeCampo)
    {
        if (!String.IsNullOrEmpty(textbox.Text))
        {
            bool eNumero = Int32.TryParse(textbox.Text, out int id);

            if (eNumero)
            {
                return true;

            }
            else
            {
                MessageBox.Show($"Valor inválido para o campo {nomeCampo}, que deve ser numérico.", "Valor inválido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

        }
        else
        {
            MessageBox.Show($"Campo {nomeCampo} não preenchido!", "Campo vazio!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            textbox.Focus();
            return false;
        }
    }

    private bool ValidaCamposTextoAntesDeSalvar(TextBox textbox, string nomeCampo)
    {
        if (!String.IsNullOrEmpty(textbox.Text))
        {
            bool eNumero = Int32.TryParse(textbox.Text, out int id);

            if (eNumero)
            {

                MessageBox.Show($"Valor inválido para o campo {nomeCampo}", "Valor inválido!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }

        }
        else
        {
            MessageBox.Show($"Campo {nomeCampo} não preenchido!", "Campo vazio!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            textbox.Focus();
            return false;
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        //VER SE HÁ MELHORIAS A SEREM FEITAS

        if ((txtIdVendedor.Text.Length > 0 && txtVendedor.Text.Length > 0 && txtIdCpfCliente.Text.Length > 0 && txtNomeCliente.Text.Length > 0))
        {
            if (ValidaCamposNumericosAntesDeSalvar(txtIdVendedor, "ID Vendedor"))
            {
                if (ValidaCamposTextoAntesDeSalvar(txtVendedor, "Nome Vendedor"))
                {
                    if (ValidaCamposNumericosAntesDeSalvar(txtIdCpfCliente, "ID Cliente"))
                    {
                        if (ValidaCamposTextoAntesDeSalvar(txtNomeCliente, "Nome Cliente"))
                        {
                            int id = PesquisaUltimoIDNoBanco();
                            InsereProdutoNaTabelaPedido(id);
                            InsereProdutoNaTabelaPedidoItems(id);
                            tabelaAddProdutos.Rows.Clear();
                            ConsultaPedidosView cpv = (ConsultaPedidosView)Application.OpenForms["ConsultaPedidosView"];
                            cpv.ClearTabelaPedidos();
                            cpv.PesquisarComDataReaderFirebird(cpv.testNewQueries("default"));

                        }
                    }
                }
            }

        }
        else
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
        if (txtCodProd.Text.Length > 0)
        {
            if (Int32.TryParse(txtCodProd.Text, out int id))
            {
                PesquisaProdutoPorID();
            }


        }
        else
        {
            txtPreco.Clear();
            txtNomeProd.Clear();
        }

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

    private void tabelaAddProdutos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {
        double valor = 0;

        for (int i = 0; i < tabelaAddProdutos.Rows.Count; i++)
        {

            valor += double.Parse(tabelaAddProdutos.Rows[i].Cells[4].Value.ToString());

        }

        txtValorTotal.Text = valor.ToString("C", CultureInfo.CurrentCulture);
        txtValorProdutos.Text = valor.ToString("C", CultureInfo.CurrentCulture);
    }

    private void CadastroNovoPedidoView_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F4)
        {
            MessageBox.Show("F4 pressed");
            button1_Click(sender, e);

        }
        if (e.KeyCode == Keys.Enter)
        {
            MessageBox.Show("Enter pressed");
            button1_Click(sender, e);
        }
    }

    private void CadastroNovoPedidoView_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == 13)
        {
            MessageBox.Show("enter pressed");
        }
    }

    private List<TextBox> ListaCamposVendedor()
    {
        List<TextBox> lista = new List<TextBox>();
        lista.Add(txtIdVendedor);
        lista.Add(txtVendedor);
        return lista;
    }

    private void txtIdVendedor_KeyDown(object sender, KeyEventArgs e)
    {
        IsThereEmptyTextBoxes(e, ListaCamposVendedor(), txtIdCpfCliente, "vendedor");
    }

    private List<TextBox> ListaCamposCliente()
    {
        List<TextBox> lista = new List<TextBox>();

        lista.Add(txtIdCpfCliente);
        lista.Add(txtNomeCliente);
        lista.Add(txtRazaoSocial);
        lista.Add(txtEndereco);

        return lista;
    }

    private void IsThereEmptyTextBoxes(KeyEventArgs e, List<TextBox> lista, TextBox nextToFocusOn, string secao)
    {
        if (e.KeyCode == Keys.Enter)
        {
            bool allTextBoxesCompleted = true;

            foreach (TextBox textbox in lista)
            {
                if (String.IsNullOrEmpty(textbox.Text))
                {
                    textbox.Focus();
                    MessageBox.Show($"Há campos de informação de {secao} que não foram preenchidos!", "Campos vazios!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            if (allTextBoxesCompleted)
            {
                nextToFocusOn.Focus();
            }
        }
    }


    private void txtIdCpfCliente_KeyDown(object sender, KeyEventArgs e)
    {
        IsThereEmptyTextBoxes(e, ListaCamposCliente(), txtCodProd, "cliente");

    }

    private List<TextBox> ListaCamposProduto()
    {
        List<TextBox> lista = new List<TextBox>();

        lista.Add(txtCodProd);
        lista.Add(txtNomeProd);

        return lista;
    }

    private void txtCodProd_KeyDown(object sender, KeyEventArgs e)
    {
        IsThereEmptyTextBoxes(e, ListaCamposProduto(), txtQuantidade, "produto");
    }

    private List<TextBox> ListaCamposProdutoParaAdicionar()
    {
        List<TextBox> lista = new List<TextBox>();

        lista.Add(txtCodProd);
        lista.Add(txtNomeProd);
        lista.Add(txtQuantidade);
        lista.Add(txtPreco);

        return lista;
    }

    private void txtQuantidade_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            bool allTextBoxesCompleted = true;
            List<TextBox> lista = new List<TextBox>(ListaCamposProdutoParaAdicionar());

            foreach (TextBox textbox in lista)
            {
                if (String.IsNullOrEmpty(textbox.Text))
                {
                    textbox.Focus();
                    MessageBox.Show($"Há campos de informação de produto que não foram preenchidos!", "Campos vazios!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            if (allTextBoxesCompleted)
            {
                btnAdicionar.Focus();

            }
        }

    }

    private void txtIdVendedor_Leave(object sender, EventArgs e)
    {
        bool eNumero = Int32.TryParse(txtIdVendedor.Text, out int id);

        if (!eNumero)
        {
            txtIdVendedor.Text = SelecionaIDVendedor();
        }
    }
}
