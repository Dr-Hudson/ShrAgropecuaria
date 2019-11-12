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
            this.button1 = new System.Windows.Forms.Button();
            this.lbInstrucao = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(148, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = "Selecionar Cliente";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lbInstrucao
            // 
            this.lbInstrucao.AutoSize = true;
            this.lbInstrucao.Location = new System.Drawing.Point(55, 9);
            this.lbInstrucao.Name = "lbInstrucao";
            this.lbInstrucao.Size = new System.Drawing.Size(0, 13);
            this.lbInstrucao.TabIndex = 1;
            // 
            // view_Fiado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 398);
            this.Controls.Add(this.lbInstrucao);
            this.Controls.Add(this.button1);
            this.Name = "view_Fiado";
            this.Text = "view_Fiado";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbInstrucao;
    }
}