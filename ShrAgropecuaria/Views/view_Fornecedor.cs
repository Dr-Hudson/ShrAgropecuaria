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
    public partial class view_Fornecedor : Form
    {
        Fornecedor forn = new Fornecedor();

        public ICidadeRepository CidadeRepository { get; }
        public IFornecedorRepository FornecedorRepository { get; }


        public view_Fornecedor(ICidadeRepository cidadeRepository, IFornecedorRepository fornecedorRepository)
        {
            InitializeComponent();
            CidadeRepository = cidadeRepository;
            FornecedorRepository = fornecedorRepository;
            txtID.Enabled = false;
            txtEstado.Enabled = false;
        }
        
        void LimparTela()
        {
            txtBairro.Text = "";
            txtCEP.Text = "";
            txtCNPJ.Text = "";
            txtComplemento.Text = "";
            txtDescricao.Text = "";
            txtEndereco.Text = "";
            txtID.Text = "";
            txtNome.Text = "";
            txtNumero.Text = "";
            txtTelefone.Text = "";
            txtCidade.Text = "";
        }

        


        private void btnGravar_Click(object sender, EventArgs e)
        {
            if(txtBairro.Text != "")
            {
                forn.Forn_bairro = txtBairro.Text;
                if(txtCEP.Text != "")
                {
                    forn.Forn_cep = txtCEP.Text;
                    if(txtCidade.Text != "")
                    {
                        forn.Cidade = (Cidade)CidadeRepository.PegaId(txtCidade.Text);
                        if(txtCNPJ.Text != "")
                        {
                            forn.Forn_cnpj = txtCNPJ.Text;
                            if(txtComplemento.Text != "")
                            {
                                forn.Forn_complemento = txtComplemento.Text;
                                if(txtDescricao.Text != "")
                                {
                                    forn.Forn_descricao = txtDescricao.Text;
                                    if(txtEndereco.Text != "")
                                    {
                                        forn.Forn_endereco = txtEndereco.Text;
                                        if(txtNome.Text != "")
                                        {
                                            forn.Forn_nome = txtNome.Text;
                                            if(txtNumero.Text != "")
                                            {
                                                forn.Forn_numero = Convert.ToInt32(txtNumero.Text);
                                                if(txtTelefone.Text != "")
                                                {
                                                    forn.Forn_telefone = txtTelefone.Text;
                                                    
                                                    if(forn != null)
                                                    {
                                                        if (txtID.Text != "")
                                                        {
                                                            forn.Forn_cod = Convert.ToInt32(txtID.Text);
                                                            FornecedorRepository.Gravar(forn);
                                                        }
                                                        else
                                                            FornecedorRepository.Gravar(forn);

                                                        MessageBox.Show("Gravou!");
                                                        LimparTela();
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
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparTela();
            txtNome.Focus();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int cod;
            int.TryParse(txtID.Text, out cod);
            //forn = FornecedorRepository.Get(cod);
            if(forn != null)
            {
                //FornecedorRepository.Excluir(forn);
            }
            else
            {
                MessageBox.Show("Não foi possível Excluir esse fornecedor");
            }
        }

        private void btnPesquisarCid_Click(object sender, EventArgs e)
        {

        }
    }
}
