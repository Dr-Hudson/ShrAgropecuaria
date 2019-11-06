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
            if(txtDescricao.Text != "")
            {
                pp.Pp_descricao = txtDescricao.Text;
                if(txtEstoque.Text != "")
                {
                    pp.Pp_estoque = Convert.ToInt32(txtEstoque.Text);
                    if(txtFabricante.Text != "")
                    {
                        pp.Pp_fabricante = txtFabricante.Text;
                        if(txtValorCompra.Text != "")
                        {
                            string a = txtValorCompra.Text.Replace("R$", "").Replace("-", "").Replace("_", "").Replace(".",",");
                            pp.Pp_valorcompra = Math.Round(Convert.ToDecimal(a),2);
                            if(txtValorUnitario.Text != "")
                            {
                                a = a = txtValorUnitario.Text.Replace("R$", "").Replace("-", "").Replace("_", "").Replace(".", ",");
                                pp.Pp_valorunitario = Math.Round(Convert.ToDecimal(a),2);
                                if(txtCategoria.Text!="")
                                {
                                    pp.Cat = (CategoriaProdutoPET)CategoriaProdutoPET.PegaId(txtCategoria.Text);
                                    if(txtAtivo.Text!="")
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
                                    

                                }

                               
                            }
                        }
                    }
                }
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
            if(a.ShowDialog() == DialogResult.OK)
            {
                txtCategoria.Text = a.cat.Cat_descricao;
            }
        }

        private void brnPesquisarProd_Click(object sender, EventArgs e)
        {
            var a = new PesquisaProdutoPET(ProdutoPet);
            if (a.ShowDialog() == DialogResult.OK)
            {
                txtAtivo.Text = a.pp.Pp_ativo;
                txtCategoria.Text = a.pp.Cat.Cat_descricao;
                txtDescricao.Text = a.pp.Pp_descricao;
                txtEstoque.Text = a.pp.Pp_estoque.ToString();
                txtFabricante.Text = a.pp.Pp_fabricante;
                txtID.Text = a.pp.Pp_cod.ToString();
                txtValorCompra.Text = a.pp.Pp_valorcompra.ToString();
                txtValorUnitario.Text = a.pp.Pp_valorunitario.ToString();
            }
        }

        private void DireitaParaEsquerda(object sender, KeyPressEventArgs e)
        {
            
        }
    }
    
}
