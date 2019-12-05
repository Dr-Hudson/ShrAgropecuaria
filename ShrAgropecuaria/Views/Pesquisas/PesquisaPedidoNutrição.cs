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
    public partial class PesquisaPedidoNutrição : Form
    {
        public PedidoNutricao pedNutri = new PedidoNutricao();
        public IPedidoNutricaoRepository PedidoNutricaoRepository { get; }
        public PesquisaPedidoNutrição(IPedidoNutricaoRepository pedidoNutricaoRepository)
        {
            InitializeComponent();
            PedidoNutricaoRepository = pedidoNutricaoRepository;
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            DgvPedNutri.DataSource = null;

            if (txt_nomeCli.Text == "" && txt_numPed.Text == "")
            {
                List<PedidoNutricao> pedNutriList = PedidoNutricaoRepository.GetAll().ToList();
                DgvPedNutri.DataSource = pedNutriList;
            }
            else if (txt_nomeCli.Text != "" && txt_numPed.Text == "")
            {
                List<PedidoNutricao> pedNutriList = PedidoNutricaoRepository.GetByNomeCliente(txt_nomeCli.Text).ToList();
                DgvPedNutri.DataSource = pedNutriList;
            }
            else if (txt_nomeCli.Text == "" && txt_numPed.Text != "")
            {
                List<PedidoNutricao> pedNutriList = PedidoNutricaoRepository.GetByCod(txt_numPed.Text).ToList();
                DgvPedNutri.DataSource = pedNutriList;
            }
            else if (txt_nomeCli.Text != "" && txt_numPed.Text != "")
            {
                List<PedidoNutricao> pedNutriList = PedidoNutricaoRepository.GetByNomeCliente(txt_nomeCli.Text).ToList();
                DgvPedNutri.DataSource = pedNutriList;
            }

            DgvPedNutri.Columns.Remove("Fazenda");
            DgvPedNutri.Columns.Remove("Cliente");
            DgvPedNutri.Columns.Remove("Usuario");
            DgvPedNutri.Columns.Remove("faz_cod");
            DgvPedNutri.Columns.Remove("cli_cod");
            DgvPedNutri.Columns.Remove("User_cod");
            DgvPedNutri.Columns["Pn_cod"].HeaderText = "Codigo";
            DgvPedNutri.Columns["Pn_previsaoentrega"].HeaderText = "Previsão de Entrega";
            DgvPedNutri.Columns["Pn_dataentrega"].HeaderText = "Data de Entrega";
            DgvPedNutri.Columns["Pn_porcentagem"].HeaderText = "Porcentagem";
            DgvPedNutri.Columns["Pn_contato"].HeaderText = "Contato";
            DgvPedNutri.Columns["Pn_valortotal"].HeaderText = "Valor Total";
            DgvPedNutri.Columns["Pn_data"].HeaderText = "Data";
            DgvPedNutri.Columns["Pn_obs"].HeaderText = "Obs";
            DgvPedNutri.Columns["FazendaNome"].HeaderText = "Nome da Fazenda";
            DgvPedNutri.Columns["ClienteNome"].HeaderText = "Nome do Cliente";
            DgvPedNutri.Columns["Pn_formapgto"].HeaderText = "Forma de Pagamento";
        }

        private void BtnSelecionarCid_Click(object sender, EventArgs e)
        {
            try
            {
                pedNutri = DgvPedNutri.CurrentRow?.DataBoundItem as PedidoNutricao;
                if (DgvPedNutri.CurrentRow != null)
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

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
