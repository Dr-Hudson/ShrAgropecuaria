namespace ShrAgropecuaria.Views
{
    partial class view_ControlarEntregaPedidoNutrição
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
            this.label28 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txt_nomeCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_idCli = new System.Windows.Forms.TextBox();
            this.btn_pesqCliente = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_nomeFazenda = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_idFazenda = new System.Windows.Forms.TextBox();
            this.btn_pesqFazenda = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_gravar = new System.Windows.Forms.Button();
            this.btn_limpar = new System.Windows.Forms.Button();
            this.txt_msg = new System.Windows.Forms.Label();
            this.radio_entregue = new System.Windows.Forms.RadioButton();
            this.radio_naoEntregue = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label28);
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.txt_nomeCliente);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_idCli);
            this.panel1.Controls.Add(this.btn_pesqCliente);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(555, 116);
            this.panel1.TabIndex = 0;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(7, 7);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(194, 26);
            this.label28.TabIndex = 2;
            this.label28.Text = "Dados do Cliente:";
            this.label28.UseWaitCursor = true;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(7, 45);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(27, 22);
            this.label26.TabIndex = 47;
            this.label26.Text = "Id";
            // 
            // txt_nomeCliente
            // 
            this.txt_nomeCliente.Location = new System.Drawing.Point(169, 74);
            this.txt_nomeCliente.Name = "txt_nomeCliente";
            this.txt_nomeCliente.ReadOnly = true;
            this.txt_nomeCliente.Size = new System.Drawing.Size(256, 20);
            this.txt_nomeCliente.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome do Cliente";
            // 
            // txt_idCli
            // 
            this.txt_idCli.Location = new System.Drawing.Point(169, 47);
            this.txt_idCli.Name = "txt_idCli";
            this.txt_idCli.ReadOnly = true;
            this.txt_idCli.Size = new System.Drawing.Size(256, 20);
            this.txt_idCli.TabIndex = 46;
            // 
            // btn_pesqCliente
            // 
            this.btn_pesqCliente.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pesqCliente.Location = new System.Drawing.Point(431, 71);
            this.btn_pesqCliente.Name = "btn_pesqCliente";
            this.btn_pesqCliente.Size = new System.Drawing.Size(89, 27);
            this.btn_pesqCliente.TabIndex = 0;
            this.btn_pesqCliente.Text = "Pesquisar";
            this.btn_pesqCliente.UseVisualStyleBackColor = true;
            this.btn_pesqCliente.Click += new System.EventHandler(this.btn_pesqCliente_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Berlin Sans FB Demi", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(521, 71);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(27, 33);
            this.label17.TabIndex = 44;
            this.label17.Text = "*";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txt_nomeFazenda);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txt_idFazenda);
            this.panel2.Controls.Add(this.btn_pesqFazenda);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(573, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(555, 116);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 26);
            this.label2.TabIndex = 45;
            this.label2.Text = "Dados da Fazenda:";
            this.label2.UseWaitCursor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 22);
            this.label3.TabIndex = 47;
            this.label3.Text = "Id";
            // 
            // txt_nomeFazenda
            // 
            this.txt_nomeFazenda.Location = new System.Drawing.Point(169, 74);
            this.txt_nomeFazenda.Name = "txt_nomeFazenda";
            this.txt_nomeFazenda.ReadOnly = true;
            this.txt_nomeFazenda.Size = new System.Drawing.Size(256, 20);
            this.txt_nomeFazenda.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 22);
            this.label4.TabIndex = 42;
            this.label4.Text = "Nome da Fazenda";
            // 
            // txt_idFazenda
            // 
            this.txt_idFazenda.Location = new System.Drawing.Point(169, 47);
            this.txt_idFazenda.Name = "txt_idFazenda";
            this.txt_idFazenda.ReadOnly = true;
            this.txt_idFazenda.Size = new System.Drawing.Size(256, 20);
            this.txt_idFazenda.TabIndex = 46;
            // 
            // btn_pesqFazenda
            // 
            this.btn_pesqFazenda.Enabled = false;
            this.btn_pesqFazenda.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pesqFazenda.Location = new System.Drawing.Point(431, 71);
            this.btn_pesqFazenda.Name = "btn_pesqFazenda";
            this.btn_pesqFazenda.Size = new System.Drawing.Size(89, 27);
            this.btn_pesqFazenda.TabIndex = 0;
            this.btn_pesqFazenda.Text = "Pesquisar";
            this.btn_pesqFazenda.UseVisualStyleBackColor = true;
            this.btn_pesqFazenda.Click += new System.EventHandler(this.btn_pesqFazenda_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Berlin Sans FB Demi", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(521, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 33);
            this.label5.TabIndex = 0;
            this.label5.Text = "*";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.radio_naoEntregue);
            this.panel3.Controls.Add(this.radio_entregue);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Location = new System.Drawing.Point(15, 146);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1113, 331);
            this.panel3.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(19, 47);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1074, 263);
            this.dataGridView1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(498, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 26);
            this.label6.TabIndex = 48;
            this.label6.Text = "Pedido(s):";
            this.label6.UseWaitCursor = true;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.btn_gravar);
            this.panel4.Controls.Add(this.btn_limpar);
            this.panel4.Controls.Add(this.txt_msg);
            this.panel4.Location = new System.Drawing.Point(345, 497);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(456, 100);
            this.panel4.TabIndex = 3;
            // 
            // btn_gravar
            // 
            this.btn_gravar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_gravar.Location = new System.Drawing.Point(145, 54);
            this.btn_gravar.Name = "btn_gravar";
            this.btn_gravar.Size = new System.Drawing.Size(75, 30);
            this.btn_gravar.TabIndex = 0;
            this.btn_gravar.Text = "Gravar";
            this.btn_gravar.UseVisualStyleBackColor = true;
            // 
            // btn_limpar
            // 
            this.btn_limpar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_limpar.Location = new System.Drawing.Point(226, 54);
            this.btn_limpar.Name = "btn_limpar";
            this.btn_limpar.Size = new System.Drawing.Size(75, 30);
            this.btn_limpar.TabIndex = 1;
            this.btn_limpar.Text = "Limpar";
            this.btn_limpar.UseVisualStyleBackColor = true;
            this.btn_limpar.Click += new System.EventHandler(this.btn_limpar_Click);
            // 
            // txt_msg
            // 
            this.txt_msg.AutoSize = true;
            this.txt_msg.Font = new System.Drawing.Font("Open Sans Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_msg.Location = new System.Drawing.Point(133, 20);
            this.txt_msg.Name = "txt_msg";
            this.txt_msg.Size = new System.Drawing.Size(0, 22);
            this.txt_msg.TabIndex = 38;
            // 
            // radio_entregue
            // 
            this.radio_entregue.AutoSize = true;
            this.radio_entregue.Enabled = false;
            this.radio_entregue.Location = new System.Drawing.Point(918, 11);
            this.radio_entregue.Name = "radio_entregue";
            this.radio_entregue.Size = new System.Drawing.Size(65, 17);
            this.radio_entregue.TabIndex = 0;
            this.radio_entregue.TabStop = true;
            this.radio_entregue.Text = "Entegue";
            this.radio_entregue.UseVisualStyleBackColor = true;
            this.radio_entregue.CheckedChanged += new System.EventHandler(this.radio_entregue_CheckedChanged);
            // 
            // radio_naoEntregue
            // 
            this.radio_naoEntregue.AutoSize = true;
            this.radio_naoEntregue.Enabled = false;
            this.radio_naoEntregue.Location = new System.Drawing.Point(1002, 11);
            this.radio_naoEntregue.Name = "radio_naoEntregue";
            this.radio_naoEntregue.Size = new System.Drawing.Size(91, 17);
            this.radio_naoEntregue.TabIndex = 1;
            this.radio_naoEntregue.TabStop = true;
            this.radio_naoEntregue.Text = "Não Entregue";
            this.radio_naoEntregue.UseVisualStyleBackColor = true;
            this.radio_naoEntregue.CheckedChanged += new System.EventHandler(this.radio_naoEntregue_CheckedChanged);
            // 
            // view_ControlarEntregaPedidoNutrição
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 609);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "view_ControlarEntregaPedidoNutrição";
            this.Text = "view_ControlarEntregaPedidoNutrição";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txt_nomeCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_idCli;
        private System.Windows.Forms.Button btn_pesqCliente;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_nomeFazenda;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_idFazenda;
        private System.Windows.Forms.Button btn_pesqFazenda;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_gravar;
        private System.Windows.Forms.Button btn_limpar;
        private System.Windows.Forms.Label txt_msg;
        private System.Windows.Forms.RadioButton radio_naoEntregue;
        private System.Windows.Forms.RadioButton radio_entregue;
    }
}