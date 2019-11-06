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

        private void FornecedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var f = Dependencia.Container.GetInstance<view_Fornecedor>();
            f.Show();
        }

        private void ClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = Dependencia.Container.GetInstance<View_Cliente>();
            f.Show();
        }

        private void produtosPETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = Dependencia.Container.GetInstance<view_ProdutoPET>();
            f.Show();
        }

        private void UsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = Dependencia.Container.GetInstance<view_Usuario>();
            f.ShowDialog();
        }
    }
}
