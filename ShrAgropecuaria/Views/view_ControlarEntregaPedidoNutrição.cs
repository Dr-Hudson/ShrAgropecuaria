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
        public view_ControlarEntregaPedidoNutrição(IClienteRepository clienteRepository, IFazendaRepository fazendaRepository)
        {
            InitializeComponent();
            ClienteRepository = clienteRepository;
            FazendaRepository = fazendaRepository;
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
            txt_idFazenda.Text = "";
            txt_nomeFazenda.Text = "";
            txt_idCli.Text = "";
            txt_nomeCliente.Text = "";

            btn_pesqFazenda.Enabled = false;
            radio_entregue.Enabled = false;
            radio_naoEntregue.Enabled = false;
        }

        private void radio_entregue_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_entregue.Checked)
            {
                int idCli = Convert.ToInt32(txt_idCli.Text);
                int idFaz = Convert.ToInt32(txt_idFazenda.Text);
                List<PedidoNutricao> li = FazendaRepository.GetByPedido(idCli, idFaz, true).ToList();
                dataGridView1.DataSource = li;
            }
            else
            {
                int idCli = Convert.ToInt32(txt_idCli.Text);
                int idFaz = Convert.ToInt32(txt_idFazenda.Text);
                List<PedidoNutricao> li = FazendaRepository.GetByPedido(idCli, idFaz, false).ToList();
                dataGridView1.DataSource = li;
            }
        }

        private void radio_naoEntregue_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_naoEntregue.Checked)
            {
                int idCli = Convert.ToInt32(txt_idCli.Text);
                int idFaz = Convert.ToInt32(txt_idFazenda.Text);
                List<PedidoNutricao> li = FazendaRepository.GetByPedido(idCli, idFaz, false).ToList();
                dataGridView1.DataSource = li;
            }
            else
            {
                int idCli = Convert.ToInt32(txt_idCli.Text);
                int idFaz = Convert.ToInt32(txt_idFazenda.Text);
                List<PedidoNutricao> li = FazendaRepository.GetByPedido(idCli, idFaz, true).ToList();
                dataGridView1.DataSource = li;
            }
        }
    }
}
