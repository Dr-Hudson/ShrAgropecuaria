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
    public partial class PesquisaProdutoNutricao : Form
    {
        public IProdutoNutricao ProdutoRepository { get; }

        public ProdutoNutricao Produto = new ProdutoNutricao();
        public PesquisaProdutoNutricao(IProdutoNutricao produtoNutricao)
        {
            InitializeComponent();
            ProdutoRepository = produtoNutricao;
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            string user = txtUsuario.Text;
            try
            {
                List<ProdutoNutricao> produtos = ProdutoRepository.GetByNome(user).ToList();
                dgvDados.DataSource = produtos;
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
                Produto = dgvDados.CurrentRow?.DataBoundItem as ProdutoNutricao;
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

        private void BtCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
