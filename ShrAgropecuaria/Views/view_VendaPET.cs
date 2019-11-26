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
        List<ProdutoVenda> produtos = new List<ProdutoVenda>();
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

        public void RenomeiaCampos()
        {
            dgvProdutos.Columns.Remove("Venda");
            dgvProdutos.Columns.Remove("Vendaid");
            dgvProdutos.Columns.Remove("ProdutoID");
            dgvProdutos.Columns.Remove("Produto");
            dgvProdutos.Columns["DescricaoProduto"].HeaderText = "Produto";
            dgvProdutos.Columns["Pv_quantidade"].HeaderText = "Quantidade";
            dgvProdutos.Columns["Pv_valor_unitario"].HeaderText = "Valor Unitário";

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            int n;
            if(int.TryParse(txtQtde.Text,out n) && n>0)
            { 
                var a = new PesquisaProdutoPET(ProdutoPETRepository);
                if (a.ShowDialog() == DialogResult.OK)
                {
                    ProdutoVenda pv = new ProdutoVenda();
                    pv.Produto = a.pp;
                    pv.Pv_quantidade = n;
                    pv.Pv_valor_unitario = a.pp.Pp_valorunitario;
                    produtos.Add(pv);
                    dgvProdutos.DataSource = null;
                    dgvProdutos.DataSource = produtos;
                    string s = txtValor.Text;
                    if (s == "")
                        txtValor.Text = (a.pp.Pp_valorunitario * n).ToString();
                    else
                    {
                        decimal d = Convert.ToDecimal(txtValor.Text);
                        d += a.pp.Pp_valorunitario * n;
                        txtValor.Text = d.ToString();
                    }
                    txtQtde.Text = "";
                }
                RenomeiaCampos();
            }
        }

        private void BtnRmv_Click(object sender, EventArgs e)
        {
            try
            {
                ProdutoVenda pv = dgvProdutos.CurrentRow?.DataBoundItem as ProdutoVenda;
                if (dgvProdutos.CurrentRow != null)
                {
                    produtos.Remove(pv);
                    decimal d = Convert.ToDecimal(txtValor.Text);
                    d -= pv.Pv_quantidade * pv.Produto.Pp_valorunitario;
                    dgvProdutos.DataSource = null;
                    dgvProdutos.DataSource = produtos;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnVender_Click(object sender, EventArgs e)
        {
            VendaPET v = new VendaPET();
            if(txtcliente.Text == null)
            {
                MessageBox.Show("Selecione um cliente");
            }
            else
            {
                v.Cliente = cliente;
                v.Vp_datavenda = dtpData.Value;
                v.Vp_valortotal = Convert.ToDecimal(txtValor.Text);
                if(produtos.Count == 0 )
                {
                    MessageBox.Show("Uma venda precisa ter pelo menos um produto!");
                }
                else
                {
                    VendaPETRepository.gravar(v);
                    foreach (var item in produtos)
                    {
                        item.Venda = v;
                        item.Vendaid = v.Vp_cod;
                        VendaPETRepository.GravarProds(item);
                        int n = item.Produto.Pp_estoque - item.Pv_quantidade;
                        int? c = item.ProdutoID;
                        VendaPETRepository.atualizarproduto((int)c, n);
                    }
                    txtcliente.Text = "";
                    cliente = null;
                    produtos.Clear();
                    dgvProdutos.DataSource = null;
                    txtValor.Text = "";
                }
            }
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            var a = new PesquisaVendaPET(VendaPETRepository);
            
            if (a.ShowDialog() == DialogResult.OK)
            {
                List<ProdutoVenda> lpv = new List<ProdutoVenda>();
                lpv = VendaPETRepository.GetPVenda(a.VendPet.Vp_cod).ToList();
                txtcliente.Text = a.VendPet.Cliente.Cli_nome;
                txtValor.Text = a.VendPet.Vp_valortotal.ToString();
                dtpData.Value = a.VendPet.Vp_datavenda;
                dgvProdutos.DataSource = lpv;
                RenomeiaCampos();
                
                
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

        }
    }
}
