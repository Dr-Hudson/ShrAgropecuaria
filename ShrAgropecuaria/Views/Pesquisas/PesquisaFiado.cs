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
    public partial class PesquisaFiado : Form
    {
        public IFiadoRepository FiadoRepository { get; }
        public Cliente cliente = new Cliente();
        public PesquisaFiado(IFiadoRepository fiadoRepository)
        {
            InitializeComponent();
            FiadoRepository = fiadoRepository;
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            string nome = txtUsuario.Text;
            try
            {
                List<Cliente> clientes = FiadoRepository.BuscaPorNome(nome).ToList();
                dgvDados.DataSource = clientes;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void BtnSelecionar_Click(object sender, EventArgs e)
        {
            try
            {
                cliente = dgvDados.CurrentRow?.DataBoundItem as Cliente;
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

        private void btCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
