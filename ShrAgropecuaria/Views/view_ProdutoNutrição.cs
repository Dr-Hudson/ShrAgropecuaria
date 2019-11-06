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
            cbTipo.DataSource = ProdutoNutricao.Carrega();
        }

        private void Limpar()
        {
            txtID.Text = "";
            txtNome.Text = "";
            txtObs.Text = "";
            txtValor.Text = "";
            dtpPrevisao.Value = DateTime.Now;
            cbTipo.SelectedItem = "";
        }

        private void BtLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void BtGravar_Click(object sender, EventArgs e)
        {
            lbR.Text = "";
            if (txtNome.Text.Replace(" ", "").Length < 5)
            {
                lbR.Text = "Nome precisa ter mais de\n5 caracteres!";
            }
            else
                if (txtValor.Text.Length == 0)
                {
                    lbR.Text = "Valor não definido";
              
                }
                else
                    if(cbTipo.SelectedItem == null)
                    {
                        lbR.Text = "Tipo não selecionado";
                    }
                    else
                    {
                        ProdutoNutricao prod = new ProdutoNutricao();
                        prod.Prodn_ativo = 'A';
                        prod.Prodn_nomeprod = txtNome.Text;
                        prod.Prodn_obs = txtObs.Text;
                        prod.Prodn_previsaoentrega = dtpPrevisao.Value;
                        prod.Prodn_valorunitario = Convert.ToInt32(txtValor.Text);
                        prod.TipoProdutoNutricao = (TipoProdutoNutricao)cbTipo.SelectedItem;
                        if (txtID.Text.Length == 0)
                            prod.Prodn_cod = null;
                        else
                            prod.Prodn_cod = Convert.ToInt32(txtID.Text);
                        try
                        {
                            ProdutoNutricao.Gravar(prod);
                            if (txtID.Text == "")
                                MessageBox.Show("Usuario cadastrado!");
                            else
                                MessageBox.Show("Usuario Alterado!");
                            Limpar();
                        }
                        catch (Exception erro)
                        {
                            MessageBox.Show(erro.Message);
                        }

                    }
        }
    }
}
