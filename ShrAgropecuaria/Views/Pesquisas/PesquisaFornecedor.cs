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

            DgvForn.Columns.Remove("Forn_cod");
            DgvForn.Columns["Forn_nome"].HeaderText = "Nome do fornecedor";
            DgvForn.Columns["Forn_endereco"].HeaderText = "Endereço";
            DgvForn.Columns["Forn_bairro"].HeaderText = "Bairro";
            DgvForn.Columns["Forn_complemento"].HeaderText = "Complemento";
            DgvForn.Columns["Forn_cep"].HeaderText = "CEP";
            DgvForn.Columns["Forn_numero"].HeaderText = "Número";
            DgvForn.Columns["Forn_descricao"].HeaderText = "Descrição";
            DgvForn.Columns["Forn_cnpj"].HeaderText = "CNPJ";
            DgvForn.Columns["Forn_telefone"].HeaderText = "Telefone";
            DgvForn.Columns.Remove("Cidadeid");
            DgvForn.Columns["NomeCidade"].HeaderText = "Cidade";

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
