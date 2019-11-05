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
    public partial class PesquisaFornecedor : Form
    {
        public Fornecedor forn = new Fornecedor();

        IFornecedorRepository FornecedorRepository { get; }
        public PesquisaFornecedor(IFornecedorRepository fornecedorrepository)
        {
            InitializeComponent();
            FornecedorRepository = fornecedorrepository;
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            if (txt_id.Text == "" && txt_nome.Text == "" && txtCid.Text == "")
            {
                List<Fornecedor> forn = FornecedorRepository.GetAll("").ToList();
                DgvForn.DataSource = forn;
            }
            else if(txt_id.Text == "" && txt_nome.Text != "" && txtCid.Text == "")
            {
                List<Fornecedor> forn = FornecedorRepository.GetByNome(txt_nome.Text).ToList();
                DgvForn.DataSource = forn;
            }
            else if(txt_id.Text == "" && txt_nome.Text == "" && txtCid.Text != "")
            {
                List<Fornecedor> forn = FornecedorRepository.GetByCid(txtCid.Text).ToList();
                DgvForn.DataSource = forn;
            }
            
        }

        private void BtnSelecionarCid_Click(object sender, EventArgs e)
        {
            try
            {
                forn = DgvForn.CurrentRow?.DataBoundItem as Fornecedor;
                if (DgvForn.CurrentRow != null)
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

        private void BtnPesquisarFiltro_Click(object sender, EventArgs e)
        {

        }
    }
}
