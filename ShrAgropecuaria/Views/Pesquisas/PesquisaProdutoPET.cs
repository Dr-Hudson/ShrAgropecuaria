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
    public partial class PesquisaProdutoPET : Form
    {
        public ProdutoPET pp = new ProdutoPET();

        IProdutoPETRepository ProdutoPET { get; }
        public PesquisaProdutoPET(IProdutoPETRepository produtopet)
        {
            InitializeComponent();
            ProdutoPET = produtopet;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSelecionarCid_Click(object sender, EventArgs e)
        {
            try
            {
                pp = DgvPP.CurrentRow?.DataBoundItem as ProdutoPET;
                if (DgvPP.CurrentRow != null)
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

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            if (txt_id.Text == "" && txt_nome.Text == "" && txtCategoria.Text == "")
            {
                List<ProdutoPET> pp = ProdutoPET.GetAll().ToList();

                
                DgvPP.DataSource = pp;
                DgvPP.Columns.Remove("Pp_cod");
                
                DgvPP.Columns["Pp_fabricante"].HeaderText = "Nome do fabricante";
                DgvPP.Columns["Pp_valorcompra"].HeaderText = "Valor da compra do produto";
                DgvPP.Columns["Pp_estoque"].HeaderText = "Estoque";
                DgvPP.Columns["Pp_descricao"].HeaderText = "Descrição do produto";
                DgvPP.Columns["Pp_valorunitario"].HeaderText = "Valor Unitário";
                DgvPP.Columns["CategoriaProdutoDescricao"].HeaderText = "Categoria";
                DgvPP.Columns.Remove("CategoriaProdutoPETId");
                DgvPP.Columns.Remove("Pp_Ativo");


            }
            else if (txt_id.Text != "" && txt_nome.Text == "" && txtCategoria.Text=="")
            {
                pp = ProdutoPET.Get(Convert.ToInt32(txt_id.Text));
                DgvPP.DataSource = pp;
            }
            else if (txt_id.Text == "" && txt_nome.Text != "" && txtCategoria.Text == "")
            {
                List<ProdutoPET> pp = ProdutoPET.GetByNome(txt_nome.Text).ToList();
                DgvPP.DataSource = pp;
            }
            else if(txt_id.Text == "" && txt_nome.Text == "" && txtCategoria.Text!="")
            {
                List<ProdutoPET> pp = ProdutoPET.GetByCat(txt_nome.Text).ToList();
                DgvPP.DataSource = pp;
            }

        }
    }
}
