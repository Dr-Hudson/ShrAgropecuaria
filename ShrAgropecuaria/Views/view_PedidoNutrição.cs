using ShrAgropecuaria.Repositorios.Interfaces;
using ShrAgropecuaria.Views.Pesquisas;
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
    public partial class view_PedidoNutrição : Form
    {
        public IPedidoNutricaoRepository PedidoNutricaoRepository { get; }
        public view_PedidoNutrição(IPedidoNutricaoRepository pedidoNutricaoRepository)
        {
            InitializeComponent();
            PedidoNutricaoRepository = pedidoNutricaoRepository;
        }

        private void btn_pesqPedido_Click(object sender, EventArgs e)
        {
            var a = new PesquisaPedidoNutrição(PedidoNutricaoRepository);
            if (a.ShowDialog() == DialogResult.OK)
            {
                //
            }
        }
    }
}
