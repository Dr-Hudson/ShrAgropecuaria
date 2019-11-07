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
