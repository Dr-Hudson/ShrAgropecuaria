namespace ShrAgropecuaria.Views.Pesquisas
{
    partial class PesquisaPedidoNutrição
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
            this.BtnPesquisar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_numPed = new System.Windows.Forms.TextBox();
            this.Cidade = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_nomeCli = new System.Windows.Forms.TextBox();
            this.DgvPedNutri = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnSelecionarCid = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPedNutri)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnPesquisar
            // 
            this.BtnPesquisar.AutoSize = true;
            this.BtnPesquisar.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPesquisar.Location = new System.Drawing.Point(610, 5);
            this.BtnPesquisar.Name = "BtnPesquisar";
            this.BtnPesquisar.Size = new System.Drawing.Size(83, 27);
            this.BtnPesquisar.TabIndex = 64;
            this.BtnPesquisar.Text = "Pesquisar";
            this.BtnPesquisar.UseVisualStyleBackColor = true;
            this.BtnPesquisar.Click += new System.EventHandler(this.BtnPesquisar_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txt_numPed);
            this.panel1.Controls.Add(this.Cidade);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.BtnPesquisar);
            this.panel1.Controls.Add(this.txt_nomeCli);
            this.panel1.Controls.Add(this.DgvPedNutri);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(703, 320);
            this.panel1.TabIndex = 63;
            // 
            // txt_numPed
            // 
            this.txt_numPed.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_numPed.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_numPed.Location = new System.Drawing.Point(415, 9);
            this.txt_numPed.Name = "txt_numPed";
            this.txt_numPed.Size = new System.Drawing.Size(111, 23);
            this.txt_numPed.TabIndex = 69;
            // 
            // Cidade
            // 
            this.Cidade.AutoSize = true;
            this.Cidade.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cidade.Location = new System.Drawing.Point(279, 12);
            this.Cidade.Name = "Cidade";
            this.Cidade.Size = new System.Drawing.Size(130, 17);
            this.Cidade.TabIndex = 68;
            this.Cidade.Text = "Número do Pedido";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 17);
            this.label4.TabIndex = 65;
            this.label4.Text = "Nome do Cliente";
            // 
            // txt_nomeCli
            // 
            this.txt_nomeCli.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nomeCli.Location = new System.Drawing.Point(128, 9);
            this.txt_nomeCli.Name = "txt_nomeCli";
            this.txt_nomeCli.Size = new System.Drawing.Size(132, 23);
            this.txt_nomeCli.TabIndex = 63;
            // 
            // DgvPedNutri
            // 
            this.DgvPedNutri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPedNutri.Location = new System.Drawing.Point(3, 38);
            this.DgvPedNutri.Name = "DgvPedNutri";
            this.DgvPedNutri.Size = new System.Drawing.Size(690, 270);
            this.DgvPedNutri.TabIndex = 54;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 338);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 27);
            this.button1.TabIndex = 65;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnSelecionarCid
            // 
            this.BtnSelecionarCid.AutoSize = true;
            this.BtnSelecionarCid.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSelecionarCid.Location = new System.Drawing.Point(626, 338);
            this.BtnSelecionarCid.Name = "BtnSelecionarCid";
            this.BtnSelecionarCid.Size = new System.Drawing.Size(89, 27);
            this.BtnSelecionarCid.TabIndex = 64;
            this.BtnSelecionarCid.Text = "Selecionar";
            this.BtnSelecionarCid.UseVisualStyleBackColor = true;
            this.BtnSelecionarCid.Click += new System.EventHandler(this.BtnSelecionarCid_Click);
            // 
            // PesquisaPedidoNutrição
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 373);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BtnSelecionarCid);
            this.Name = "PesquisaPedidoNutrição";
            this.Text = "PesquisaPedidoNutrição";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPedNutri)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnPesquisar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_numPed;
        private System.Windows.Forms.Label Cidade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_nomeCli;
        private System.Windows.Forms.DataGridView DgvPedNutri;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnSelecionarCid;
    }
}