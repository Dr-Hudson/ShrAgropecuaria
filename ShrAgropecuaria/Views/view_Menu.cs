using ShrAgropecuaria.Classes;
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
    public partial class view_Menu : Form
    {
        public view_Menu()
        {
            InitializeComponent();
        }

        private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = Dependencia.Container.GetInstance<view_Fornecedor>();
            f.Show();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = Dependencia.Container.GetInstance<View_Cliente>();
            f.Show();
        }

        private void produtoPETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = Dependencia.Container.GetInstance<view_ProdutoPET>();
            f.Show();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = Dependencia.Container.GetInstance<view_Usuario>();
            f.Show();
        }

        private void produtoNutriçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = Dependencia.Container.GetInstance<view_ProdutoNutrição>();
            f.Show();
        }

        private void parametrizacaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = Dependencia.Container.GetInstance<view_Parametrização>();
            f.Show();
        }

        private void fiadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = Dependencia.Container.GetInstance<view_Fiado>();
            f.Show();
        }

        private void lançarDespesaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = Dependencia.Container.GetInstance<view_LancarDespesa>();
            f.Show();
        }

        private void entregaPedidoNutriçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = Dependencia.Container.GetInstance<view_ControlarEntregaPedidoNutrição>();
            f.Show();
        }

        private void quitarContasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = Dependencia.Container.GetInstance<view_QuitarContasAPagar>();
            f.Show();
        }

        private void pedidoNutriçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = Dependencia.Container.GetInstance<view_PedidoNutrição>();
            f.Show();
        }
    }
}
