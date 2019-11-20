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
    public partial class PesquisaCliente : Form
    {
        public Cliente cli = new Cliente();
        public IClienteRepository ClienteRepository { get; }
        public PesquisaCliente(IClienteRepository clienteRepository)
        {
            InitializeComponent();
            ClienteRepository = clienteRepository;
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            if (txt_nome.Text == "" && txt_cpf.Text == "")
            {
                List<Cliente> cli = ClienteRepository.GetAll("").ToList();
                DgvForn.DataSource = cli;
            }
            else
            if (txt_nome.Text != "" && txt_cpf.Text == "")
            {
                List<Cliente> cli = ClienteRepository.GetByNome(txt_nome.Text).ToList();
                DgvForn.DataSource = cli;
            }
            else if (txt_nome.Text == "" && txt_cpf.Text != "")
            {
                List<Cliente> cli = ClienteRepository.GetByCPF(txt_cpf.Text).ToList();
                DgvForn.DataSource = cli;
            }
            DgvForn.Columns.Remove("Cidadeid");
            DgvForn.Columns.Remove("Cidade");
            DgvForn.Columns["Cli_cod"].HeaderText = "Codigo";
            DgvForn.Columns["Cli_dataliberacao"].HeaderText = "Data de Liberação";
            DgvForn.Columns["Cli_limite"].HeaderText = "Limite";
            DgvForn.Columns["Cli_saldofiado"].HeaderText = "Saldo Fiado";
            DgvForn.Columns["Cli_bairro"].HeaderText = "Bairro";
            DgvForn.Columns["Cli_cep"].HeaderText = "CEP";
            DgvForn.Columns["Cli_complemento"].HeaderText = "Complemento";
            DgvForn.Columns["Cli_numero"].HeaderText = "Número";
            DgvForn.Columns["Cli_nome"].HeaderText = "Nome";
            DgvForn.Columns["Cli_cpf"].HeaderText = "CPF";
            DgvForn.Columns["Cli_rg"].HeaderText = "RG";
            DgvForn.Columns["Cli_endereco"].HeaderText = "Endereço";
            DgvForn.Columns["Cli_telefone"].HeaderText = "Telefone";
            DgvForn.Columns["CidadeNome"].HeaderText = "Cidade";
        }

        private void BtnSelecionarCid_Click(object sender, EventArgs e)
        {
            try
            {
                cli = DgvForn.CurrentRow?.DataBoundItem as Cliente;
                if (DgvForn.CurrentRow != null)
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
