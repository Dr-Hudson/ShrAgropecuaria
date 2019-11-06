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
    public partial class view_ProdutoNutrição : Form
    {
        public IProdutoNutricao ProdutoNutricao { get; }

        public view_ProdutoNutrição(IProdutoNutricao produtoNutricao)
        {
            InitializeComponent();
            ProdutoNutricao = produtoNutricao;
            txtID.Enabled = false;
            List<TipoProdutoNutricao> a = ProdutoNutricao.Carrega().ToList();
            foreach(var b in a)
            {
                cbTipo.Items.Add(b);
            }
        }

        private void Limpar()
        {
            txtID.Text = "";
            txtNome.Text = "";
            txtObs.Text = "";
            txtValor.Text = "";
            dtpPrevisao.Value = DateTime.Now;
            cbTipo.SelectedItem = "";
            txtNome.BackColor = Color.White;
            txtValor.BackColor = Color.White;
            cbTipo.BackColor = Color.White;
        }

        private void BtLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void BtGravar_Click(object sender, EventArgs e)
        {
            decimal n;
            lbR.Text = "";
            txtNome.BackColor = Color.White;
            txtValor.BackColor = Color.White;
            cbTipo.BackColor = Color.White;
            if (txtNome.Text.Replace(" ", "").Length == 0)
            {
                lbR.Text = "Nome invalido!";
                txtNome.BackColor = Color.Red;
            }
            else
                if (!decimal.TryParse(txtValor.Text, out n))
                {
                    lbR.Text = "Valor invalido";
                    txtValor.BackColor = Color.Red;
                }
                else
                    if(cbTipo.SelectedItem == null)
                    {
                        lbR.Text = "Tipo não selecionado";
                        cbTipo.BackColor = Color.Red;
                    }
                    else
                    {
                        ProdutoNutricao prod = new ProdutoNutricao();
                        prod.Prodn_ativo = 'A';
                        prod.Prodn_nomeprod = txtNome.Text;
                        prod.Prodn_obs = txtObs.Text;
                        prod.Prodn_previsaoentrega = dtpPrevisao.Value;
                        prod.Prod_valorunitario = n;
                        prod.TipoProdutoNutricao = (TipoProdutoNutricao)cbTipo.SelectedItem;
                        if (txtID.Text.Length == 0)
                            prod.Prodn_cod = null;
                        else
                            prod.Prodn_cod = Convert.ToInt32(txtID.Text);
                        try
                        {
                            ProdutoNutricao.Gravar(prod);
                            if (txtID.Text == "")
                                MessageBox.Show("Produto cadastrado!");
                            else
                                MessageBox.Show("Produto Alterado!");
                            Limpar();
                        }
                        catch (Exception erro)
                        {
                            MessageBox.Show(erro.Message);
                        }

                    }
        }

        private void BtExcluir_Click(object sender, EventArgs e)
        {
            lbR.Text = "";
            if (txtID.Text == "")
            {
                lbR.Text = "Use o botão de pesquisa e\nselecione um Produto";
            }
            else
            {
                ProdutoNutricao prod = new ProdutoNutricao();
                prod.Prodn_cod = Convert.ToInt32(txtID.Text);
                try
                {
                    ProdutoNutricao.Excluir(prod);
                    MessageBox.Show("Excluido!");
                    Limpar();
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }
        }

        private void BtPesquisar_Click(object sender, EventArgs e)
        {
            var a = new PesquisaProdutoNutricao(ProdutoNutricao);

            if (a.ShowDialog() == DialogResult.OK)
            {

                txtID.Text = a.Produto.Prodn_cod.ToString();
                txtNome.Text = a.Produto.Prodn_nomeprod;
                txtObs.Text = a.Produto.Prodn_obs;
                txtValor.Text = a.Produto.Prod_valorunitario.ToString();
                dtpPrevisao.Value = a.Produto.Prodn_previsaoentrega;
                cbTipo.SelectedItem = a.Produto.TipoProdutoNutricao;
            }
        }
    }
}
