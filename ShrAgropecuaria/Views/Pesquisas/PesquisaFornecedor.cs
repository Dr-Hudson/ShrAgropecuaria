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
            List<Fornecedor> forn = FornecedorRepository.GetAll("").ToList();
            DgvForn.DataSource = forn;
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
            List<Fornecedor> forn = new List<Fornecedor>();
            if (txt_id.Text != "")
                forn = FornecedorRepository.GetById(Convert.ToInt32(txt_id.Text)).ToList();
            else
                forn = FornecedorRepository.GetByNome(txt_nome.Text).ToList();
            DgvForn.DataSource = forn;
            DgvForn.DataSource = forn;
            if (forn.Count == 0)
            {
                MessageBox.Show("Nome ou ID não encontrada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
