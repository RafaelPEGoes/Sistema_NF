namespace MiniSistema_TOPNFE
{
    partial class ConsultaPedidosView
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpDataFim = new System.Windows.Forms.DateTimePicker();
            this.dtpDataIni = new System.Windows.Forms.DateTimePicker();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.lblOrdenacao = new System.Windows.Forms.Label();
            this.cbOrdenaPor = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSituacao = new System.Windows.Forms.ComboBox();
            this.lblNumero = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVendedor = new System.Windows.Forms.TextBox();
            this.Vendedor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.Cidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Número = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Confirmado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Faturado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabelaConsultaPedido = new System.Windows.Forms.DataGridView();
            this.colCidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSituacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFaturado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstoqueSeparado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuContexto = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaConsultaPedido)).BeginInit();
            this.menuContexto.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpDataFim);
            this.panel1.Controls.Add(this.dtpDataIni);
            this.panel1.Controls.Add(this.btnImprimir);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.lblOrdenacao);
            this.panel1.Controls.Add(this.cbOrdenaPor);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbSituacao);
            this.panel1.Controls.Add(this.lblNumero);
            this.panel1.Controls.Add(this.txtNumero);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtVendedor);
            this.panel1.Controls.Add(this.Vendedor);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtCliente);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1900, 90);
            this.panel1.TabIndex = 0;
            // 
            // dtpDataFim
            // 
            this.dtpDataFim.CustomFormat = "";
            this.dtpDataFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataFim.Location = new System.Drawing.Point(896, 28);
            this.dtpDataFim.Name = "dtpDataFim";
            this.dtpDataFim.Size = new System.Drawing.Size(131, 27);
            this.dtpDataFim.TabIndex = 22;
            this.dtpDataFim.ValueChanged += new System.EventHandler(this.dtpDataFim_ValueChanged);
            // 
            // dtpDataIni
            // 
            this.dtpDataIni.CustomFormat = "";
            this.dtpDataIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataIni.Location = new System.Drawing.Point(759, 29);
            this.dtpDataIni.Name = "dtpDataIni";
            this.dtpDataIni.Size = new System.Drawing.Size(131, 27);
            this.dtpDataIni.TabIndex = 21;
            this.dtpDataIni.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(1709, 0);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(94, 89);
            this.btnImprimir.TabIndex = 19;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnPesquisa, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1809, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(91, 89);
            this.tableLayoutPanel2.TabIndex = 18;
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.Location = new System.Drawing.Point(3, 3);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(85, 83);
            this.btnPesquisa.TabIndex = 13;
            this.btnPesquisa.Text = "Buscar";
            this.btnPesquisa.UseVisualStyleBackColor = true;
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // lblOrdenacao
            // 
            this.lblOrdenacao.AutoSize = true;
            this.lblOrdenacao.Location = new System.Drawing.Point(1273, 5);
            this.lblOrdenacao.Name = "lblOrdenacao";
            this.lblOrdenacao.Size = new System.Drawing.Size(88, 20);
            this.lblOrdenacao.TabIndex = 17;
            this.lblOrdenacao.Text = "Ordenar Por";
            // 
            // cbOrdenaPor
            // 
            this.cbOrdenaPor.FormattingEnabled = true;
            this.cbOrdenaPor.Items.AddRange(new object[] {
            "Cidade",
            "Número",
            "Tipo",
            "Confirmado",
            "Faturado",
            "Estoque",
            "Data",
            "Vendedor",
            "ID Cliente",
            "Cliente"});
            this.cbOrdenaPor.Location = new System.Drawing.Point(1273, 27);
            this.cbOrdenaPor.Name = "cbOrdenaPor";
            this.cbOrdenaPor.Size = new System.Drawing.Size(151, 28);
            this.cbOrdenaPor.TabIndex = 16;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnAlterar, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(187, 87);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // btnAlterar
            // 
            this.btnAlterar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAlterar.Location = new System.Drawing.Point(96, 3);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(88, 81);
            this.btnAlterar.TabIndex = 14;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 81);
            this.button1.TabIndex = 12;
            this.button1.Text = "Novo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1116, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Situação";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cbSituacao
            // 
            this.cbSituacao.FormattingEnabled = true;
            this.cbSituacao.Items.AddRange(new object[] {
            "Todos",
            "Estoque Separado",
            "Faturado"});
            this.cbSituacao.Location = new System.Drawing.Point(1116, 27);
            this.cbSituacao.Name = "cbSituacao";
            this.cbSituacao.Size = new System.Drawing.Size(151, 28);
            this.cbSituacao.TabIndex = 10;
            this.cbSituacao.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(1033, 9);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(63, 20);
            this.lblNumero.TabIndex = 9;
            this.lblNumero.Text = "Número";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(1033, 28);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(77, 27);
            this.txtNumero.TabIndex = 8;
            this.txtNumero.TextChanged += new System.EventHandler(this.txtNumero_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(896, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Data Fim";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(759, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Data Início";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtVendedor
            // 
            this.txtVendedor.Location = new System.Drawing.Point(516, 28);
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.Size = new System.Drawing.Size(237, 27);
            this.txtVendedor.TabIndex = 3;
            this.txtVendedor.TextChanged += new System.EventHandler(this.txtVendedor_TextChanged);
            // 
            // Vendedor
            // 
            this.Vendedor.AutoSize = true;
            this.Vendedor.Location = new System.Drawing.Point(516, 8);
            this.Vendedor.Name = "Vendedor";
            this.Vendedor.Size = new System.Drawing.Size(73, 20);
            this.Vendedor.TabIndex = 2;
            this.Vendedor.Text = "Vendedor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(290, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cliente";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(290, 28);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(220, 27);
            this.txtCliente.TabIndex = 0;
            this.txtCliente.TextChanged += new System.EventHandler(this.txtCliente_TextChanged);
            // 
            // Cidade
            // 
            this.Cidade.HeaderText = "Cidade";
            this.Cidade.MinimumWidth = 6;
            this.Cidade.Name = "Cidade";
            this.Cidade.Width = 125;
            // 
            // Número
            // 
            this.Número.HeaderText = "Número";
            this.Número.MinimumWidth = 6;
            this.Número.Name = "Número";
            this.Número.Width = 125;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.MinimumWidth = 6;
            this.Tipo.Name = "Tipo";
            this.Tipo.Width = 125;
            // 
            // Confirmado
            // 
            this.Confirmado.HeaderText = "Confirmado";
            this.Confirmado.MinimumWidth = 6;
            this.Confirmado.Name = "Confirmado";
            this.Confirmado.Width = 125;
            // 
            // Faturado
            // 
            this.Faturado.HeaderText = "Faturado";
            this.Faturado.MinimumWidth = 6;
            this.Faturado.Name = "Faturado";
            this.Faturado.Width = 125;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabelaConsultaPedido);
            this.panel2.Location = new System.Drawing.Point(0, 91);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1901, 965);
            this.panel2.TabIndex = 1;
            // 
            // tabelaConsultaPedido
            // 
            this.tabelaConsultaPedido.AllowUserToAddRows = false;
            this.tabelaConsultaPedido.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tabelaConsultaPedido.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.tabelaConsultaPedido.ColumnHeadersHeight = 29;
            this.tabelaConsultaPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tabelaConsultaPedido.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCidade,
            this.colNumero,
            this.colTipo,
            this.colSituacao,
            this.colFaturado,
            this.colEstoqueSeparado,
            this.colData,
            this.colVendedor,
            this.colIdCliente,
            this.colCliente,
            this.colTotal});
            this.tabelaConsultaPedido.ContextMenuStrip = this.menuContexto;
            this.tabelaConsultaPedido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabelaConsultaPedido.Location = new System.Drawing.Point(0, 0);
            this.tabelaConsultaPedido.Name = "tabelaConsultaPedido";
            this.tabelaConsultaPedido.RowHeadersVisible = false;
            this.tabelaConsultaPedido.RowHeadersWidth = 51;
            this.tabelaConsultaPedido.RowTemplate.Height = 29;
            this.tabelaConsultaPedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabelaConsultaPedido.Size = new System.Drawing.Size(1901, 965);
            this.tabelaConsultaPedido.TabIndex = 0;
            this.tabelaConsultaPedido.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            this.tabelaConsultaPedido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tabelaConsultaPedido_KeyDown);
            // 
            // colCidade
            // 
            this.colCidade.HeaderText = "Cidade";
            this.colCidade.MinimumWidth = 6;
            this.colCidade.Name = "colCidade";
            this.colCidade.Visible = false;
            // 
            // colNumero
            // 
            this.colNumero.HeaderText = "Número";
            this.colNumero.MinimumWidth = 6;
            this.colNumero.Name = "colNumero";
            this.colNumero.Visible = false;
            // 
            // colTipo
            // 
            this.colTipo.HeaderText = "Tipo";
            this.colTipo.MinimumWidth = 6;
            this.colTipo.Name = "colTipo";
            this.colTipo.Visible = false;
            // 
            // colSituacao
            // 
            this.colSituacao.HeaderText = "Confirmado";
            this.colSituacao.MinimumWidth = 6;
            this.colSituacao.Name = "colSituacao";
            this.colSituacao.Visible = false;
            // 
            // colFaturado
            // 
            this.colFaturado.HeaderText = "Faturado";
            this.colFaturado.MinimumWidth = 6;
            this.colFaturado.Name = "colFaturado";
            this.colFaturado.Visible = false;
            // 
            // colEstoqueSeparado
            // 
            this.colEstoqueSeparado.HeaderText = "Est. Separado";
            this.colEstoqueSeparado.MinimumWidth = 6;
            this.colEstoqueSeparado.Name = "colEstoqueSeparado";
            this.colEstoqueSeparado.Visible = false;
            // 
            // colData
            // 
            this.colData.HeaderText = "Data";
            this.colData.MinimumWidth = 6;
            this.colData.Name = "colData";
            this.colData.Visible = false;
            // 
            // colVendedor
            // 
            this.colVendedor.HeaderText = "Vendedor";
            this.colVendedor.MinimumWidth = 6;
            this.colVendedor.Name = "colVendedor";
            this.colVendedor.Visible = false;
            // 
            // colIdCliente
            // 
            this.colIdCliente.HeaderText = "ID Cliente";
            this.colIdCliente.MinimumWidth = 6;
            this.colIdCliente.Name = "colIdCliente";
            this.colIdCliente.Visible = false;
            // 
            // colCliente
            // 
            this.colCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCliente.HeaderText = "Cliente";
            this.colCliente.MinimumWidth = 6;
            this.colCliente.Name = "colCliente";
            this.colCliente.Visible = false;
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Total";
            this.colTotal.MinimumWidth = 6;
            this.colTotal.Name = "colTotal";
            this.colTotal.Visible = false;
            // 
            // menuContexto
            // 
            this.menuContexto.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuContexto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imprimirToolStripMenuItem});
            this.menuContexto.Name = "contextMenuStrip1";
            this.menuContexto.Size = new System.Drawing.Size(136, 28);
            // 
            // imprimirToolStripMenuItem
            // 
            this.imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            this.imprimirToolStripMenuItem.Size = new System.Drawing.Size(135, 24);
            this.imprimirToolStripMenuItem.Text = "Imprimir";
            this.imprimirToolStripMenuItem.Click += new System.EventHandler(this.imprimirToolStripMenuItem_Click);
            // 
            // ConsultaPedidosView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1055);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ConsultaPedidosView";
            this.Text = "Form1";
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ConsultaPedidosView_PreviewKeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabelaConsultaPedido)).EndInit();
            this.menuContexto.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox txtCliente;
        private Label label3;
        private TextBox txtVendedor;
        private Label Vendedor;
        private Label label4;
        private Label label2;
        private ComboBox cbSituacao;
        private Label lblNumero;
        private TextBox txtNumero;
        private DataGridViewTextBoxColumn Cidade;
        private DataGridViewTextBoxColumn Número;
        private DataGridViewTextBoxColumn Tipo;
        private DataGridViewTextBoxColumn Confirmado;
        private DataGridViewTextBoxColumn Faturado;
        private Panel panel2;
        private DataGridView tabelaConsultaPedido;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnAlterar;
        private Button btnPesquisa;
        private Button button1;
        private Label lblOrdenacao;
        private ComboBox cbOrdenaPor;
        private TableLayoutPanel tableLayoutPanel2;
        private ContextMenuStrip menuContexto;
        private ToolStripMenuItem imprimirToolStripMenuItem;
        private Button btnImprimir;
        private DateTimePicker dtpDataFim;
        private DateTimePicker dtpDataIni;
        private DataGridViewTextBoxColumn colCidade;
        private DataGridViewTextBoxColumn colNumero;
        private DataGridViewTextBoxColumn colTipo;
        private DataGridViewTextBoxColumn colSituacao;
        private DataGridViewTextBoxColumn colFaturado;
        private DataGridViewTextBoxColumn colEstoqueSeparado;
        private DataGridViewTextBoxColumn colData;
        private DataGridViewTextBoxColumn colVendedor;
        private DataGridViewTextBoxColumn colIdCliente;
        private DataGridViewTextBoxColumn colCliente;
        private DataGridViewTextBoxColumn colTotal;
    }


}