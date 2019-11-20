namespace ShrAgropecuaria.Views.Pesquisas
{
    partial class PesquisaFazenda
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
            this.txt_ie = new System.Windows.Forms.TextBox();
            this.Cidade = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_nome = new System.Windows.Forms.TextBox();
            this.DgvForn = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnSelecionarCid = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvForn)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnPesquisar
            // 
            this.BtnPesquisar.Location = new System.Drawing.Point(618, 5);
            this.BtnPesquisar.Name = "BtnPesquisar";
            this.BtnPesquisar.Size = new System.Drawing.Size(67, 25);
            this.BtnPesquisar.TabIndex = 64;
            this.BtnPesquisar.Text = "Pesquisar";
            this.BtnPesquisar.UseVisualStyleBackColor = true;
            this.BtnPesquisar.Click += new System.EventHandler(this.BtnPesquisar_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txt_ie);
            this.panel1.Controls.Add(this.Cidade);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.BtnPesquisar);
            this.panel1.Controls.Add(this.txt_nome);
            this.panel1.Controls.Add(this.DgvForn);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(696, 311);
            this.panel1.TabIndex = 60;
            // 
            // txt_ie
            // 
            this.txt_ie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_ie.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ie.Location = new System.Drawing.Point(247, 7);
            this.txt_ie.Name = "txt_ie";
            this.txt_ie.Size = new System.Drawing.Size(132, 23);
            this.txt_ie.TabIndex = 69;
            // 
            // Cidade
            // 
            this.Cidade.AutoSize = true;
            this.Cidade.Location = new System.Drawing.Point(201, 11);
            this.Cidade.Name = "Cidade";
            this.Cidade.Size = new System.Drawing.Size(23, 13);
            this.Cidade.TabIndex = 68;
            this.Cidade.Text = "I.E.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 15);
            this.label4.TabIndex = 65;
            this.label4.Text = "Nome";
            // 
            // txt_nome
            // 
            this.txt_nome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_nome.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nome.Location = new System.Drawing.Point(48, 8);
            this.txt_nome.Name = "txt_nome";
            this.txt_nome.Size = new System.Drawing.Size(132, 23);
            this.txt_nome.TabIndex = 63;
            // 
            // DgvForn
            // 
            this.DgvForn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvForn.Location = new System.Drawing.Point(3, 38);
            this.DgvForn.Name = "DgvForn";
            this.DgvForn.Size = new System.Drawing.Size(690, 270);
            this.DgvForn.TabIndex = 54;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 329);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 62;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnSelecionarCid
            // 
            this.BtnSelecionarCid.Location = new System.Drawing.Point(630, 329);
            this.BtnSelecionarCid.Name = "BtnSelecionarCid";
            this.BtnSelecionarCid.Size = new System.Drawing.Size(75, 23);
            this.BtnSelecionarCid.TabIndex = 61;
            this.BtnSelecionarCid.Text = "Selecionar";
            this.BtnSelecionarCid.UseVisualStyleBackColor = true;
            this.BtnSelecionarCid.Click += new System.EventHandler(this.BtnSelecionarCid_Click);
            // 
            // PesquisaFazenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 366);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BtnSelecionarCid);
            this.MaximumSize = new System.Drawing.Size(734, 405);
            this.MinimumSize = new System.Drawing.Size(734, 405);
            this.Name = "PesquisaFazenda";
            this.Text = "PesquisaFazenda";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvForn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnPesquisar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_ie;
        private System.Windows.Forms.Label Cidade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_nome;
        private System.Windows.Forms.DataGridView DgvForn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnSelecionarCid;
    }
}