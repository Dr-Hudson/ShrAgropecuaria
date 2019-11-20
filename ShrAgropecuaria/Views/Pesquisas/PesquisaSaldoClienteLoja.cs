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
    public partial class PesquisaSaldoClienteLoja : Form
    {
        public ISaldoProdutoNutricao SaldoProdutoRepository { get; }

        public SaldoClientePedidoLoja SaldoProduto;
        public PesquisaSaldoClienteLoja(ISaldoProdutoNutricao saldoProduto)
        {
            InitializeComponent();
            SaldoProdutoRepository = saldoProduto;
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                List<SaldoClientePedidoLoja> saldos = SaldoProdutoRepository.BuscaPorFazenda(txtUsuario.Text).ToList();
                dgvDados.DataSource = saldos;
            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void BtnSelecionar_Click(object sender, EventArgs e)
        {
            try
            {
                SaldoProduto = dgvDados.CurrentRow?.DataBoundItem as SaldoClientePedidoLoja;
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
