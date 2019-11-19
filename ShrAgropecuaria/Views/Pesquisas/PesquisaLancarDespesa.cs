using ShrAgropecuaria.Classes;
using ShrAgropecuaria.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShrAgropecuaria.Views.Pesquisas
{
    public partial class PesquisaLancarDespesa : Form
    {
        public ContasAPagar CAP = new ContasAPagar();

        IContasAPagarRepository Icontasapagar { get; }
        public PesquisaLancarDespesa(IContasAPagarRepository contasapagar)
        {
            InitializeComponent();
            Icontasapagar = contasapagar;
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            if (txt_id.Text == "" && txt_nome.Text == "")
            {
                List<ContasAPagar> CAP = Icontasapagar.GetAll("").ToList();
                DgvDespesa.DataSource = CAP;
            }
            else if(txt_id.Text == "" && txt_nome.Text != "")
            {
                List<ContasAPagar> CAP = Icontasapagar.GetAll(txt_nome.Text).ToList();
                DgvDespesa.DataSource = CAP;
            }
            
            
        }

        private void BtnSelecionarCid_Click(object sender, EventArgs e)
        {
            try
            {
                CAP = DgvDespesa.CurrentRow?.DataBoundItem as ContasAPagar;
                if (DgvDespesa.CurrentRow != null)
                {
                    DialogResult = DialogResult.OK;
                    Close();

                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }
    }
    
}
