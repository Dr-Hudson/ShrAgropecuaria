namespace ShrAgropecuaria.Views
{
    partial class view_ProdutoPET
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
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtFabricante = new System.Windows.Forms.TextBox();
            this.txtValorUnitario = new System.Windows.Forms.MaskedTextBox();
            this.txtEstoque = new System.Windows.Forms.TextBox();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAtivo = new System.Windows.Forms.TextBox();
            this.btnPesquisarCategoria = new System.Windows.Forms.Button();
            this.txtValorCompra = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnPesquisarProd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Estoque *";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Descrição *";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Fabricante *";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Valor Da Compra *";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "ValorUnitario *";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(28, 2);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(36, 20);
            this.txtID.TabIndex = 9;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(71, 2);
            this.txtDescricao.MaxLength = 40;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(279, 20);
            this.txtDescricao.TabIndex = 2;
            this.txtDescricao.Leave += new System.EventHandler(this.EventoSairDescricaoProd);
            // 
            // txtFabricante
            // 
            this.txtFabricante.Location = new System.Drawing.Point(77, 3);
            this.txtFabricante.MaxLength = 40;
            this.txtFabricante.Name = "txtFabricante";
            this.txtFabricante.Size = new System.Drawing.Size(198, 20);
            this.txtFabricante.TabIndex = 3;
            this.txtFabricante.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SomenteLetra);
            this.txtFabricante.Leave += new System.EventHandler(this.EventoSairFabricante);
            // 
            // txtValorUnitario
            // 
            this.txtValorUnitario.Location = new System.Drawing.Point(82, 2);
            this.txtValorUnitario.Mask = "$ 00000000,00";
            this.txtValorUnitario.Name = "txtValorUnitario";
            this.txtValorUnitario.Size = new System.Drawing.Size(89, 20);
            this.txtValorUnitario.TabIndex = 5;
            this.txtValorUnitario.Click += new System.EventHandler(this.txtValorUnitario_Click);
            this.txtValorUnitario.Enter += new System.EventHandler(this.txtValorUnitario_Enter);
            this.txtValorUnitario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SomenteNumeroDPEVU);
            this.txtValorUnitario.Leave += new System.EventHandler(this.EventoSairVU);
            // 
            // txtEstoque
            // 
            this.txtEstoque.Location = new System.Drawing.Point(61, 3);
            this.txtEstoque.MaxLength = 11;
            this.txtEstoque.Name = "txtEstoque";
            this.txtEstoque.Size = new System.Drawing.Size(167, 20);
            this.txtEstoque.TabIndex = 6;
            this.txtEstoque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SomenteNumero);
            this.txtEstoque.Leave += new System.EventHandler(this.EventoSairEstoque);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(591, 112);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(74, 23);
            this.btnLimpar.TabIndex = 11;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnGravar
            // 
            this.btnGravar.Location = new System.Drawing.Point(680, 112);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 23);
            this.btnGravar.TabIndex = 9;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(19, 112);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 10;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // txtCategoria
            // 
            this.txtCategoria.Enabled = false;
            this.txtCategoria.Location = new System.Drawing.Point(68, 3);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(151, 20);
            this.txtCategoria.TabIndex = 18;
            this.txtCategoria.Leave += new System.EventHandler(this.EventoSairCat);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Categoria *";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Situação *";
            this.label5.Click += new System.EventHandler(this.LegendaSituacao);
            // 
            // txtAtivo
            // 
            this.txtAtivo.Location = new System.Drawing.Point(65, 3);
            this.txtAtivo.MaxLength = 1;
            this.txtAtivo.Name = "txtAtivo";
            this.txtAtivo.ShortcutsEnabled = false;
            this.txtAtivo.Size = new System.Drawing.Size(100, 20);
            this.txtAtivo.TabIndex = 8;
            this.txtAtivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SomenteLetra);
            this.txtAtivo.Leave += new System.EventHandler(this.EventoSairSit);
            // 
            // btnPesquisarCategoria
            // 
            this.btnPesquisarCategoria.Location = new System.Drawing.Point(225, 1);
            this.btnPesquisarCategoria.Name = "btnPesquisarCategoria";
            this.btnPesquisarCategoria.Size = new System.Drawing.Size(24, 23);
            this.btnPesquisarCategoria.TabIndex = 7;
            this.btnPesquisarCategoria.UseVisualStyleBackColor = true;
            this.btnPesquisarCategoria.Click += new System.EventHandler(this.btnPesquisarCategoria_Click);
            // 
            // txtValorCompra
            // 
            this.txtValorCompra.Location = new System.Drawing.Point(103, 2);
            this.txtValorCompra.Mask = "$ 00000000.00";
            this.txtValorCompra.Name = "txtValorCompra";
            this.txtValorCompra.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtValorCompra.Size = new System.Drawing.Size(89, 20);
            this.txtValorCompra.TabIndex = 4;
            this.txtValorCompra.Click += new System.EventHandler(this.txtValorCompra_Click);
            this.txtValorCompra.Enter += new System.EventHandler(this.txtValorCompra_Enter);
            this.txtValorCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SomenteNumeroDPE);
            this.txtValorCompra.Leave += new System.EventHandler(this.EventoSairVC);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 565);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(128, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "* são campos obrigatórios";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(12, 93);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel8);
            this.splitContainer1.Panel1.Controls.Add(this.panel7);
            this.splitContainer1.Panel1.Controls.Add(this.panel6);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel5);
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.btnLimpar);
            this.splitContainer1.Panel2.Controls.Add(this.btnExcluir);
            this.splitContainer1.Panel2.Controls.Add(this.btnGravar);
            this.splitContainer1.Size = new System.Drawing.Size(771, 225);
            this.splitContainer1.SplitterDistance = 54;
            this.splitContainer1.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Britannic Bold", 36F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(183, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(477, 53);
            this.label7.TabIndex = 30;
            this.label7.Text = "Cadastro ProdutoPET";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtFabricante);
            this.panel1.Location = new System.Drawing.Point(19, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 28);
            this.panel1.TabIndex = 22;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtCategoria);
            this.panel2.Controls.Add(this.btnPesquisarCategoria);
            this.panel2.Location = new System.Drawing.Point(309, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(256, 28);
            this.panel2.TabIndex = 23;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtAtivo);
            this.panel3.Location = new System.Drawing.Point(571, 11);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(173, 28);
            this.panel3.TabIndex = 24;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.txtValorCompra);
            this.panel4.Location = new System.Drawing.Point(19, 59);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(202, 28);
            this.panel4.TabIndex = 25;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.txtValorUnitario);
            this.panel5.Location = new System.Drawing.Point(236, 59);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(181, 28);
            this.panel5.TabIndex = 26;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.btnPesquisarProd);
            this.panel6.Controls.Add(this.txtID);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Location = new System.Drawing.Point(19, 10);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(106, 28);
            this.panel6.TabIndex = 27;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Controls.Add(this.label4);
            this.panel7.Controls.Add(this.txtDescricao);
            this.panel7.Location = new System.Drawing.Point(143, 10);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(359, 28);
            this.panel7.TabIndex = 27;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel8.Controls.Add(this.label2);
            this.panel8.Controls.Add(this.txtEstoque);
            this.panel8.Location = new System.Drawing.Point(508, 10);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(236, 28);
            this.panel8.TabIndex = 27;
            // 
            // btnPesquisarProd
            // 
            this.btnPesquisarProd.Location = new System.Drawing.Point(72, 0);
            this.btnPesquisarProd.Name = "btnPesquisarProd";
            this.btnPesquisarProd.Size = new System.Drawing.Size(24, 23);
            this.btnPesquisarProd.TabIndex = 20;
            this.btnPesquisarProd.UseVisualStyleBackColor = true;
            this.btnPesquisarProd.Click += new System.EventHandler(this.btnPesquisarProd_Click);
            // 
            // view_ProdutoPET
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 330);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label13);
            this.Name = "view_ProdutoPET";
            this.Text = "Cadastro ProdutoPET";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtFabricante;
        private System.Windows.Forms.MaskedTextBox txtValorUnitario;
        private System.Windows.Forms.TextBox txtEstoque;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAtivo;
        private System.Windows.Forms.Button btnPesquisarCategoria;
        private System.Windows.Forms.MaskedTextBox txtValorCompra;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPesquisarProd;
    }
}