namespace ShrAgropecuaria.Views
{
    partial class view_Fiado
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
            this.btSelecionar = new System.Windows.Forms.Button();
            this.lbInstrucao = new System.Windows.Forms.Label();
            this.lbNome = new System.Windows.Forms.Label();
            this.lbRg = new System.Windows.Forms.Label();
            this.lbCpf = new System.Windows.Forms.Label();
            this.pnPagar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btPagar = new System.Windows.Forms.Button();
            this.txtValor = new System.Windows.Forms.MaskedTextBox();
            this.lbFiado = new System.Windows.Forms.Label();
            this.pnPagar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btSelecionar
            // 
            this.btSelecionar.Location = new System.Drawing.Point(148, 45);
            this.btSelecionar.Name = "btSelecionar";
            this.btSelecionar.Size = new System.Drawing.Size(104, 27);
            this.btSelecionar.TabIndex = 0;
            this.btSelecionar.Text = "Selecionar Cliente";
            this.btSelecionar.UseVisualStyleBackColor = true;
            this.btSelecionar.Click += new System.EventHandler(this.btSelecionar_Click);
            // 
            // lbInstrucao
            // 
            this.lbInstrucao.AutoSize = true;
            this.lbInstrucao.Location = new System.Drawing.Point(55, 9);
            this.lbInstrucao.Name = "lbInstrucao";
            this.lbInstrucao.Size = new System.Drawing.Size(0, 13);
            this.lbInstrucao.TabIndex = 1;
            // 
            // lbNome
            // 
            this.lbNome.AutoSize = true;
            this.lbNome.Location = new System.Drawing.Point(46, 97);
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(0, 13);
            this.lbNome.TabIndex = 2;
            // 
            // lbRg
            // 
            this.lbRg.AutoSize = true;
            this.lbRg.Location = new System.Drawing.Point(46, 128);
            this.lbRg.Name = "lbRg";
            this.lbRg.Size = new System.Drawing.Size(0, 13);
            this.lbRg.TabIndex = 3;
            // 
            // lbCpf
            // 
            this.lbCpf.AutoSize = true;
            this.lbCpf.Location = new System.Drawing.Point(46, 158);
            this.lbCpf.Name = "lbCpf";
            this.lbCpf.Size = new System.Drawing.Size(0, 13);
            this.lbCpf.TabIndex = 4;
            // 
            // pnPagar
            // 
            this.pnPagar.Controls.Add(this.label1);
            this.pnPagar.Controls.Add(this.btPagar);
            this.pnPagar.Controls.Add(this.txtValor);
            this.pnPagar.Location = new System.Drawing.Point(34, 216);
            this.pnPagar.Name = "pnPagar";
            this.pnPagar.Size = new System.Drawing.Size(325, 144);
            this.pnPagar.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Valor a ser pago do fiado";
            // 
            // btPagar
            // 
            this.btPagar.Location = new System.Drawing.Point(124, 107);
            this.btPagar.Name = "btPagar";
            this.btPagar.Size = new System.Drawing.Size(75, 23);
            this.btPagar.TabIndex = 1;
            this.btPagar.Text = "Pagar";
            this.btPagar.UseVisualStyleBackColor = true;
            this.btPagar.Click += new System.EventHandler(this.btPagar_Click);
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(114, 42);
            this.txtValor.Mask = "$ 00000000,00";
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(93, 20);
            this.txtValor.TabIndex = 0;
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            // 
            // lbFiado
            // 
            this.lbFiado.AutoSize = true;
            this.lbFiado.Location = new System.Drawing.Point(46, 185);
            this.lbFiado.Name = "lbFiado";
            this.lbFiado.Size = new System.Drawing.Size(0, 13);
            this.lbFiado.TabIndex = 6;
            // 
            // view_Fiado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 398);
            this.Controls.Add(this.lbFiado);
            this.Controls.Add(this.pnPagar);
            this.Controls.Add(this.lbCpf);
            this.Controls.Add(this.lbRg);
            this.Controls.Add(this.lbNome);
            this.Controls.Add(this.lbInstrucao);
            this.Controls.Add(this.btSelecionar);
            this.Name = "view_Fiado";
            this.Text = "Fiado";
            this.pnPagar.ResumeLayout(false);
            this.pnPagar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSelecionar;
        private System.Windows.Forms.Label lbInstrucao;
        private System.Windows.Forms.Label lbNome;
        private System.Windows.Forms.Label lbRg;
        private System.Windows.Forms.Label lbCpf;
        private System.Windows.Forms.Panel pnPagar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btPagar;
        private System.Windows.Forms.MaskedTextBox txtValor;
        private System.Windows.Forms.Label lbFiado;
    }
}