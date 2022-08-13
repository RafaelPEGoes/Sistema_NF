namespace MiniSistema_TOPNFE.Resources
{
    partial class ConsultaProdutoView
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
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.txtLote = new System.Windows.Forms.TextBox();
            this.txtAplicacao = new System.Windows.Forms.TextBox();
            this.txtDescCodCodBarras = new System.Windows.Forms.TextBox();
            this.lblLote = new System.Windows.Forms.Label();
            this.lblAplicacao = new System.Windows.Forms.Label();
            this.lblReferencia = new System.Windows.Forms.Label();
            this.lblProcuraProduto = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabelaConsultaProduto = new System.Windows.Forms.DataGridView();
            this.col_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodBarra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaConsultaProduto)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtReferencia);
            this.panel1.Controls.Add(this.txtLote);
            this.panel1.Controls.Add(this.txtAplicacao);
            this.panel1.Controls.Add(this.txtDescCodCodBarras);
            this.panel1.Controls.Add(this.lblLote);
            this.panel1.Controls.Add(this.lblAplicacao);
            this.panel1.Controls.Add(this.lblReferencia);
            this.panel1.Controls.Add(this.lblProcuraProduto);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1882, 70);
            this.panel1.TabIndex = 0;
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(341, 40);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(160, 27);
            this.txtReferencia.TabIndex = 7;
            // 
            // txtLote
            // 
            this.txtLote.Location = new System.Drawing.Point(524, 39);
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new System.Drawing.Size(307, 27);
            this.txtLote.TabIndex = 5;
            // 
            // txtAplicacao
            // 
            this.txtAplicacao.Location = new System.Drawing.Point(852, 39);
            this.txtAplicacao.Name = "txtAplicacao";
            this.txtAplicacao.Size = new System.Drawing.Size(531, 27);
            this.txtAplicacao.TabIndex = 6;
            // 
            // txtDescCodCodBarras
            // 
            this.txtDescCodCodBarras.Location = new System.Drawing.Point(12, 39);
            this.txtDescCodCodBarras.Name = "txtDescCodCodBarras";
            this.txtDescCodCodBarras.Size = new System.Drawing.Size(307, 27);
            this.txtDescCodCodBarras.TabIndex = 4;
            this.txtDescCodCodBarras.TextChanged += new System.EventHandler(this.txtDescCodCodBarras_TextChanged);
            this.txtDescCodCodBarras.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescCodCodBarras_KeyDown);
            // 
            // lblLote
            // 
            this.lblLote.AutoSize = true;
            this.lblLote.Location = new System.Drawing.Point(524, 9);
            this.lblLote.Name = "lblLote";
            this.lblLote.Size = new System.Drawing.Size(38, 20);
            this.lblLote.TabIndex = 3;
            this.lblLote.Text = "Lote";
            // 
            // lblAplicacao
            // 
            this.lblAplicacao.AutoSize = true;
            this.lblAplicacao.Location = new System.Drawing.Point(852, 9);
            this.lblAplicacao.Name = "lblAplicacao";
            this.lblAplicacao.Size = new System.Drawing.Size(75, 20);
            this.lblAplicacao.TabIndex = 2;
            this.lblAplicacao.Text = "Aplicação";
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.Location = new System.Drawing.Point(341, 9);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(79, 20);
            this.lblReferencia.TabIndex = 1;
            this.lblReferencia.Text = "Referência";
            // 
            // lblProcuraProduto
            // 
            this.lblProcuraProduto.AutoSize = true;
            this.lblProcuraProduto.Location = new System.Drawing.Point(12, 9);
            this.lblProcuraProduto.Name = "lblProcuraProduto";
            this.lblProcuraProduto.Size = new System.Drawing.Size(270, 20);
            this.lblProcuraProduto.TabIndex = 9;
            this.lblProcuraProduto.Text = "Descrição, Código ou Código de Barras";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabelaConsultaProduto);
            this.panel2.Location = new System.Drawing.Point(0, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1882, 986);
            this.panel2.TabIndex = 1;
            // 
            // tabelaConsultaProduto
            // 
            this.tabelaConsultaProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabelaConsultaProduto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_ID,
            this.colCodBarra,
            this.colReferencia,
            this.colProduto});
            this.tabelaConsultaProduto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabelaConsultaProduto.Location = new System.Drawing.Point(0, 0);
            this.tabelaConsultaProduto.Name = "tabelaConsultaProduto";
            this.tabelaConsultaProduto.ReadOnly = true;
            this.tabelaConsultaProduto.RowHeadersVisible = false;
            this.tabelaConsultaProduto.RowHeadersWidth = 51;
            this.tabelaConsultaProduto.RowTemplate.Height = 29;
            this.tabelaConsultaProduto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabelaConsultaProduto.Size = new System.Drawing.Size(1882, 986);
            this.tabelaConsultaProduto.TabIndex = 0;
            this.tabelaConsultaProduto.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabelaConsultaProduto_CellDoubleClick);
            this.tabelaConsultaProduto.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabelaConsultaProduto_RowEnter);
            this.tabelaConsultaProduto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tabelaConsultaProduto_KeyDown);
            // 
            // col_ID
            // 
            this.col_ID.DataPropertyName = "CODIGO_PRODUTO";
            this.col_ID.HeaderText = "ID";
            this.col_ID.MinimumWidth = 6;
            this.col_ID.Name = "col_ID";
            this.col_ID.ReadOnly = true;
            this.col_ID.Width = 125;
            // 
            // colCodBarra
            // 
            this.colCodBarra.DataPropertyName = "CODIGO_BARRA";
            this.colCodBarra.HeaderText = "Código de Barras";
            this.colCodBarra.MinimumWidth = 6;
            this.colCodBarra.Name = "colCodBarra";
            this.colCodBarra.ReadOnly = true;
            this.colCodBarra.Width = 200;
            // 
            // colReferencia
            // 
            this.colReferencia.DataPropertyName = "REFERENCIA1";
            this.colReferencia.HeaderText = "Referência";
            this.colReferencia.MinimumWidth = 6;
            this.colReferencia.Name = "colReferencia";
            this.colReferencia.ReadOnly = true;
            this.colReferencia.Width = 250;
            // 
            // colProduto
            // 
            this.colProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProduto.DataPropertyName = "DESCRICAO";
            this.colProduto.HeaderText = "Produto";
            this.colProduto.MinimumWidth = 6;
            this.colProduto.Name = "colProduto";
            this.colProduto.ReadOnly = true;
            // 
            // ConsultaProdutoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1882, 1055);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ConsultaProdutoView";
            this.Text = "Consultar Produto ";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabelaConsultaProduto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private TextBox txtReferencia;
        private TextBox txtLote;
        private TextBox txtAplicacao;
        protected TextBox txtDescCodCodBarras;
        private Label lblLote;
        private Label lblAplicacao;
        private Label lblReferencia;
        private Label lblProcuraProduto;
        private Panel panel2;
        private DataGridView tabelaConsultaProduto;
        private DataGridViewTextBoxColumn col_ID;
        private DataGridViewTextBoxColumn colCodBarra;
        private DataGridViewTextBoxColumn colReferencia;
        private DataGridViewTextBoxColumn colProduto;
        
        public string GettxtDescCodCodBarras()
        {
            return txtDescCodCodBarras.Text;
        }

        public void SetTxtDescCodCodBarrasText(string text)
        {
            txtDescCodCodBarras.Text = text;
        }

        public void SetFocusOnFirstTextBox()
        {
            txtDescCodCodBarras.Focus();
        }
    }
}