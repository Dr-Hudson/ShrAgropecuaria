using ShrAgropecuaria.Classes;
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
    public partial class view_ControlarEntregaPedidoNutrição : Form
    {
        public IClienteRepository ClienteRepository { get; }
        public IFazendaRepository FazendaRepository { get; }
        public IPedidoNutricaoRepository PedidoNutricaoRepository { get; }
        public view_ControlarEntregaPedidoNutrição(IClienteRepository clienteRepository, IFazendaRepository fazendaRepository, IPedidoNutricaoRepository pedidoNutricaoRepository)
        {
            InitializeComponent();
            ClienteRepository = clienteRepository;
            FazendaRepository = fazendaRepository;
            PedidoNutricaoRepository = pedidoNutricaoRepository;
        }

        public void CarregaFazendas()
        {
            List<Fazenda> fazendas = new List<Fazenda>();
            fazendas = FazendaRepository.GetByCliente(txt_idCli.Text).ToList();
            cbb_Fazenda.Items.Clear();
            foreach (var item in fazendas)
            {
                cbb_Fazenda.Items.Add(item.Faz_nome);
            }
            if (cbb_Fazenda.Items.Count > 0)
                cbb_Fazenda.SelectedIndex = 0;
        }


        private void btn_limpar_Click(object sender, EventArgs e)
        {
            LimparTudo();
        }

        public void LimparTudo()
        {
            cbb_Fazenda.Items.Clear();
            cbb_Fazenda.Text = "";
            txt_idCli.Text = "";
            txt_nomeCliente.Text = "";

            dataGridView1.DataSource = null;

            radio_entregue.Checked = false;
            radio_naoEntregue.Checked = false;

            radio_entregue.Enabled = false;
            radio_naoEntregue.Enabled = false;
            btn_nEntregue.Visible = false;
            btn_gravar.Visible = true;
        }

        private void btn_gravar_Click(object sender, EventArgs e)//marcar como entregue
        {
            DateTime dataPedido = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[5].Value);
            var ok = new view_DataEntrega(dataPedido);
            if (ok.ShowDialog() == DialogResult.OK)
            {
                PedidoNutricao p = new PedidoNutricao
                {
                    Pn_cod = (int)dataGridView1.CurrentRow.Cells[0].Value,
                    Pn_dataentrega = ok.dataEntrega
                };
                dataGridView1.CurrentRow.Cells[2].Value = p.Pn_dataentrega;
                PedidoNutricaoRepository.AlterarDataEntrega(p);
                //LimparTudo();
                MessageBox.Show("Alterado Com Sucesso");
            }
        }

        private void btn_nEntregue_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Deseja marcar como Não Entregue?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                PedidoNutricao p = new PedidoNutricao
                {
                    Pn_cod = (int)dataGridView1.CurrentRow.Cells[0].Value,
                };
                dataGridView1.CurrentRow.Cells[2].Value = null;
                PedidoNutricaoRepository.AlterarDataEntrega(p);
                //LimparTudo();
                MessageBox.Show("Alterado Com Sucesso");
            }
        }

        private void radio_entregue_Click(object sender, EventArgs e)
        {
            Fazenda faz = FazendaRepository.GetByNome(cbb_Fazenda.SelectedItem.ToString()).First();

            btn_nEntregue.Visible = true;
            btn_gravar.Visible = false;
            int idCli = Convert.ToInt32(txt_idCli.Text);
            int idFaz = (int)faz.Faz_cod;
            List<PedidoNutricao> li = PedidoNutricaoRepository.GetByPedido(idCli, idFaz, true).ToList();
            dataGridView1.DataSource = li;
            ArrumaGrid();
        }

        private void radio_naoEntregue_Click(object sender, EventArgs e)
        {
            Fazenda faz = FazendaRepository.GetByNome(cbb_Fazenda.SelectedItem.ToString()).First();

            btn_nEntregue.Visible = false;
            btn_gravar.Visible = true;
            int idCli = Convert.ToInt32(txt_idCli.Text);
            int idFaz = (int)faz.Faz_cod;
            List<PedidoNutricao> li = PedidoNutricaoRepository.GetByPedido(idCli, idFaz, false).ToList();
            dataGridView1.DataSource = li;
            ArrumaGrid();
        }

        private void btn_pesqCliente_Click(object sender, EventArgs e)
        {
            var a = new PesquisaCliente(ClienteRepository);
            if (a.ShowDialog() == DialogResult.OK)
            {
                txt_idCli.Text = a.cli.Cli_cod.ToString();
                txt_nomeCliente.Text = a.cli.Cli_nome;
                CarregaFazendas();
                radio_entregue.Enabled = true;
                radio_naoEntregue.Enabled = true;
            }
        }

        public void ArrumaGrid()
        {
            dataGridView1.Columns.Remove("faz_cod");
            dataGridView1.Columns.Remove("cli_cod");
            dataGridView1.Columns.Remove("User_cod");
            dataGridView1.Columns.Remove("Pn_formapgto");
            dataGridView1.Columns.Remove("Usuario");
            dataGridView1.Columns.Remove("Cliente");
            dataGridView1.Columns.Remove("Fazenda");
            dataGridView1.Columns.Remove("Pn_porcentagem");
            dataGridView1.Columns["ClienteNome"].HeaderText = "Nome do Cliente";
            dataGridView1.Columns["FazendaNome"].HeaderText = "Nome da Fazenda";
            dataGridView1.Columns["Pn_obs"].HeaderText = "Observação";
            dataGridView1.Columns["Pn_data"].HeaderText = "Data do Pedido";
            dataGridView1.Columns["Pn_valortotal"].HeaderText = "Valor Total";
            dataGridView1.Columns["Pn_contato"].HeaderText = "Telefone de Contato";
            dataGridView1.Columns["Pn_dataentrega"].HeaderText = "Data de Entrega";
            dataGridView1.Columns["Pn_previsaoentrega"].HeaderText = "Previsão de Entrega";
            dataGridView1.Columns["Pn_cod"].HeaderText = "Codigo";
        }

        private void cbb_Fazenda_SelectedValueChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            radio_entregue.Checked = false;
            radio_naoEntregue.Checked = false;
        }
    }
}
