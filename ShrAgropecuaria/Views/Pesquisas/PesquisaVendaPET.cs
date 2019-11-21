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
    public partial class PesquisaVendaPET : Form
    {
        public IVendaPETRepository VendaPETRepository { get; }
        public VendaPET ProdutoPET = new VendaPET();

        public PesquisaVendaPET(IVendaPETRepository vendaPETRepository)
        {
            InitializeComponent();
            VendaPETRepository = vendaPETRepository;
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            List<VendaPET> venda = VendaPETRepository.getALL(txt_nome.Text).ToList();
            dgvDados.DataSource = venda;
        }

        private void BtnSelecionarCid_Click(object sender, EventArgs e)
        {
            try
            {
                ProdutoPET = dgvDados.CurrentRow?.DataBoundItem as VendaPET;
                if (dgvDados.CurrentRow != null)
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
