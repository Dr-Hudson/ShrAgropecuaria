namespace ShrAgropecuaria.Views
{
    partial class view_VendaPET
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtcliente = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRmv = new System.Windows.Forms.Button();
            this.btnVender = new System.Windows.Forms.Button();
            this.txtQtde = new System.Windows.Forms.TextBox();
            this.quantt = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtid = new System.Windows.Forms.TextBox();
            this.txtProduto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnProd = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabProdutos = new System.Windows.Forms.TabPage();
            this.tabPagamento = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbVista = new System.Windows.Forms.RadioButton();
            this.rbPrazo = new System.Windows.Forms.RadioButton();
            this.rbParcelado = new System.Windows.Forms.RadioButton();
            this.pnPrazo = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabProdutos.SuspendLayout();
            this.tabPagamento.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnPrazo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente";
            // 
            // txtcliente
            // 
            this.txtcliente.Enabled = false;
            this.txtcliente.Location = new System.Drawing.Point(15, 26);
            this.txtcliente.Name = "txtcliente";
            this.txtcliente.Size = new System.Drawing.Size(183, 20);
            this.txtcliente.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(216, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Pesquisar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // dtpData
            // 
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData.Location = new System.Drawing.Point(336, 26);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(83, 20);
            this.dtpData.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Data";
            // 
            // txtValor
            // 
            this.txtValor.Enabled = false;
            this.txtValor.Location = new System.Drawing.Point(15, 75);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(107, 20);
            this.txtValor.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Valor";
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.Location = new System.Drawing.Point(9, 56);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.Size = new System.Drawing.Size(404, 150);
            this.dgvProdutos.TabIndex = 7;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(338, 26);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(22, 24);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnRmv
            // 
            this.btnRmv.Location = new System.Drawing.Point(366, 27);
            this.btnRmv.Name = "btnRmv";
            this.btnRmv.Size = new System.Drawing.Size(21, 23);
            this.btnRmv.TabIndex = 9;
            this.btnRmv.Text = "-";
            this.btnRmv.UseVisualStyleBackColor = true;
            this.btnRmv.Click += new System.EventHandler(this.BtnRmv_Click);
            // 
            // btnVender
            // 
            this.btnVender.Location = new System.Drawing.Point(110, 394);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(75, 23);
            this.btnVender.TabIndex = 10;
            this.btnVender.Text = "Vender";
            this.btnVender.UseVisualStyleBackColor = true;
            this.btnVender.Click += new System.EventHandler(this.BtnVender_Click);
            // 
            // txtQtde
            // 
            this.txtQtde.Location = new System.Drawing.Point(275, 30);
            this.txtQtde.Name = "txtQtde";
            this.txtQtde.Size = new System.Drawing.Size(53, 20);
            this.txtQtde.TabIndex = 11;
            // 
            // quantt
            // 
            this.quantt.AutoSize = true;
            this.quantt.Location = new System.Drawing.Point(272, 12);
            this.quantt.Name = "quantt";
            this.quantt.Size = new System.Drawing.Size(62, 13);
            this.quantt.TabIndex = 12;
            this.quantt.Text = "Quantidade";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(191, 394);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 13;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(269, 394);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar.TabIndex = 14;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.BtnPesquisar_Click);
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(128, 75);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(19, 20);
            this.txtid.TabIndex = 16;
            // 
            // txtProduto
            // 
            this.txtProduto.Location = new System.Drawing.Point(172, 30);
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.Size = new System.Drawing.Size(68, 20);
            this.txtProduto.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Produto";
            // 
            // btnProd
            // 
            this.btnProd.Location = new System.Drawing.Point(246, 30);
            this.btnProd.Name = "btnProd";
            this.btnProd.Size = new System.Drawing.Size(23, 20);
            this.btnProd.TabIndex = 19;
            this.btnProd.Text = "*";
            this.btnProd.UseVisualStyleBackColor = true;
            this.btnProd.Click += new System.EventHandler(this.btnProd_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabProdutos);
            this.tabControl.Controls.Add(this.tabPagamento);
            this.tabControl.Location = new System.Drawing.Point(12, 101);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(430, 278);
            this.tabControl.TabIndex = 20;
            // 
            // tabProdutos
            // 
            this.tabProdutos.Controls.Add(this.dgvProdutos);
            this.tabProdutos.Controls.Add(this.btnProd);
            this.tabProdutos.Controls.Add(this.txtProduto);
            this.tabProdutos.Controls.Add(this.label4);
            this.tabProdutos.Controls.Add(this.btnAdd);
            this.tabProdutos.Controls.Add(this.btnRmv);
            this.tabProdutos.Controls.Add(this.txtQtde);
            this.tabProdutos.Controls.Add(this.quantt);
            this.tabProdutos.Location = new System.Drawing.Point(4, 22);
            this.tabProdutos.Name = "tabProdutos";
            this.tabProdutos.Padding = new System.Windows.Forms.Padding(3);
            this.tabProdutos.Size = new System.Drawing.Size(422, 252);
            this.tabProdutos.TabIndex = 0;
            this.tabProdutos.Text = "Produtos";
            this.tabProdutos.UseVisualStyleBackColor = true;
            // 
            // tabPagamento
            // 
            this.tabPagamento.Controls.Add(this.pnPrazo);
            this.tabPagamento.Controls.Add(this.groupBox1);
            this.tabPagamento.Location = new System.Drawing.Point(4, 22);
            this.tabPagamento.Name = "tabPagamento";
            this.tabPagamento.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagamento.Size = new System.Drawing.Size(422, 252);
            this.tabPagamento.TabIndex = 1;
            this.tabPagamento.Text = "Pagamento";
            this.tabPagamento.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbParcelado);
            this.groupBox1.Controls.Add(this.rbPrazo);
            this.groupBox1.Controls.Add(this.rbVista);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Forma de Pagamento";
            // 
            // rbVista
            // 
            this.rbVista.AutoSize = true;
            this.rbVista.Location = new System.Drawing.Point(28, 19);
            this.rbVista.Name = "rbVista";
            this.rbVista.Size = new System.Drawing.Size(58, 17);
            this.rbVista.TabIndex = 0;
            this.rbVista.TabStop = true;
            this.rbVista.Text = "A Vista";
            this.rbVista.UseVisualStyleBackColor = true;
            this.rbVista.CheckedChanged += new System.EventHandler(this.rbVista_CheckedChanged);
            // 
            // rbPrazo
            // 
            this.rbPrazo.AutoSize = true;
            this.rbPrazo.Location = new System.Drawing.Point(159, 19);
            this.rbPrazo.Name = "rbPrazo";
            this.rbPrazo.Size = new System.Drawing.Size(62, 17);
            this.rbPrazo.TabIndex = 1;
            this.rbPrazo.TabStop = true;
            this.rbPrazo.Text = "A Prazo";
            this.rbPrazo.UseVisualStyleBackColor = true;
            // 
            // rbParcelado
            // 
            this.rbParcelado.AutoSize = true;
            this.rbParcelado.Location = new System.Drawing.Point(293, 19);
            this.rbParcelado.Name = "rbParcelado";
            this.rbParcelado.Size = new System.Drawing.Size(73, 17);
            this.rbParcelado.TabIndex = 2;
            this.rbParcelado.TabStop = true;
            this.rbParcelado.Text = "Parcelado";
            this.rbParcelado.UseVisualStyleBackColor = true;
            // 
            // pnPrazo
            // 
            this.pnPrazo.Controls.Add(this.label5);
            this.pnPrazo.Controls.Add(this.textBox1);
            this.pnPrazo.Location = new System.Drawing.Point(6, 60);
            this.pnPrazo.Name = "pnPrazo";
            this.pnPrazo.Size = new System.Drawing.Size(410, 186);
            this.pnPrazo.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "label5";
            // 
            // view_VendaPET
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 429);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnVender);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpData);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtcliente);
            this.Controls.Add(this.label1);
            this.Name = "view_VendaPET";
            this.Text = "view_VendaPET";
            this.Load += new System.EventHandler(this.view_VendaPET_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabProdutos.ResumeLayout(false);
            this.tabProdutos.PerformLayout();
            this.tabPagamento.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnPrazo.ResumeLayout(false);
            this.pnPrazo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtcliente;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRmv;
        private System.Windows.Forms.Button btnVender;
        private System.Windows.Forms.TextBox txtQtde;
        private System.Windows.Forms.Label quantt;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.TextBox txtProduto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnProd;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabProdutos;
        private System.Windows.Forms.TabPage tabPagamento;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbVista;
        private System.Windows.Forms.RadioButton rbParcelado;
        private System.Windows.Forms.RadioButton rbPrazo;
        private System.Windows.Forms.Panel pnPrazo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
    }
}