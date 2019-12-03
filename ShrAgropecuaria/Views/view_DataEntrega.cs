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
    public partial class view_DataEntrega : Form
    {
        public DateTime dataEntrega;
        public view_DataEntrega(DateTime dataPedido)
        {
            InitializeComponent();
            dataE.MinDate = dataPedido;
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Confirmar_Click(object sender, EventArgs e)
        {
            try
            {
                dataEntrega = dataE.Value;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
