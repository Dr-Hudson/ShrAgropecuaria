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
    public partial class PesquisaCategoria : Form
    {
        public CategoriaProdutoPET cat = new CategoriaProdutoPET();

        ICategoriaProdutoPET CategoriaProdutoPET { get; }
        public PesquisaCategoria(ICategoriaProdutoPET categoriaprodutopet)
        {
            InitializeComponent();

            CategoriaProdutoPET = categoriaprodutopet;
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            if(txt_id.Text == "" && txt_nome.Text == "")
            {
                List<CategoriaProdutoPET> cpp = CategoriaProdutoPET.GetAll().ToList();
                DgvCat.DataSource = cpp;
            }
            else if(txt_id.Text != "" && txt_nome.Text =="")
            {
                cat = CategoriaProdutoPET.Get(Convert.ToInt32(txt_id.Text));
                DgvCat.DataSource = cat;
            }
            else if(txt_id.Text == "" && txt_nome.Text != "")
            {
                List<CategoriaProdutoPET> cpp = CategoriaProdutoPET.GetByNome(txt_nome.Text).ToList();
                DgvCat.DataSource = cpp;
            }
        }

        private void BtnSelecionar_Click(object sender, EventArgs e)
        {
            try
            {
                cat = DgvCat.CurrentRow?.DataBoundItem as CategoriaProdutoPET;
                if (DgvCat.CurrentRow != null)
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

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
