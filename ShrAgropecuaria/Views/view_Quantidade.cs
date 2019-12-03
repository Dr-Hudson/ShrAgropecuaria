using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShrAgropecuaria.Views
{
    public partial class view_Quantidade : Form
    {
        public int quant;
        public view_Quantidade()
        {
            InitializeComponent();
        }

        private void txt_quant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Confirmar_Click(object sender, EventArgs e)
        {
            try
            {
                quant = Convert.ToInt32(txt_quant.Text);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_quant_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_quant_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_quant.Text == "0" || (txt_quant.Text != "" && Convert.ToInt32(txt_quant.Text) > 1000000))
            {
                txt_quant.Text = "";
            }
        }
    }
}
