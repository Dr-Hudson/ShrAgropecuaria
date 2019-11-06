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
    public partial class view_ProdutoPET : Form
    {
        ProdutoPET pp = new ProdutoPET();
        IProdutoPET ProdutoPet { get; }
        ICategoriaProdutoPET CategoriaProdutoPET { get; }

        public view_ProdutoPET(IProdutoPET produtopet, ICategoriaProdutoPET categoriaprodutopet)
        {
            InitializeComponent();
            ProdutoPet = produtopet;
            CategoriaProdutoPET = categoriaprodutopet;
        }

        public void LimparTela()
        {
            txtDescricao.Text = "";
            txtEstoque.Text = "";
            txtFabricante.Text = "";
            txtID.Text = "";
            txtValorCompra.Text = "";
            txtValorUnitario.Text = "";
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparTela();
            txtDescricao.Focus();
        }



        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text != "")
            {
                pp.Pp_descricao = txtDescricao.Text;
                if (txtEstoque.Text != "")
                {
                    pp.Pp_estoque = Convert.ToInt32(txtEstoque.Text);
                    if (txtFabricante.Text != "")
                    {
                        pp.Pp_fabricante = txtFabricante.Text;
                        if (txtValorCompra.Text != "")
                        {
                            string a = txtValorCompra.Text.Replace("R$", "").Replace("-", "").Replace("_", "").Replace(".", ",").Replace(" ", "");
                            pp.Pp_valorcompra = Math.Round(Convert.ToDecimal(a), 2);
                            if (txtValorUnitario.Text != "")
                            {
                                a = a = txtValorUnitario.Text.Replace("R$", "").Replace("-", "").Replace("_", "").Replace(".", ",").Replace(" ", "");
                                pp.Pp_valorunitario = Math.Round(Convert.ToDecimal(a), 2);
                                if (txtCategoria.Text != "")
                                {
                                    pp.Cat = (CategoriaProdutoPET)CategoriaProdutoPET.PegaId(txtCategoria.Text);
                                    if (txtAtivo.Text != "")
                                    {
                                        pp.Pp_ativo = txtAtivo.Text;
                                        if (pp != null)
                                        {
                                            if (txtID.Text != "")
                                            {
                                                pp.Pp_cod = Convert.ToInt32(txtID.Text);
                                                ProdutoPet.Gravar(pp);
                                                MessageBox.Show("Gravou com sucesso!!");
                                            }
                                            else
                                            {
                                                ProdutoPet.Gravar(pp);
                                                MessageBox.Show("Gravou com sucesso!!");
                                            }

                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Não foi possível efetuar a gravação pois o campo de situação do produto está em branco, favor, preencher!!", "Campo em branco", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        txtAtivo.Focus();
                                    }


                                }
                                else
                                {
                                    MessageBox.Show("Não foi possível efetuar a gravação pois o campo de categoria do produto está em branco, favor, preencher!!", "Campo em branco", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    btnPesquisarCategoria.Focus();
                                }


                            }
                            else
                            {
                                MessageBox.Show("Não foi possível efetuar a gravação pois o campo de valor unitário do produto está em branco, favor, preencher!!", "Campo em branco", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtValorUnitario.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível efetuar a gravação pois o campo de valor da compra está em branco, favor, preencher!!", "Campo em branco", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtValorCompra.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível efetuar a gravação pois o campo de fabricante está em branco, favor, preencher!!", "Campo em branco", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtEstoque.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possível efetuar a gravação pois o campo de estoque do produto está em branco, favor, preencher!!", "Campo em branco", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEstoque.Focus();
                }
            }
            else
            {
                MessageBox.Show("Não foi possível efetuar a gravação pois o campo de descrição do produto está em branco, favor, preencher!!", "Campo em branco", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescricao.Focus();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int cod;
            int.TryParse(txtID.Text, out cod);
            pp = ProdutoPet.Get(cod);
            if (pp != null)
            {
                ProdutoPet.Excluir(pp);
                MessageBox.Show("Excluído com sucesso!");
            }
            else
            {
                MessageBox.Show("Não foi possível Excluir esse produto");
            }
        }

        private void btnPesquisarCategoria_Click(object sender, EventArgs e)
        {
            var a = new PesquisaCategoria(CategoriaProdutoPET);
            if (a.ShowDialog() == DialogResult.OK)
            {
                txtCategoria.Text = a.cat.Cat_descricao;
            }
        }

        private void brnPesquisarProd_Click(object sender, EventArgs e)
        {
            var a = new PesquisaProdutoPET(ProdutoPet);


            string b;
            string c;
            if (a.ShowDialog() == DialogResult.OK)
            {
                txtAtivo.Text = a.pp.Pp_ativo;
                txtCategoria.Text = a.pp.Cat.Cat_descricao;
                txtDescricao.Text = a.pp.Pp_descricao;
                txtEstoque.Text = a.pp.Pp_estoque.ToString();
                txtFabricante.Text = a.pp.Pp_fabricante;
                txtID.Text = a.pp.Pp_cod.ToString();
                
                txtValorCompra.Text = a.pp.Pp_valorcompra.ToString().PadLeft(11,' ');
                txtValorUnitario.Text = a.pp.Pp_valorunitario.ToString().PadLeft(11, ' ');
            }
        }

        

        private void EventoSairDescricaoProd(object sender, EventArgs e)
        {
            if (txtDescricao.Text == "")
            {
                MessageBox.Show("O campo de descrição do produto está em branco!!, deve-se ser preenchido para fazer sua gravação!!", "Campo em branco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescricao.BackColor = Color.Red;
            }
            else
                txtDescricao.BackColor = Color.White;

        }

        private void SomenteNumero(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void SomenteLetra(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {

                e.Handled = true;

            }
        }

        private void EventoSairFabricante(object sender, EventArgs e)
        {
            if (txtFabricante.Text == "")
            {
                MessageBox.Show("O campo de Fabricante está em branco!!, deve-se ser preenchido para fazer a gravação!!", "Campo em branco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFabricante.BackColor = Color.Red;
            }
            else
                txtFabricante.BackColor = Color.White;
        }

        private void EventoSairSit(object sender, EventArgs e)
        {
            if (txtAtivo.Text == "")
            {
                MessageBox.Show("O campo de situação está em branco!!, deve-se ser preenchido para fazer a gravação!!", "Campo em branco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAtivo.BackColor = Color.Red;
            }
            else
                txtAtivo.BackColor = Color.White;
        }

        private void EventoSairCat(object sender, EventArgs e)
        {
            if (txtCategoria.Text == "")
            {
                MessageBox.Show("O campo de categoria está em branco!!, deve-se ser preenchido para fazer a gravação!!", "Campo em branco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCategoria.BackColor = Color.Red;
            }
            else
                txtCategoria.BackColor = Color.White;
        }

        private void EventoSairEstoque(object sender, EventArgs e)
        {
            if (txtEstoque.Text == "")
            {
                MessageBox.Show("O campo do estoque está em branco!!, deve-se ser preenchido para fazer a gravação!!", "Campo em branco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEstoque.BackColor = Color.Red;
            }
            else
                txtEstoque.BackColor = Color.White;
        }

        private void EventoSairVU(object sender, EventArgs e)
        {
            if (txtValorCompra.Text.Replace("R$", "").Replace("-", "").Replace("_", "").Replace(".", "").Replace(",", "").Replace(" ", "") == "")
            {
                MessageBox.Show("O campo do valor unitário está em branco!!, deve-se ser preenchido para fazer a gravação!!", "Campo em branco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtValorUnitario.BackColor = Color.Red;
            }
            else
                txtValorUnitario.BackColor = Color.White;
        }

        private void EventoSairVC(object sender, EventArgs e)
        {
            if (txtValorCompra.Text.Replace("R$", "").Replace("-", "").Replace("_", "").Replace(".", "").Replace(",", "").Replace(" ", "") == "")
            {
                MessageBox.Show("O campo do valor da compra está em branco!!, deve-se ser preenchido para fazer a gravação!!", "Campo em branco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtValorCompra.BackColor = Color.Red;
            }
            else
                txtValorCompra.BackColor = Color.White;
        }

        private void txtValorCompra_Click(object sender, EventArgs e)
        {
            txtValorCompra.Select(3, 0);
        }

        private void txtValorUnitario_Click(object sender, EventArgs e)
        {
            txtValorUnitario.Select(3, 0);
        }

        private void txtValorCompra_Enter(object sender, EventArgs e)
        {
            txtValorCompra.Select(3, 0);
        }

        private void txtValorUnitario_Enter(object sender, EventArgs e)
        {
            txtValorUnitario.Select(3, 0);
        }
    }
}
