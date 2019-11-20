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

        private void btn_pesqCliente_Click(object sender, EventArgs e)
        {
            var a = new PesquisaCliente(ClienteRepository);
            if (a.ShowDialog() == DialogResult.OK)
            {
                txt_idCli.Text = a.cli.Cli_cod.ToString();
                txt_nomeCliente.Text = a.cli.Cli_nome;
                btn_pesqFazenda.Enabled = true;
            }
        }

        private void btn_pesqFazenda_Click(object sender, EventArgs e)
        {
            if (txt_idCli.Text.Length > 0)
            {
                var a = new PesquisaFazenda(FazendaRepository);
                if (a.ShowDialog() == DialogResult.OK)
                {
                    txt_idFazenda.Text = a.faz.Faz_cod.ToString();
                    txt_nomeFazenda.Text = a.faz.Faz_nome;
                    radio_entregue.Enabled = true;
                    radio_naoEntregue.Enabled = true;
                }
            }
            else
                MessageBox.Show("Selecione um Cliente");
        }

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            LimparTudo();
        }

        public void LimparTudo()
        {
            txt_idFazenda.Text = "";
            txt_nomeFazenda.Text = "";
            txt_idCli.Text = "";
            txt_nomeCliente.Text = "";

            dataGridView1.DataSource = null;

            radio_entregue.Checked = false;
            radio_naoEntregue.Checked = false;

            btn_pesqFazenda.Enabled = false;
            radio_entregue.Enabled = false;
            radio_naoEntregue.Enabled = false;
            btn_nEntregue.Visible = false;
            btn_gravar.Visible = true;
        }

        private void btn_gravar_Click(object sender, EventArgs e)
        {
            var ok = new view_DataEntrega();
            if (ok.ShowDialog() == DialogResult.OK)
            {
                PedidoNutricao p = new PedidoNutricao
                {
                    Pn_cod = (int)dataGridView1.CurrentRow.Cells[0].Value,
                    Pn_dataentrega = ok.dataEntrega
                };
                PedidoNutricaoRepository.AlterarDataEntrega(p);
                LimparTudo();
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
                LimparTudo();
                MessageBox.Show("Alterado Com Sucesso");
            }
        }

        private void radio_entregue_Click(object sender, EventArgs e)
        {
            btn_nEntregue.Visible = true;
            btn_gravar.Visible = false;
            int idCli = Convert.ToInt32(txt_idCli.Text);
            int idFaz = Convert.ToInt32(txt_idFazenda.Text);
            List<PedidoNutricao> li = PedidoNutricaoRepository.GetByPedido(idCli, idFaz, true).ToList();
            dataGridView1.DataSource = li;
        }

        private void radio_naoEntregue_Click(object sender, EventArgs e)
        {
            btn_nEntregue.Visible = false;
            btn_gravar.Visible = true;
            int idCli = Convert.ToInt32(txt_idCli.Text);
            int idFaz = Convert.ToInt32(txt_idFazenda.Text);
            List<PedidoNutricao> li = PedidoNutricaoRepository.GetByPedido(idCli, idFaz, false).ToList();
            dataGridView1.DataSource = li;
        }
    }
}
