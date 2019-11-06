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
            txtCidade.Enabled = false;
            
            
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
            txtEstado.Text = "";
        }

        


        private void btnGravar_Click(object sender, EventArgs e)
        {
            if(txtBairro.Text != "")
            {
                forn.Forn_bairro = txtBairro.Text;
                if(txtCEP.Text != "")
                {
                    
                    forn.Forn_cep = txtCEP.Text.Replace("-", "");
                    if (txtCidade.Text != "")
                    {
                        forn.Cidade = (Cidade)CidadeRepository.PegaId(txtCidade.Text);
                        if(txtCNPJ.Text != "")
                        {
                            
                            
                            forn.Forn_cnpj = txtCNPJ.Text.Replace(",", "").Replace("/", "").Replace("-", "");
                            if(txtComplemento.Text != "" || txtComplemento.Text == "")
                            {
                                if (txtComplemento.Text == "" && MessageBox.Show("O campo complemento está em branco, gostaria de preencher para continuar?", "Campo em branco", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    return;
                                }
                                else
                                {
                                    forn.Forn_complemento = txtComplemento.Text;
                                    if (txtDescricao.Text != "" || txtDescricao.Text == "")
                                    {
                                        if (txtDescricao.Text == "" && MessageBox.Show("O campo complemento está em branco, gostaria de preencher para continuar?", "Campo em branco", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        {
                                            return;
                                        }
                                        else
                                        {
                                            forn.Forn_descricao = txtDescricao.Text;
                                            if (txtEndereco.Text != "")
                                            {
                                                forn.Forn_endereco = txtEndereco.Text;
                                                if (txtNome.Text != "")
                                                {
                                                    forn.Forn_nome = txtNome.Text;
                                                    if (txtNumero.Text != "")
                                                    {
                                                        forn.Forn_numero = Convert.ToInt32(txtNumero.Text);
                                                        if (txtTelefone.Text != "")
                                                        {

                                                            forn.Forn_telefone = txtTelefone.Text.Replace(")", "").Replace("(", "").Replace("-", "");

                                                            if (forn != null)
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
                                                        else
                                                        {
                                                            MessageBox.Show("Não foi possível fazer a gravação! Deve ser informado o Telefone!!", "Campo em branco", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                            txtTelefone.Focus();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Não foi possível fazer a gravação! Deve ser informado o Número!!", "Campo em branco", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        txtNumero.Focus();
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Não foi possível fazer a gravação! Deve ser informado o Nome!!", "Campo em branco", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    txtNome.Focus();
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Não foi possível fazer a gravação! Deve ser informado o Endereço!!", "Campo em branco", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                txtEndereco.Focus();
                                            }
                                        }
                                        
                                    }
                                    
                                }
                                
                            }

                        }
                        else
                        {
                            MessageBox.Show("Não foi possível fazer a gravação! Deve ser informado o CNPJ!!", "Campo em branco", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtCNPJ.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível fazer a gravação! Deve ser informado a cidade!!", "Campo em branco", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnPesquisarCid.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possível fazer a gravação! Deve ser informado o CEP!!", "Campo em branco", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCEP.Focus();
                }
            }
            else
            {
                MessageBox.Show("Não foi possível fazer a gravação! Deve ser informado o bairro!!","Campo em branco",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtBairro.Focus();
            }
        }



        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparTela();
            txtNome.Focus();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            var a = new PesquisaFornecedor(FornecedorRepository);
            
            if(a.ShowDialog() == DialogResult.OK)
            {
                
                txtID.Text = a.forn.Forn_cod.ToString();
                txtBairro.Text = a.forn.Forn_bairro;
                txtCEP.Text = a.forn.Forn_cep;
                txtCidade.Text = a.forn.Cidade.Cid_nome;
                txtEstado.Text = a.forn.Cidade.EstadoUf;
                txtCNPJ.Text = a.forn.Forn_cnpj.ToString();
                txtComplemento.Text = a.forn.Forn_complemento;
                txtDescricao.Text = a.forn.Forn_descricao;
                txtEndereco.Text = a.forn.Forn_endereco;
                txtNome.Text = a.forn.Forn_nome;
                txtNumero.Text = a.forn.Forn_numero.ToString();
                txtTelefone.Text = a.forn.Forn_telefone;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int cod;
            int.TryParse(txtID.Text, out cod);
            forn = FornecedorRepository.Get(cod);
            if(forn != null)
            {
                FornecedorRepository.Excluir(forn);
                MessageBox.Show("Excluído com sucesso!");
            }
            else
            {
                MessageBox.Show("Não foi possível Excluir esse fornecedor");
            }
            LimparTela();
        }

        private void btnPesquisarCid_Click(object sender, EventArgs e)
        {
            var a = new PesquisaCidade(CidadeRepository);
            if(a.ShowDialog() == DialogResult.OK)
            {
                txtCidade.Text = a.Cidades.Cid_nome;
                txtEstado.Text = a.Cidades.Estado.Est_uf;
            }
        }

        private void EventoSairBairro(object sender, EventArgs e)
        {
            if (txtBairro.Text.Length < 4 || txtBairro.Text.Length > 40)
            {
                MessageBox.Show("Nome do bairro deve ter ao menos 4 caracteres e não pode ultrapassar 40 caracteres");
                txtBairro.BackColor = Color.Red;
                txtBairro.Text = "";
            }
            else
            {
                txtBairro.BackColor = Color.White;
            }
        }

        private void EventoSairNome(object sender, EventArgs e)
        {
            if (txtNome.Text.Length < 3 || txtNome.Text.Length > 40)
            {
                MessageBox.Show("O campo nome, é um campo obrigatório, nela deve conter o nome com ao menos 3 caracteres e no máximo 40!");
                
                txtNome.Text = "";
                txtNome.BackColor = Color.Red;
            }
            else
                txtNome.BackColor = Color.White;
        }

        private void BloqueioNumero(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {

                e.Handled = true;

            }
        }

        private void BloqueioLetra(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void EventoSairCPF(object sender, EventArgs e)
        {
            if (txtCEP.Text.Length != 9)
            {
                MessageBox.Show("O CEP deve ser digitado de forma correta, incluindo seus 8 digitos!");

                txtCEP.Text = "";
                txtCEP.BackColor = Color.Red;
            }
            else
                txtCEP.BackColor = Color.White;
        }

        private void EventoSairCNPJ(object sender, EventArgs e)
        {
            if (txtCNPJ.Text.Length != 18)
            {
                MessageBox.Show("O CNPJ deve ser digitado de forma correta, incluindo seus 14 digitos!");

                txtCNPJ.Text = "";
                txtCNPJ.BackColor = Color.Red;

            }
            else
                txtCNPJ.BackColor = Color.White;
        }

        private void EventoSairTelefone(object sender, EventArgs e)
        {
            if (txtTelefone.Text.Length != 14)
            {
                MessageBox.Show("O Telefone deve ser digitado de forma correta, incluindo o DDD!");

                txtTelefone.Text = "";
                txtTelefone.BackColor = Color.Red;
            }
            else
                txtTelefone.BackColor = Color.White;
        }

        private void EventoSairEndereco(object sender, EventArgs e)
        {
            if (txtEndereco.Text.Length < 3 || txtEndereco.Text.Length > 40)
            {
                MessageBox.Show("O campo Endereco, é um campo obrigatório, nela deve conter o nome com ao menos 3 caracteres e no máximo 40!");
                
                txtEndereco.Text = "";
                txtEndereco.BackColor = Color.Red;
            }
            else
                txtEndereco.BackColor = Color.White;
        }

        private void EventoSairNumero(object sender, EventArgs e)
        {
            if(txtNumero.Text.Length == 0 )
            {
                MessageBox.Show("Deve-se inserir o número!");
                txtNumero.BackColor = Color.Red;

            }
            else
            {
                txtNumero.BackColor = Color.White;
            }
        }

        private void EventoSairCidade(object sender, EventArgs e)
        {
            if (txtCidade.Text == "")
            {
                MessageBox.Show("Deve-se escolher uma cidade!!");
                txtCidade.BackColor = Color.Red;
            }
            else
                txtCidade.BackColor = Color.White;

        }

        private void LegendaNome(object sender, EventArgs e)
        {
            MessageBox.Show("Campo para inserir seu nome completo", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
