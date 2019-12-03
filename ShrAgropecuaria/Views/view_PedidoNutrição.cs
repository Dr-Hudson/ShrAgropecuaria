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
    public partial class view_PedidoNutrição : Form
    {
        public List<ProdutoPedidoNutricao> prodPedNutriList = new List<ProdutoPedidoNutricao>();

        public IClienteRepository ClienteRepository { get; }
        public IFazendaRepository FazendaRepository { get; }
        public IProdutoNutricao ProdutoNutricao { get; }
        public IPedidoNutricaoRepository PedidoNutricaoRepository { get; }
        public view_PedidoNutrição(IClienteRepository clienteRepository, IFazendaRepository fazendaRepository, IPedidoNutricaoRepository pedidoNutricaoRepository,
            IProdutoNutricao produtoNutricao)
        {
            InitializeComponent();
            PedidoNutricaoRepository = pedidoNutricaoRepository;
            ClienteRepository = clienteRepository;
            FazendaRepository = fazendaRepository;
            ProdutoNutricao = produtoNutricao;


            cbb_FormaPgto.Items.Add(15);
            cbb_FormaPgto.Items.Add(30);
            cbb_FormaPgto.Items.Add(60);
            cbb_FormaPgto.Items.Add(90);
            cbb_FormaPgto.SelectedIndex = 0;
            dataE.MinDate = DateTime.Now;
            txt_valorTotal.Text = "0";
            mask_porcentagem.Text = "5";
        }

        private void btn_pesqPedido_Click(object sender, EventArgs e)
        {
            var a = new PesquisaPedidoNutrição(PedidoNutricaoRepository);
            if (a.ShowDialog() == DialogResult.OK)
            {
                txt_codPedido.Text = a.pedNutri.Pn_cod.ToString();

                txt_idCli.Text = a.pedNutri.Cliente.Cli_cod.ToString();
                txt_nomeCliente.Text = a.pedNutri.ClienteNome;
                CarregaFazendas();
                cbb_Fazenda.SelectedItem = a.pedNutri.Fazenda.Faz_nome;

                txt_obs.Text = a.pedNutri.Pn_obs;
                txt_valorTotal.Text = a.pedNutri.Pn_valortotal.ToString();
                mask_telefone.Text = a.pedNutri.Pn_contato;
                mask_porcentagem.Text = a.pedNutri.Pn_porcentagem.ToString();
                cbb_FormaPgto.SelectedItem = a.pedNutri.Pn_formapgto;

                prodPedNutriList = PedidoNutricaoRepository.GetByProduto(txt_codPedido.Text).ToList();
                dataGridView1.DataSource = prodPedNutriList;
                ArrumaGrid();
            }
        }

        public void ArrumaGrid()
        {
            dataGridView1.Columns.Remove("PedidoNutricao");
            dataGridView1.Columns.Remove("ProdutoNutricao");
            dataGridView1.Columns.Remove("idPedNutri");
            dataGridView1.Columns.Remove("idProdNutri");
            dataGridView1.Columns["Ppn_quantidade"].HeaderText = "Quantidade";
            dataGridView1.Columns["Ppn_peso"].HeaderText = "Peso";
            dataGridView1.Columns["Ppn_valorvenda"].HeaderText = "Valor";
            dataGridView1.Columns["NomeProd"].HeaderText = "Nome do Produto";
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

        private void btn_pesqCliente_Click(object sender, EventArgs e)
        {
            var a = new PesquisaCliente(ClienteRepository);
            if (a.ShowDialog() == DialogResult.OK)
            {
                txt_idCli.Text = a.cli.Cli_cod.ToString();
                txt_nomeCliente.Text = a.cli.Cli_nome;
                CarregaFazendas();
            }
        }

        private void btn_adicionar_Click(object sender, EventArgs e)
        {
            var a = new PesquisaProdutoNutricao(ProdutoNutricao);
            if (a.ShowDialog() == DialogResult.OK)
            {
                ProdutoPedidoNutricao prodPedNutri = new ProdutoPedidoNutricao();
                prodPedNutri.ProdutoNutricao = a.Produto;
                prodPedNutri.PedidoNutricao = null;



                var b = new view_Quantidade();
                if (b.ShowDialog() == DialogResult.OK)
                {
                    bool achou = false;
                    foreach (var item in prodPedNutriList)
                    {
                        if (item.ProdutoNutricao.Prodn_cod == prodPedNutri.ProdutoNutricao.Prodn_cod)
                        {
                            item.Ppn_quantidade += b.quant;
                            item.Ppn_peso += b.quant * 20;
                            item.Ppn_valorvenda += b.quant * a.Produto.Prod_valorunitario;
                            //txt_valorTotal.Text = (Convert.ToDecimal(txt_valorTotal.Text) + item.Ppn_valorvenda).ToString();
                            achou = true;
                            break;
                        }
                    }

                    if (!achou)
                    {
                        prodPedNutri.Ppn_quantidade = b.quant;
                        prodPedNutri.Ppn_peso = b.quant * 20;
                        prodPedNutri.Ppn_valorvenda = b.quant * a.Produto.Prod_valorunitario;
                        //txt_valorTotal.Text = (Convert.ToDecimal(txt_valorTotal.Text) + prodPedNutri.Ppn_valorvenda).ToString();
                        prodPedNutriList.Add(prodPedNutri);
                    }

                    decimal val = 0;
                    foreach (var item in prodPedNutriList)
                    {
                        val += item.Ppn_valorvenda;
                    }
                    txt_valorTotal.Text = val.ToString();

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = prodPedNutriList;
                    ArrumaGrid();
                }
            }
        }

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            LimparTudo();
        }

        public void LimparTudo()
        {
            txt_codPedido.Text = "";
            txt_idCli.Text = "";
            txt_nomeCliente.Text = "";
            txt_obs.Text = "";
            txt_valorTotal.Text = "0";
            mask_porcentagem.Text = "5";
            dataE.Value = DateTime.Now;
            mask_telefone.Text = "";
            cbb_FormaPgto.SelectedIndex = 0;
            cbb_Fazenda.Items.Clear();
            cbb_Fazenda.Text = "";
            dataGridView1.DataSource = null;
            prodPedNutriList = new List<ProdutoPedidoNutricao>();
        }

        private void btn_gravar_Click(object sender, EventArgs e)
        {
            PedidoNutricao pedNutri = new PedidoNutricao();
            if (txt_idCli.Text != null)
            {
                pedNutri.Cliente = ClienteRepository.Get(Convert.ToInt32(txt_idCli.Text));
                if (cbb_Fazenda.Items.Count > 0)
                {
                    pedNutri.Fazenda = FazendaRepository.GetByNome(cbb_Fazenda.SelectedItem.ToString()).First();
                    pedNutri.Pn_data = DateTime.Now;
                    pedNutri.Pn_obs = txt_obs.Text;
                    pedNutri.Pn_valortotal = Convert.ToDecimal(txt_valorTotal.Text);
                    pedNutri.Pn_previsaoentrega = dataE.Value.Date;
                    if (mask_telefone.Text.Length == 15)
                    {
                        pedNutri.Pn_contato = mask_telefone.Text.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");
                        if (mask_porcentagem.Text != null)
                        {
                            pedNutri.Pn_porcentagem = Convert.ToInt32(mask_porcentagem.Text);
                            pedNutri.Pn_formapgto = Convert.ToInt32(cbb_FormaPgto.SelectedItem.ToString());

                            if (txt_codPedido.Text != null)
                            {
                                PedidoNutricaoRepository.DeletaProdutosPedido(Convert.ToInt32(txt_codPedido.Text));
                                pedNutri.Pn_cod = Convert.ToInt32(txt_codPedido.Text);
                            }

                            PedidoNutricaoRepository.GravarPedido(pedNutri);

                            foreach (var item in prodPedNutriList)
                            {
                                item.PedidoNutricao = pedNutri;
                                PedidoNutricaoRepository.GravarProdutoPedido(item);
                            }
                            MessageBox.Show("Gravado com Sucesso!");
                            LimparTudo();
                        }
                    }
                }
            }
        }

        private void mask_telefone_Click(object sender, EventArgs e)
        {
            string telefone = mask_telefone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            if (telefone.Length > 0 && telefone.Length < 2)
                mask_telefone.Select(telefone.Length + 1, 0);
            else
                if (telefone.Length >= 2 && telefone.Length < 7)
                mask_telefone.Select(telefone.Length + 3, 0);
            else
                if (telefone.Length >= 7)
                mask_telefone.Select(telefone.Length + 4, 0);
            else
                mask_telefone.Select(1, 0);
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            if (txt_codPedido.Text != null)
            {
                if (DialogResult.Yes == MessageBox.Show("Deseja Excluir o Pedido?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    PedidoNutricaoRepository.Excluir(Convert.ToInt32(txt_codPedido.Text));
                    MessageBox.Show("Excluido com Sucesso!");
                    LimparTudo();
                }
            }
        }

        private void btn_remover_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                prodPedNutriList.Remove(prodPedNutriList[dataGridView1.CurrentRow.Index]);

                decimal val = 0;
                foreach (var item in prodPedNutriList)
                {
                    val += item.Ppn_valorvenda;
                }
                txt_valorTotal.Text = val.ToString();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = prodPedNutriList;
                ArrumaGrid();
            }
        }

        private void mask_porcentagem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void mask_porcentagem_KeyUp(object sender, KeyEventArgs e)
        {
            if (mask_porcentagem.Text == "0" || (mask_porcentagem.Text != "" && Convert.ToInt32(mask_porcentagem.Text) > 10))
            {
                mask_porcentagem.Text = "";
            }
        }

        private void mask_porcentagem_Click(object sender, EventArgs e)
        {
            string porcentagem = mask_porcentagem.Text.Replace(" ", "").Replace("_", "");
            if (porcentagem.Length > 0)
                mask_porcentagem.Select(porcentagem.Length, 0);
            else
                mask_porcentagem.Select(0, 0);
        }
    }
}
