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
    public partial class view_Parametrização : Form
    {
        public IParametrizacaoRepository ParametrizacaoRepository { get; }
        public ICidadeRepository CidadeRepository { get; }

        public Boolean flag { get; } 
        public view_Parametrização(IParametrizacaoRepository parametrizacaoRepository, ICidadeRepository cidadeRepository)
        {
            InitializeComponent();
            ParametrizacaoRepository = parametrizacaoRepository;
            CidadeRepository = cidadeRepository;

            Parametrizacao p = parametrizacaoRepository.Get();
            flag = true;
            if(p != null)
            {
                txtLogo.Text = p.Par_logo;
                txtNome.Text = p.Par_nomeemp;
                mask_cnpj.Text = p.Par_cnpj;
                txt_endereco.Text = p.Par_endereco;
                txt_bairro.Text = p.Par_bairro;
                mask_cep.Text = p.Par_cep;
                mask_numero.Text = p.Par_numero.ToString();
                txt_complemento.Text = p.Par_complemento;
                txt_cidade.Text = CidadeRepository.Get(p.Cid_cod).Cid_nome;
                flag = false;
            }

        }

        private void BtAlterar_Click(object sender, EventArgs e)
        {
            Parametrizacao pa = new Parametrizacao();
            if (txtNome.TextLength > 0)
            {
                pa.Par_nomeemp = txtNome.Text;
                if (txtLogo.Text.Length > 0)
                {
                    pa.Par_logo = txtLogo.Text;
                    string cnpj = mask_cnpj.Text.Replace(",", "").Replace("-", "").Replace("/", "").Replace(" ", "");
                    if (cnpj.Length > 13)
                    {
                        pa.Par_cnpj = cnpj;
                        if (txt_endereco.Text.Length > 0)
                        {
                            pa.Par_endereco = txt_endereco.Text;
                            if (txt_bairro.Text.Length > 0)
                            {
                                pa.Par_bairro = txt_bairro.Text;
                                if (mask_cep.Text.Length == 9)
                                {
                                    pa.Par_cep = mask_cep.Text.Replace("-", "");
                                    if (mask_numero.Text.Length > 0)
                                    {
                                        pa.Par_numero = Convert.ToInt32(mask_numero.Text);
                                        if (txt_cidade.Text.Length > 0)
                                        {
                                            pa.Cid_cod = CidadeRepository.PegaId(txt_cidade.Text).Cid_cod;
                                            if (txt_complemento.Text.Length > 0)
                                                pa.Par_complemento = txt_complemento.Text;
                                            else
                                                pa.Par_complemento = "";

                                            ParametrizacaoRepository.Gravar(pa, flag);
                                            Close();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Selecione uma Cidade");
                                        }
                                    }
                                    else
                                    {
                                        mask_numero.Focus();
                                        MessageBox.Show("Campo Número incompleto.");
                                    }
                                }
                                else
                                {
                                    mask_cep.Focus();
                                    MessageBox.Show("Campo CEP Incorreto.");
                                }
                            }
                            else
                            {
                                txt_bairro.Focus();
                                MessageBox.Show("Campo Bairro está vazio.");
                            }
                        }
                        else
                        {
                            txt_endereco.Focus();
                            MessageBox.Show("Campo Endereço está vazio.");
                        }
                    }
                    else
                    {
                        mask_cnpj.Focus();
                        MessageBox.Show("Campo CNPJ está invalido.");
                    }  
                }
                else
                {
                    txtLogo.Focus();
                    MessageBox.Show("Link da logo não pode estar vazio");
                }  
            }
            else
            {
                MessageBox.Show("Nome não pode ser vazio");
                txtNome.Focus();
            }
        }

        private void mask_cep_Click(object sender, EventArgs e)
        {
            string cep = mask_cep.Text.Replace("-", "").Replace(" ", "");
            if (cep.Length > 0)
                mask_cep.Select(cep.Length, 0);
            else
                mask_cep.Select(0, 0);
        }

        private void mask_numero_Click(object sender, EventArgs e)
        {
            if (mask_numero.Text.Replace(" ", "").Length > 0)
                mask_numero.Select(mask_numero.Text.Length, 0);
            else
                mask_numero.Select(0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var a = new PesquisaCidade(CidadeRepository);
            if (a.ShowDialog() == DialogResult.OK)
                txt_cidade.Text = a.Cidades.Cid_nome;
        }

        private void mask_cnpj_Click(object sender, EventArgs e)
        {
            string cnpj = mask_cnpj.Text.Replace(",", "").Replace("-", "").Replace("/", "").Replace(" ", "");
            if (cnpj.Length > 0 && cnpj.Length < 2)
                mask_cnpj.Select(cnpj.Length, 0);
            else
                if (cnpj.Length >= 2 && cnpj.Length < 5)
                mask_cnpj.Select(cnpj.Length + 1, 0);
            else
                if (cnpj.Length >= 5 && cnpj.Length < 8)
                mask_cnpj.Select(cnpj.Length + 2, 0);
            else
                if (cnpj.Length >= 8 && cnpj.Length < 12)
                mask_cnpj.Select(cnpj.Length + 3, 0);
            else
                if (cnpj.Length >= 12)
                mask_cnpj.Select(cnpj.Length + 4, 0);
            else
                mask_cnpj.Select(0, 0);
        }

        public bool isCNPJ()
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma,  resto;
            string digito, tempCnpj, cnpj = mask_cnpj.Text;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "").Replace(",", "");

            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj += digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito += resto.ToString();
            return cnpj.EndsWith(digito);
        }

        private void mask_cnpj_Leave(object sender, EventArgs e)
        {
            string cnpj = mask_cnpj.Text.Replace(",", "").Replace("-", "").Replace("/", "").Replace(" ", "");
            if (cnpj.Length > 13)
            {
                if (!isCNPJ())
                {
                    mask_cnpj.Text = "";
                    mask_cnpj.Focus();
                    MessageBox.Show("CNPJ Invalido!");
                }
            }   
        }
    }
}
