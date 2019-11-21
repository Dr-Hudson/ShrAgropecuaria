namespace ShrAgropecuaria.Views
{
    partial class view_QuitarContasAPagar
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
            this.label7 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rbGeral = new System.Windows.Forms.RadioButton();
            this.rbAberto = new System.Windows.Forms.RadioButton();
            this.rbFechado = new System.Windows.Forms.RadioButton();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.DgvQuitar = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtValorPago = new System.Windows.Forms.MaskedTextBox();
            this.txtVP = new System.Windows.Forms.MaskedTextBox();
            this.dtpDataPagamento = new System.Windows.Forms.DateTimePicker();
            this.lbVPago = new System.Windows.Forms.Label();
            this.lbData = new System.Windows.Forms.Label();
            this.lbVP = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbFiltro = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.panel7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvQuitar)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Britannic Bold", 36F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(175, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(346, 53);
            this.label7.TabIndex = 38;
            this.label7.Text = "Quitar Despesa";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Controls.Add(this.label3);
            this.panel7.Controls.Add(this.txtUser);
            this.panel7.Location = new System.Drawing.Point(28, 90);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(195, 29);
            this.panel7.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Usuario";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(52, 2);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(133, 20);
            this.txtUser.TabIndex = 300;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Location = new System.Drawing.Point(28, 122);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 45);
            this.panel1.TabIndex = 33;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.rbGeral);
            this.panel4.Controls.Add(this.rbAberto);
            this.panel4.Controls.Add(this.rbFechado);
            this.panel4.Location = new System.Drawing.Point(109, 7);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(197, 29);
            this.panel4.TabIndex = 5;
            // 
            // rbGeral
            // 
            this.rbGeral.AutoSize = true;
            this.rbGeral.Location = new System.Drawing.Point(138, 4);
            this.rbGeral.Name = "rbGeral";
            this.rbGeral.Size = new System.Drawing.Size(50, 17);
            this.rbGeral.TabIndex = 6;
            this.rbGeral.TabStop = true;
            this.rbGeral.Text = "Geral";
            this.rbGeral.UseVisualStyleBackColor = true;
            this.rbGeral.CheckedChanged += new System.EventHandler(this.rbGeral_CheckedChanged);
            // 
            // rbAberto
            // 
            this.rbAberto.AutoSize = true;
            this.rbAberto.Location = new System.Drawing.Point(3, 5);
            this.rbAberto.Name = "rbAberto";
            this.rbAberto.Size = new System.Drawing.Size(56, 17);
            this.rbAberto.TabIndex = 3;
            this.rbAberto.TabStop = true;
            this.rbAberto.Text = "Aberto";
            this.rbAberto.UseVisualStyleBackColor = true;
            this.rbAberto.CheckedChanged += new System.EventHandler(this.rbAberto_CheckedChanged);
            // 
            // rbFechado
            // 
            this.rbFechado.AutoSize = true;
            this.rbFechado.Location = new System.Drawing.Point(65, 5);
            this.rbFechado.Name = "rbFechado";
            this.rbFechado.Size = new System.Drawing.Size(67, 17);
            this.rbFechado.TabIndex = 5;
            this.rbFechado.TabStop = true;
            this.rbFechado.Text = "Fechado";
            this.rbFechado.UseVisualStyleBackColor = true;
            this.rbFechado.CheckedChanged += new System.EventHandler(this.rbFechado_CheckedChanged);
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel9.Controls.Add(this.btnPesquisar);
            this.panel9.Controls.Add(this.label8);
            this.panel9.Controls.Add(this.txtID);
            this.panel9.Location = new System.Drawing.Point(11, 7);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(92, 29);
            this.panel9.TabIndex = 1;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(55, 1);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(28, 23);
            this.btnPesquisar.TabIndex = 1;
            this.btnPesquisar.Text = "*";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(22, 2);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(28, 20);
            this.txtID.TabIndex = 300;
            // 
            // DgvQuitar
            // 
            this.DgvQuitar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvQuitar.Location = new System.Drawing.Point(28, 173);
            this.DgvQuitar.Name = "DgvQuitar";
            this.DgvQuitar.Size = new System.Drawing.Size(644, 273);
            this.DgvQuitar.TabIndex = 39;
            this.DgvQuitar.SelectionChanged += new System.EventHandler(this.DgvQuitar_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(280, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 40;
            this.label1.Text = "Despesa";
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(510, 76);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(75, 23);
            this.btnQuitar.TabIndex = 42;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtValorPago);
            this.panel2.Controls.Add(this.txtVP);
            this.panel2.Controls.Add(this.dtpDataPagamento);
            this.panel2.Controls.Add(this.btnQuitar);
            this.panel2.Controls.Add(this.lbVPago);
            this.panel2.Controls.Add(this.lbData);
            this.panel2.Controls.Add(this.lbVP);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(28, 453);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(644, 142);
            this.panel2.TabIndex = 43;
            // 
            // txtValorPago
            // 
            this.txtValorPago.Location = new System.Drawing.Point(393, 79);
            this.txtValorPago.Mask = "$ 00000000.00";
            this.txtValorPago.Name = "txtValorPago";
            this.txtValorPago.Size = new System.Drawing.Size(100, 20);
            this.txtValorPago.TabIndex = 48;
            this.txtValorPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SomenteNumeroDPE);
            // 
            // txtVP
            // 
            this.txtVP.Location = new System.Drawing.Point(24, 81);
            this.txtVP.Mask = "$ 00000000.00";
            this.txtVP.Name = "txtVP";
            this.txtVP.Size = new System.Drawing.Size(100, 20);
            this.txtVP.TabIndex = 47;
            // 
            // dtpDataPagamento
            // 
            this.dtpDataPagamento.Location = new System.Drawing.Point(144, 81);
            this.dtpDataPagamento.Name = "dtpDataPagamento";
            this.dtpDataPagamento.Size = new System.Drawing.Size(226, 20);
            this.dtpDataPagamento.TabIndex = 46;
            // 
            // lbVPago
            // 
            this.lbVPago.AutoSize = true;
            this.lbVPago.Location = new System.Drawing.Point(391, 63);
            this.lbVPago.Name = "lbVPago";
            this.lbVPago.Size = new System.Drawing.Size(59, 13);
            this.lbVPago.TabIndex = 45;
            this.lbVPago.Text = "Valor Pago";
            // 
            // lbData
            // 
            this.lbData.AutoSize = true;
            this.lbData.Location = new System.Drawing.Point(141, 63);
            this.lbData.Name = "lbData";
            this.lbData.Size = new System.Drawing.Size(101, 13);
            this.lbData.TabIndex = 42;
            this.lbData.Text = "Data do pagamento";
            // 
            // lbVP
            // 
            this.lbVP.AutoSize = true;
            this.lbVP.Location = new System.Drawing.Point(21, 63);
            this.lbVP.Name = "lbVP";
            this.lbVP.Size = new System.Drawing.Size(84, 13);
            this.lbVP.TabIndex = 41;
            this.lbVP.Text = "Valor da parcela";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Location = new System.Drawing.Point(348, 122);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(324, 45);
            this.panel3.TabIndex = 44;
            // 
            // cbFiltro
            // 
            this.cbFiltro.AutoSize = true;
            this.cbFiltro.Location = new System.Drawing.Point(3, 3);
            this.cbFiltro.Name = "cbFiltro";
            this.cbFiltro.Size = new System.Drawing.Size(78, 17);
            this.cbFiltro.TabIndex = 45;
            this.cbFiltro.Text = "Ativar Filtro";
            this.cbFiltro.UseVisualStyleBackColor = true;
            this.cbFiltro.CheckedChanged += new System.EventHandler(this.cbFiltro_CheckedChanged);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.cbFiltro);
            this.panel5.Location = new System.Drawing.Point(3, 8);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(87, 25);
            this.panel5.TabIndex = 46;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.dtpData);
            this.panel6.Location = new System.Drawing.Point(96, 7);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(221, 26);
            this.panel6.TabIndex = 45;
            // 
            // dtpData
            // 
            this.dtpData.Location = new System.Drawing.Point(4, 2);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(210, 20);
            this.dtpData.TabIndex = 0;
            // 
            // view_QuitarContasAPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 679);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.DgvQuitar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel1);
            this.Name = "view_QuitarContasAPagar";
            this.Text = "view_QuitarContasAPagar";
            this.Load += new System.EventHandler(this.view_QuitarContasAPagar_Load);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvQuitar)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rbAberto;
        private System.Windows.Forms.RadioButton rbFechado;
        private System.Windows.Forms.DataGridView DgvQuitar;
        private System.Windows.Forms.RadioButton rbGeral;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbVP;
        private System.Windows.Forms.Label lbData;
        private System.Windows.Forms.DateTimePicker dtpDataPagamento;
        private System.Windows.Forms.Label lbVPago;
        private System.Windows.Forms.MaskedTextBox txtValorPago;
        private System.Windows.Forms.MaskedTextBox txtVP;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox cbFiltro;
    }
}