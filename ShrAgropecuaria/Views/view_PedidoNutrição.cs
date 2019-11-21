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

            txt_valorTotal.Text = "0";
        }

        private void btn_pesqPedido_Click(object sender, EventArgs e)
        {
            var a = new PesquisaPedidoNutrição(PedidoNutricaoRepository);
            if (a.ShowDialog() == DialogResult.OK)
            {
                txt_codPedido.Text = a.pedNutri.Pn_cod.ToString();

                txt_idCli.Text = a.pedNutri.Cliente.Cli_cod.ToString();
                txt_nomeCliente.Text = a.pedNutri.ClienteNome;
                txt_idFazenda.Text = a.pedNutri.Fazenda.Faz_cod.ToString();
                txt_nomeFazenda.Text = a.pedNutri.FazendaNome;

                List<ProdutoPedidoNutricao> pedNutriList = PedidoNutricaoRepository.GetByProduto(txt_idCli.Text).ToList();
                dataGridView1.DataSource = pedNutriList;
            }
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
                }
            }
            else
                MessageBox.Show("Selecione um Cliente");
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
                    prodPedNutri.Quantidade = b.quant;
                    prodPedNutri.Peso = b.quant * 20;
                    prodPedNutri.Valorvenda = b.quant * a.Produto.Prod_valorunitario;

                    txt_valorTotal.Text = (Convert.ToDecimal(txt_valorTotal.Text) + prodPedNutri.Valorvenda).ToString();

                    prodPedNutriList.Add(prodPedNutri);

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = prodPedNutriList;
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
            txt_idFazenda.Text = "";
            txt_nomeCliente.Text = "";
            txt_nomeFazenda.Text = "";
            txt_obs.Text = "";
            txt_valorTotal.Text = "0";
            txt_porcentagem.Text = "";
            dataE.Value = DateTime.Now;
            mask_telefone.Text = "";

            btn_pesqFazenda.Enabled = false;
        }

        private void btn_gravar_Click(object sender, EventArgs e)
        {
            PedidoNutricao pedNutri = new PedidoNutricao();
            if (txt_idCli.Text != null)
            {
                //pedNutri.Cliente.Cli_cod = Convert.ToInt32(txt_idCli.Text);
                pedNutri.Cliente = ClienteRepository.Get(Convert.ToInt32(txt_idCli.Text));
                if (txt_idFazenda.Text != null)
                {
                    //pedNutri.Fazenda.Faz_cod = Convert.ToInt32(txt_idFazenda.Text);
                    pedNutri.Fazenda = FazendaRepository.Get(Convert.ToInt32(txt_idFazenda.Text));
                    pedNutri.Pn_data = DateTime.Now;
                    pedNutri.Pn_obs = txt_obs.Text;
                    pedNutri.Pn_valortotal = Convert.ToDecimal(txt_valorTotal.Text);
                    pedNutri.Pn_previsaoentrega = dataE.Value.Date;
                    if (mask_telefone.Text.Length == 15)
                    {
                        pedNutri.Pn_contato = mask_telefone.Text.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");
                        if (txt_porcentagem.Text != null)
                        {
                            pedNutri.Pn_porcentagem = Convert.ToInt32(txt_porcentagem.Text); 
                            PedidoNutricaoRepository.GravarPedido(pedNutri);

                            foreach (var item in prodPedNutriList)
                            {
                                item.PedidoNutricao = pedNutri;
                                PedidoNutricaoRepository.GravarProdutoPedido(item);
                            }
                            MessageBox.Show("Gravado com Sucesso");
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            if (txt_codPedido.Text != null)
            {
                if (DialogResult.Yes == MessageBox.Show("Deseja Excluir o Pedido?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    PedidoNutricaoRepository.Excluir(Convert.ToInt32(txt_codPedido.Text));
                }
            }
        }

        private void btn_remover_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                prodPedNutriList.Remove(prodPedNutriList[dataGridView1.CurrentRow.Index]);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = prodPedNutriList;
            }
        }
    }
}
