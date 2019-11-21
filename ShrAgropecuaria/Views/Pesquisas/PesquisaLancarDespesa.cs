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
            List<ContasAPagar> CAP = new List<ContasAPagar>();

            if (txt_id.Text == "" && txt_nome.Text != "")
            {
                CAP = Icontasapagar.GetAll(txt_nome.Text).ToList();
                DgvDespesa.DataSource = CAP;
            }
            else if (txt_id.Text == "" && txt_nome.Text == "" && dtpData.Value != null)
            {
                string a, b;
                DateTime c, d;
                a = dtpData.Value.ToString();
                b = dtpData.Value.Date.ToString();
                a= a.Replace("/", "-");
                b= b.Replace("/", "-");
                c = DateTime.Parse(a);
                d = DateTime.Parse(b);
                CAP = Icontasapagar.Filtro(d,c).ToList();
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

        private void PesquisaLancarDespesa_Load(object sender, EventArgs e)
        {
            List<ContasAPagar> CAP = Icontasapagar.GetAll("").ToList();
            DgvDespesa.DataSource = CAP;
        }
    }
    
}
