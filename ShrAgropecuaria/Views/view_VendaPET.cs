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
            txtid.Visible = false;
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
            dgvProdutos.Columns["Pv_valor_total"].HeaderText = "Valor Total";

        }

        public void limpar()
        {
            txtcliente.Text = "";
            txtQtde.Text = "";
            txtValor.Text = "";
            dtpData.Value = DateTime.Now;
            dgvProdutos.DataSource = null;
            txtid.Visible = false;
            txtProduto.Text = "";
            txtParcelas.Text = "";
            txtProduto.Text = "";
            txtDias.Text = "";
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            int n;
            bool flag = true;
            List<ProdutoVenda> aa = new List<ProdutoVenda>();
            aa = (List<ProdutoVenda>)dgvProdutos.DataSource;
            if(produtos.Count == 0)
                if(aa != null)
                    foreach (var k in aa)
                        produtos.Add(k);
            if (int.TryParse(txtQtde.Text,out n) && n>0)
            {
                ProdutoPET a = new ProdutoPET();
                List<ProdutoPET> i = ProdutoPETRepository.GetByNome(txtProduto.Text).ToList();
                a = i[0];
                ProdutoVenda pv = new ProdutoVenda();
                    pv.Produto = a;
                    pv.Pv_quantidade = n;
                    pv.Pv_valor_unitario = a.Pp_valorunitario;
                    pv.Pv_valor_total = pv.Pv_quantidade * pv.Pv_valor_unitario;
                    if (a.Pp_estoque < n)
                        MessageBox.Show("Não é possível adicionar essa quantidade por falta de estoque!");
                    else
                    {
                        foreach (var b in produtos)
                        {
                            if (b.ProdutoID == pv.ProdutoID)
                            {
                                b.Pv_quantidade += pv.Pv_quantidade;
                                b.Pv_valor_total = b.Pv_valor_unitario * b.Pv_quantidade;
                                flag = false;
                            }
                                
                        }
                        if(flag)
                            produtos.Add(pv);
                        dgvProdutos.DataSource = null;
                        dgvProdutos.DataSource = produtos;
                        string s = txtValor.Text;
                        if (s == "")
                            txtValor.Text = (a.Pp_valorunitario * n).ToString();
                        else
                        {
                            decimal d = Convert.ToDecimal(txtValor.Text);
                            d += a.Pp_valorunitario * n;
                            txtValor.Text = d.ToString();
                        }
                        
                        RenomeiaCampos();
                    }

                    txtQtde.Text = "";
                txtProduto.Text = "";
                
                
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
                    txtValor.Text = d.ToString();
                    dgvProdutos.DataSource = null;
                    dgvProdutos.DataSource = produtos;
                }
                RenomeiaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnVender_Click(object sender, EventArgs e)
        {
            int parcelas =0, dias=0;
            VendaPET v = new VendaPET();
            bool flag = true;
            DateTime data = DateTime.Now;
            if (txtcliente.Text == null)
            {
                MessageBox.Show("Selecione um cliente");
            }
            else
            {
                if (txtid.Text != "")
                    v.Vp_cod = Convert.ToInt32(txtid.Text);
                if(produtos.Count == 0 )
                {
                    MessageBox.Show("Uma venda precisa ter pelo menos um produto!");
                }
                else
                {
                    v.Vp_valortotal = Convert.ToDecimal(txtValor.Text);
                    v.Cliente = cliente;
                    v.Vp_datavenda = dtpData.Value;
                    List<ProdutoVenda> lpv = VendaPETRepository.GetPVenda(v.Vp_cod).ToList();
                    if(rbParcelado.Checked)
                    {
                        flag = false;
                        if(txtParcelas.Text.Replace("R$", "").Replace("-", "").Replace("_", "").Replace(".", ",").Replace(" ", "").Replace(",", "").Length > 0)
                        {
                            string a = txtParcelas.Text.Replace("R$", "").Replace("-", "").Replace("_", "").Replace(".", ",").Replace(" ", "");
                             parcelas = Convert.ToInt32(a);
                            if(txtDias.Text.Replace("R$", "").Replace("-", "").Replace("_", "").Replace(".", ",").Replace(" ", "").Replace(",", "").Length > 0)
                            {
                                string b = txtParcelas.Text.Replace("R$", "").Replace("-", "").Replace("_", "").Replace(".", ",").Replace(" ", "");
                                dias = Convert.ToInt32(b);
                                data = dtpVencimentoParcela.Value;
                                flag = true;
                            }
                            else
                            {
                                MessageBox.Show("Dias invalidos");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Parcelas invalidas");
                        }
                    }
                    else
                    {
                        if(rbPrazo.Checked)
                           data = dtpVencimentoPrazo.Value;
                    }
                    if(flag)
                    {
                        if (txtid.Text != "")
                        {
                            foreach (var a in lpv)
                            {
                                int estoque = a.Produto.Pp_estoque + a.Pv_quantidade;
                                int? c = a.ProdutoID;
                                VendaPETRepository.atualizarproduto((int)c, estoque);
                            }
                        }
                        VendaPETRepository.gravar(v);
                        if (rbParcelado.Checked)
                        {
                            decimal total = v.Vp_valortotal;
                            decimal valorp = v.Vp_valortotal / parcelas;
                            ContasAReceber c;
                            for (int i = 0; i < parcelas; i++)
                            {
                                c = new ContasAReceber();
                                c.Cr_dataVencimento = data;
                                if (i + 1 != parcelas)
                                    c.Cr_valorAReceber = valorp;
                                else
                                    c.Cr_valorAReceber = total;
                                total -= valorp;
                                c.Cr_dataGeracao = DateTime.Now;
                                c.VendaPet = (int)v.Vp_cod;
                                c.UsuarioId = v.Usuarioid;
                                VendaPETRepository.GravarContas(c);
                                data = data.AddDays(dias);
                            }
                        }
                        else
                        {
                            if(rbPrazo.Checked)
                            {
                                ContasAReceber c = new ContasAReceber();
                                c.Cr_dataVencimento = data;
                                c.Cr_valorAReceber = v.Vp_valortotal;
                                c.VendaPet = (int)v.Vp_cod;
                                c.UsuarioId = v.Usuarioid;
                                VendaPETRepository.GravarContas(c);
                            }
                        }
                        foreach (var item in produtos)
                        {
                            item.Venda = v;
                            item.Vendaid = v.Vp_cod;
                            VendaPETRepository.GravarProds(item);
                            ProdutoPET pp = ProdutoPETRepository.Get(item.ProdutoID);
                            int n = pp.Pp_estoque - item.Pv_quantidade;
                            int? c = item.ProdutoID;
                            VendaPETRepository.atualizarproduto((int)c, n);
                        }
                        produtos.Clear();
                        limpar();
                        MessageBox.Show("Gravado com sucesso!");
                    }
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
                txtid.Text = a.VendPet.Vp_cod.ToString();
                cliente = a.VendPet.Cliente;
                dgvProdutos.DataSource = lpv;
                produtos.Clear();
                foreach (var k in lpv)
                    produtos.Add(k);
                RenomeiaCampos();
            }
        }


        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if(txtid.Text != "")
            {
                List<ProdutoVenda> lpv = (List<ProdutoVenda>)dgvProdutos.DataSource;
                ProdutoVenda k = new ProdutoVenda();
                foreach (var a in lpv)
                {
                    int estoque = a.Produto.Pp_estoque + a.Pv_quantidade;
                    int? c = a.ProdutoID;
                    VendaPETRepository.atualizarproduto((int)c, estoque);
                    k = a;


                }
                VendaPETRepository.Exclui(k, k.Venda);
                limpar();
                produtos.Clear();
                MessageBox.Show("Excluído com sucesso!");
            }
            else
            {
                MessageBox.Show("Selecione uma venda!");
            }
        }

        private void btnProd_Click(object sender, EventArgs e)
        {
            var a = new PesquisaProdutoPET(ProdutoPETRepository);

            if (a.ShowDialog() == DialogResult.OK)
            {
                txtProduto.Text = a.pp.Pp_descricao;
            }
        }

        private void view_VendaPET_Load(object sender, EventArgs e)
        {

        }

        private void rbVista_CheckedChanged(object sender, EventArgs e)
        {
            if(rbParcelado.Checked)
            {
                pnParcelado.Visible = true;
                pnPrazo.Visible = false;
            }
            else
            {
                if(rbPrazo.Checked)
                {
                    pnParcelado.Visible = false;
                    pnPrazo.Visible = true;
                }
                else
                {
                    if(rbVista.Checked)
                    {
                        pnPrazo.Visible = false;
                        pnParcelado.Visible = false;
                    }
                }
            }
        }
    }
}
