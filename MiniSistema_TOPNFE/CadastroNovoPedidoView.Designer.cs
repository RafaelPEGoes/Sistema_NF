namespace MiniSistema_TOPNFE
{
    partial class CadastroNovoPedidoView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblIDVendedor = new System.Windows.Forms.Label();
            this.txtIdVendedor = new System.Windows.Forms.TextBox();
            this.txtVendedor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumeroPed = new System.Windows.Forms.TextBox();
            this.lblNumero = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtIdCpfCliente = new System.Windows.Forms.TextBox();
            this.btnProcessar = new System.Windows.Forms.Button();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.lblEndereco = new System.Windows.Forms.Label();
            this.lblRazaoSocial = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtRazaoSocial = new System.Windows.Forms.TextBox();
            this.txtNomeCliente = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.txtValorProdutos = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tabelaAddProdutos = new System.Windows.Forms.DataGridView();
            this.colid_prod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.lblNomeProd = new System.Windows.Forms.Label();
            this.lblEstoque = new System.Windows.Forms.Label();
            this.lblReserva = new System.Windows.Forms.Label();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.lblPreco = new System.Windows.Forms.Label();
            this.lblModalidade = new System.Windows.Forms.Label();
            this.lblCodProd = new System.Windows.Forms.Label();
            this.cbModalidade = new System.Windows.Forms.ComboBox();
            this.txtNomeProd = new System.Windows.Forms.TextBox();
            this.txtEstoque = new System.Windows.Forms.TextBox();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.txtReserva = new System.Windows.Forms.TextBox();
            this.txtCodProd = new System.Windows.Forms.TextBox();
            this.btnPesquisaPorNomeID = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaAddProdutos)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnSalvar);
            this.panel1.Location = new System.Drawing.Point(1674, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 70);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(13, 22);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(94, 29);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(121, 22);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(94, 29);
            this.btnSalvar.TabIndex = 17;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblIDVendedor);
            this.panel2.Controls.Add(this.txtIdVendedor);
            this.panel2.Controls.Add(this.txtVendedor);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtNumeroPed);
            this.panel2.Controls.Add(this.lblNumero);
            this.panel2.Location = new System.Drawing.Point(2, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1679, 70);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // lblIDVendedor
            // 
            this.lblIDVendedor.AutoSize = true;
            this.lblIDVendedor.Location = new System.Drawing.Point(110, 4);
            this.lblIDVendedor.Name = "lblIDVendedor";
            this.lblIDVendedor.Size = new System.Drawing.Size(24, 20);
            this.lblIDVendedor.TabIndex = 4;
            this.lblIDVendedor.Text = "ID";
            this.lblIDVendedor.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtIdVendedor
            // 
            this.txtIdVendedor.Location = new System.Drawing.Point(110, 27);
            this.txtIdVendedor.Name = "txtIdVendedor";
            this.txtIdVendedor.Size = new System.Drawing.Size(73, 27);
            this.txtIdVendedor.TabIndex = 2;
            this.txtIdVendedor.TextChanged += new System.EventHandler(this.txtIdVendedor_TextChanged);
            this.txtIdVendedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdVendedor_KeyDown);
            this.txtIdVendedor.Leave += new System.EventHandler(this.txtIdVendedor_Leave);
            // 
            // txtVendedor
            // 
            this.txtVendedor.Location = new System.Drawing.Point(200, 27);
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.Size = new System.Drawing.Size(230, 27);
            this.txtVendedor.TabIndex = 3;
            this.txtVendedor.TextChanged += new System.EventHandler(this.txtVendedor_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Vendedor";
            // 
            // txtNumeroPed
            // 
            this.txtNumeroPed.Enabled = false;
            this.txtNumeroPed.Location = new System.Drawing.Point(13, 27);
            this.txtNumeroPed.Name = "txtNumeroPed";
            this.txtNumeroPed.Size = new System.Drawing.Size(80, 27);
            this.txtNumeroPed.TabIndex = 0;
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(13, 4);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(63, 20);
            this.lblNumero.TabIndex = 0;
            this.lblNumero.Text = "Número";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "ID / CPF / CNPJ Cliente";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtIdCpfCliente);
            this.panel3.Controls.Add(this.btnProcessar);
            this.panel3.Controls.Add(this.txtEndereco);
            this.panel3.Controls.Add(this.lblEndereco);
            this.panel3.Controls.Add(this.lblRazaoSocial);
            this.panel3.Controls.Add(this.lblCliente);
            this.panel3.Controls.Add(this.txtRazaoSocial);
            this.panel3.Controls.Add(this.txtNomeCliente);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(2, 69);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1900, 70);
            this.panel3.TabIndex = 3;
            // 
            // txtIdCpfCliente
            // 
            this.txtIdCpfCliente.Location = new System.Drawing.Point(10, 25);
            this.txtIdCpfCliente.Name = "txtIdCpfCliente";
            this.txtIdCpfCliente.Size = new System.Drawing.Size(154, 27);
            this.txtIdCpfCliente.TabIndex = 4;
            this.txtIdCpfCliente.TextChanged += new System.EventHandler(this.txtIdCpfCliente_TextChanged);
            this.txtIdCpfCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdCpfCliente_KeyDown);
            // 
            // btnProcessar
            // 
            this.btnProcessar.Location = new System.Drawing.Point(1243, 24);
            this.btnProcessar.Name = "btnProcessar";
            this.btnProcessar.Size = new System.Drawing.Size(94, 29);
            this.btnProcessar.TabIndex = 8;
            this.btnProcessar.Text = "Processar";
            this.btnProcessar.UseVisualStyleBackColor = true;
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(915, 26);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(294, 27);
            this.txtEndereco.TabIndex = 7;
            // 
            // lblEndereco
            // 
            this.lblEndereco.AutoSize = true;
            this.lblEndereco.Location = new System.Drawing.Point(915, 3);
            this.lblEndereco.Name = "lblEndereco";
            this.lblEndereco.Size = new System.Drawing.Size(71, 20);
            this.lblEndereco.TabIndex = 8;
            this.lblEndereco.Text = "Endereço";
            // 
            // lblRazaoSocial
            // 
            this.lblRazaoSocial.AutoSize = true;
            this.lblRazaoSocial.Location = new System.Drawing.Point(569, 3);
            this.lblRazaoSocial.Name = "lblRazaoSocial";
            this.lblRazaoSocial.Size = new System.Drawing.Size(94, 20);
            this.lblRazaoSocial.TabIndex = 7;
            this.lblRazaoSocial.Text = "Razão Social";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(200, 3);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(55, 20);
            this.lblCliente.TabIndex = 6;
            this.lblCliente.Text = "Cliente";
            // 
            // txtRazaoSocial
            // 
            this.txtRazaoSocial.Location = new System.Drawing.Point(569, 26);
            this.txtRazaoSocial.Name = "txtRazaoSocial";
            this.txtRazaoSocial.Size = new System.Drawing.Size(306, 27);
            this.txtRazaoSocial.TabIndex = 6;
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.Location = new System.Drawing.Point(200, 25);
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.Size = new System.Drawing.Size(333, 27);
            this.txtNomeCliente.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tableLayoutPanel1);
            this.panel4.Enabled = false;
            this.panel4.Location = new System.Drawing.Point(0, 911);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1902, 82);
            this.panel4.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblValorTotal, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtValorTotal, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtValorProdutos, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel1.Enabled = false;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1471, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(431, 82);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Location = new System.Drawing.Point(218, 0);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(80, 20);
            this.lblValorTotal.TabIndex = 1;
            this.lblValorTotal.Text = "Valor Total";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Valor dos Produtos";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Location = new System.Drawing.Point(218, 44);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(210, 27);
            this.txtValorTotal.TabIndex = 3;
            // 
            // txtValorProdutos
            // 
            this.txtValorProdutos.Location = new System.Drawing.Point(3, 44);
            this.txtValorProdutos.Name = "txtValorProdutos";
            this.txtValorProdutos.Size = new System.Drawing.Size(196, 27);
            this.txtValorProdutos.TabIndex = 2;
            this.txtValorProdutos.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tabelaAddProdutos);
            this.panel5.Location = new System.Drawing.Point(20, 210);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1882, 703);
            this.panel5.TabIndex = 5;
            // 
            // tabelaAddProdutos
            // 
            this.tabelaAddProdutos.AllowUserToAddRows = false;
            this.tabelaAddProdutos.AllowUserToDeleteRows = false;
            this.tabelaAddProdutos.AllowUserToResizeColumns = false;
            this.tabelaAddProdutos.AllowUserToResizeRows = false;
            this.tabelaAddProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabelaAddProdutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colid_prod,
            this.colProduto,
            this.colQuantidade,
            this.colValorUnitario,
            this.colValorFinal});
            this.tabelaAddProdutos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabelaAddProdutos.Location = new System.Drawing.Point(0, 0);
            this.tabelaAddProdutos.Name = "tabelaAddProdutos";
            this.tabelaAddProdutos.ReadOnly = true;
            this.tabelaAddProdutos.RowHeadersVisible = false;
            this.tabelaAddProdutos.RowHeadersWidth = 51;
            this.tabelaAddProdutos.RowTemplate.Height = 29;
            this.tabelaAddProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabelaAddProdutos.Size = new System.Drawing.Size(1882, 703);
            this.tabelaAddProdutos.TabIndex = 19;
            this.tabelaAddProdutos.TabStop = false;
            this.tabelaAddProdutos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // colid_prod
            // 
            this.colid_prod.HeaderText = "ID Produto";
            this.colid_prod.MinimumWidth = 6;
            this.colid_prod.Name = "colid_prod";
            this.colid_prod.ReadOnly = true;
            this.colid_prod.Width = 125;
            // 
            // colProduto
            // 
            this.colProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProduto.HeaderText = "Produto";
            this.colProduto.MinimumWidth = 6;
            this.colProduto.Name = "colProduto";
            this.colProduto.ReadOnly = true;
            // 
            // colQuantidade
            // 
            this.colQuantidade.HeaderText = "Quantidade";
            this.colQuantidade.MinimumWidth = 6;
            this.colQuantidade.Name = "colQuantidade";
            this.colQuantidade.ReadOnly = true;
            this.colQuantidade.Width = 125;
            // 
            // colValorUnitario
            // 
            this.colValorUnitario.HeaderText = "Valor Unitário";
            this.colValorUnitario.MinimumWidth = 6;
            this.colValorUnitario.Name = "colValorUnitario";
            this.colValorUnitario.ReadOnly = true;
            this.colValorUnitario.Width = 125;
            // 
            // colValorFinal
            // 
            this.colValorFinal.HeaderText = "Valor Final";
            this.colValorFinal.MinimumWidth = 6;
            this.colValorFinal.Name = "colValorFinal";
            this.colValorFinal.ReadOnly = true;
            this.colValorFinal.Width = 125;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnAdicionar);
            this.panel6.Controls.Add(this.lblNomeProd);
            this.panel6.Controls.Add(this.lblEstoque);
            this.panel6.Controls.Add(this.lblReserva);
            this.panel6.Controls.Add(this.lblQuantidade);
            this.panel6.Controls.Add(this.lblPreco);
            this.panel6.Controls.Add(this.lblModalidade);
            this.panel6.Controls.Add(this.lblCodProd);
            this.panel6.Controls.Add(this.cbModalidade);
            this.panel6.Controls.Add(this.txtNomeProd);
            this.panel6.Controls.Add(this.txtEstoque);
            this.panel6.Controls.Add(this.txtQuantidade);
            this.panel6.Controls.Add(this.txtPreco);
            this.panel6.Controls.Add(this.txtReserva);
            this.panel6.Controls.Add(this.txtCodProd);
            this.panel6.Controls.Add(this.btnPesquisaPorNomeID);
            this.panel6.Location = new System.Drawing.Point(0, 140);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1902, 70);
            this.panel6.TabIndex = 6;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(1534, 25);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(94, 29);
            this.btnAdicionar.TabIndex = 17;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // lblNomeProd
            // 
            this.lblNomeProd.AutoSize = true;
            this.lblNomeProd.Location = new System.Drawing.Point(275, 3);
            this.lblNomeProd.Name = "lblNomeProd";
            this.lblNomeProd.Size = new System.Drawing.Size(62, 20);
            this.lblNomeProd.TabIndex = 14;
            this.lblNomeProd.Text = "Produto";
            // 
            // lblEstoque
            // 
            this.lblEstoque.AutoSize = true;
            this.lblEstoque.Location = new System.Drawing.Point(773, 3);
            this.lblEstoque.Name = "lblEstoque";
            this.lblEstoque.Size = new System.Drawing.Size(62, 20);
            this.lblEstoque.TabIndex = 13;
            this.lblEstoque.Text = "Estoque";
            // 
            // lblReserva
            // 
            this.lblReserva.AutoSize = true;
            this.lblReserva.Location = new System.Drawing.Point(917, 5);
            this.lblReserva.Name = "lblReserva";
            this.lblReserva.Size = new System.Drawing.Size(60, 20);
            this.lblReserva.TabIndex = 12;
            this.lblReserva.Text = "Reserva";
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(1064, 3);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(87, 20);
            this.lblQuantidade.TabIndex = 11;
            this.lblQuantidade.Text = "Quantidade";
            // 
            // lblPreco
            // 
            this.lblPreco.AutoSize = true;
            this.lblPreco.Location = new System.Drawing.Point(1214, 3);
            this.lblPreco.Name = "lblPreco";
            this.lblPreco.Size = new System.Drawing.Size(46, 20);
            this.lblPreco.TabIndex = 10;
            this.lblPreco.Text = "Preço";
            // 
            // lblModalidade
            // 
            this.lblModalidade.AutoSize = true;
            this.lblModalidade.Location = new System.Drawing.Point(1362, 3);
            this.lblModalidade.Name = "lblModalidade";
            this.lblModalidade.Size = new System.Drawing.Size(90, 20);
            this.lblModalidade.TabIndex = 9;
            this.lblModalidade.Text = "Modalidade";
            // 
            // lblCodProd
            // 
            this.lblCodProd.AutoSize = true;
            this.lblCodProd.Location = new System.Drawing.Point(11, 5);
            this.lblCodProd.Name = "lblCodProd";
            this.lblCodProd.Size = new System.Drawing.Size(58, 20);
            this.lblCodProd.TabIndex = 8;
            this.lblCodProd.Text = "Código";
            this.lblCodProd.Click += new System.EventHandler(this.label4_Click);
            // 
            // cbModalidade
            // 
            this.cbModalidade.FormattingEnabled = true;
            this.cbModalidade.ItemHeight = 20;
            this.cbModalidade.Location = new System.Drawing.Point(1362, 26);
            this.cbModalidade.Name = "cbModalidade";
            this.cbModalidade.Size = new System.Drawing.Size(151, 28);
            this.cbModalidade.TabIndex = 15;
            // 
            // txtNomeProd
            // 
            this.txtNomeProd.Location = new System.Drawing.Point(275, 26);
            this.txtNomeProd.Name = "txtNomeProd";
            this.txtNomeProd.Size = new System.Drawing.Size(477, 27);
            this.txtNomeProd.TabIndex = 10;
            // 
            // txtEstoque
            // 
            this.txtEstoque.Location = new System.Drawing.Point(773, 26);
            this.txtEstoque.Name = "txtEstoque";
            this.txtEstoque.Size = new System.Drawing.Size(125, 27);
            this.txtEstoque.TabIndex = 11;
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(1064, 26);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(125, 27);
            this.txtQuantidade.TabIndex = 13;
            this.txtQuantidade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuantidade_KeyDown);
            // 
            // txtPreco
            // 
            this.txtPreco.Location = new System.Drawing.Point(1214, 26);
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new System.Drawing.Size(125, 27);
            this.txtPreco.TabIndex = 14;
            // 
            // txtReserva
            // 
            this.txtReserva.Location = new System.Drawing.Point(917, 25);
            this.txtReserva.Name = "txtReserva";
            this.txtReserva.Size = new System.Drawing.Size(125, 27);
            this.txtReserva.TabIndex = 12;
            // 
            // txtCodProd
            // 
            this.txtCodProd.Location = new System.Drawing.Point(11, 28);
            this.txtCodProd.Name = "txtCodProd";
            this.txtCodProd.Size = new System.Drawing.Size(125, 27);
            this.txtCodProd.TabIndex = 8;
            this.txtCodProd.TextChanged += new System.EventHandler(this.txtCodProd_TextChanged);
            this.txtCodProd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodProd_KeyDown);
            // 
            // btnPesquisaPorNomeID
            // 
            this.btnPesquisaPorNomeID.Location = new System.Drawing.Point(153, 26);
            this.btnPesquisaPorNomeID.Name = "btnPesquisaPorNomeID";
            this.btnPesquisaPorNomeID.Size = new System.Drawing.Size(94, 29);
            this.btnPesquisaPorNomeID.TabIndex = 9;
            this.btnPesquisaPorNomeID.Text = "Pesquisar";
            this.btnPesquisaPorNomeID.UseVisualStyleBackColor = true;
            this.btnPesquisaPorNomeID.Click += new System.EventHandler(this.btnPesquisaPorNomeID_Click);
            // 
            // CadastroNovoPedidoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1055);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CadastroNovoPedidoView";
            this.Text = "Novo Pedido";
            this.Load += new System.EventHandler(this.CadastroNovoPedidoView_Load);
            this.Shown += new System.EventHandler(this.CadastroNovoPedidoView_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CadastroNovoPedidoView_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CadastroNovoPedidoView_KeyPress);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabelaAddProdutos)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button btnSalvar;
        private Button btnCancelar;
        private Panel panel2;
        private TextBox txtVendedor;
        private Label label1;
        private TextBox txtNumeroPed;
        private Label lblNumero;
        private Label label2;
        private Panel panel3;
        private Label lblRazaoSocial;
        private Label lblCliente;
        private TextBox txtRazaoSocial;
        private TextBox txtNomeCliente;
        private Label lblIDVendedor;
        private TextBox txtIdVendedor;
        private Button btnProcessar;
        private TextBox txtEndereco;
        private Label lblEndereco;
        private Panel panel4;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblCodProd;
        private Label label3;
        private Label lblValorTotal;
        private Panel panel5;
        private DataGridView tabelaAddProdutos;
        private DataGridViewTextBoxColumn colid_prod;
        private DataGridViewTextBoxColumn colProduto;
        private DataGridViewTextBoxColumn colQuantidade;
        private DataGridViewTextBoxColumn colValorUnitario;
        private DataGridViewTextBoxColumn colValorFinal;
        private Panel panel6;
        private Label lblNomeProd;
        private Label lblEstoque;
        private Label lblReserva;
        private Label lblQuantidade;
        private Label lblPreco;
        private Label lblModalidade;
        private ComboBox cbModalidade;
        private TextBox txtNomeProd;
        private TextBox txtEstoque;
        private TextBox txtQuantidade;
        private TextBox txtPreco;
        private TextBox txtReserva;
        private TextBox txtCodProd;
        private Button btnPesquisaPorNomeID;
        private TextBox txtIdCpfCliente;
        private Button btnAdicionar;
        private TextBox txtValorProdutos;
        private TextBox txtValorTotal;
    }


}