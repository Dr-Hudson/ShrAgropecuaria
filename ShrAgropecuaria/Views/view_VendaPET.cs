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
    public partial class view_VendaPET : Form
    {
        public Cliente cliente; 
        public IVendaPETRepository VendaPETRepository { get; }
        public IClienteRepository ClienteRepository { get; }
        public IProdutoPETRepository ProdutoPETRepository { get; }
        List<ProdutoPET> produtos = new List<ProdutoPET>();
        public view_VendaPET(IVendaPETRepository vendaPETRepository, IClienteRepository clienteRepository, IProdutoPETRepository produtoPETRepository)
        {
            InitializeComponent();
            VendaPETRepository = vendaPETRepository;
            ClienteRepository = clienteRepository;
            ProdutoPETRepository = produtoPETRepository;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var a = new PesquisaCliente(ClienteRepository);
            if (a.ShowDialog() == DialogResult.OK)
            {
                cliente = a.cli;
                txtcliente.Text = a.cli.Cli_nome;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var a = new PesquisaProdutoPET(ProdutoPETRepository);
            if (a.ShowDialog() == DialogResult.OK)
            {
                produtos.Add(a.pp);
                dgvProdutos.DataSource = produtos;
            }
        }


    }
}
