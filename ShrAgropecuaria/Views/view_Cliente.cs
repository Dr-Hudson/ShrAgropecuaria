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
    public partial class View_Cliente : Form
    {
        Cliente cli = new Cliente();
        public ICidadeRepository CidadeRepository { get; }
        public IClienteRepository ClienteRepository { get; }
        public View_Cliente(ICidadeRepository cidadeRepository, IClienteRepository clienteRepository)
        {
            InitializeComponent();
            CidadeRepository = cidadeRepository;
            ClienteRepository = clienteRepository;
        }

        private void mask_limite_Click(object sender, EventArgs e)
        {
            mask_limite.Select(0, 0);
        }

        private void mask_fiado_Click(object sender, EventArgs e)
        {
            mask_fiado.Select(3, 0);
        }

        private void mask_cep_Click(object sender, EventArgs e)
        {
            mask_cep.Select(0, 0);
        }

        private void mask_numero_Click(object sender, EventArgs e)
        {
            mask_numero.Select(0, 0);
        }

        private void mask_cpf_Click(object sender, EventArgs e)
        {
            mask_cpf.Select(0, 0);
        }

        private void mask_telefone_Click(object sender, EventArgs e)
        {
            mask_telefone.Select(0, 0);
        }

        private void btn_gravar_Click(object sender, EventArgs e)
        {
            if (VerificaCampos())
            {
                LimparCampos();
                if (txt_id.Text.Length == 0)
                {
                    txt_msg.Text = "Gravado com Sucesso!";
                }
                else
                {
                    cli.Cli_cod = Convert.ToInt32(txt_id.Text);
                    txt_msg.Text = "Editado com Sucesso!";
                }
                ClienteRepository.Gravar(cli);
            }
        }

        public void LimparCampos()
        {
            txt_id.Text = "";
            txt_msg.Text = "";
            txt_nomeCliente.Text = "";
            mask_limite.Text = "";
            mask_fiado.Text = "";
            txt_endereco.Text = "";
            txt_bairro.Text = "";
            mask_cep.Text = "";
            mask_numero.Text = "";
            txt_complemento.Text = "";
            txt_cidade.Text = "";
            txt_rg.Text = "";
            mask_cpf.Text = "";
            mask_telefone.Text = "";
        }

        public static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        public bool VerificaCampos()
        {
            txt_msg.Text = "";
            cli = new Cliente();
            if (txt_nomeCliente.Text.Length > 2)
            {
                cli.Cli_nome = txt_nomeCliente.Text;
                if (mask_limite.Text.Length > 0)
                {
                    cli.Cli_limite = Convert.ToDecimal(mask_limite.Text.Replace(" ", ""));
                    string fiado = mask_fiado.Text.Replace("R$", "").Replace(" ", "").Replace(".", "");
                    if (fiado.Length > 0)
                    {
                        cli.Cli_saldofiado = Convert.ToDecimal(fiado);
                        if (txt_endereco.Text.Length > 0)
                        {
                            cli.Cli_endereco = txt_endereco.Text;
                            if (txt_bairro.Text.Length > 0)
                            {
                                cli.Cli_bairro = txt_bairro.Text;
                                if (mask_cep.Text.Length == 9)
                                {
                                    cli.Cli_cep = mask_cep.Text.Replace("-", "");
                                    if (mask_numero.Text.Length > 0)
                                    {
                                        cli.Cli_numero = Convert.ToInt32(mask_numero.Text);
                                        if (txt_cidade.Text.Length > 0)
                                        {
                                            cli.Cidade = (Cidade)CidadeRepository.PegaId(txt_cidade.Text);
                                            if (txt_rg.Text.Length > 5)
                                            {
                                                cli.Cli_rg = txt_rg.Text;
                                                if (mask_cpf.Text.Length == 14)
                                                {
                                                    cli.Cli_cpf = mask_cpf.Text.Replace(",", "").Replace("-", "");

                                                    if (IsCpf(cli.Cli_cpf))
                                                    {
                                                        if (mask_telefone.Text.Length == 15)
                                                        {
                                                            cli.Cli_telefone = mask_telefone.Text.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");
                                                            cli.Cli_complemento = txt_complemento.Text;
                                                            cli.Cli_dataliberacao = dateTimePicker1.Value;
                                                            return true;
                                                        }
                                                        else
                                                        {
                                                            txt_msg.Text = "Telefone Incompleto!";
                                                            mask_telefone.Focus();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        txt_msg.Text = "CPF Invalido!";
                                                        mask_cpf.Focus();
                                                    }
                                                }
                                                else
                                                {
                                                    txt_msg.Text = "CPF Incompleto!";
                                                    mask_cpf.Focus();
                                                }
                                            }
                                            else
                                            {
                                                txt_msg.Text = "RG Incompleto!";
                                                txt_rg.Focus();
                                            }
                                        }
                                        else
                                        {
                                            txt_msg.Text = "Selecione uma Cidade!";
                                            //txt_nomeCliente.Focus();
                                        }
                                    }
                                    else
                                    {
                                        txt_msg.Text = "Número Incompleto!";
                                        mask_numero.Focus();
                                    }
                                }
                                else
                                {
                                    txt_msg.Text = "CEP Incompleto!";
                                    mask_cep.Focus();
                                }
                            }
                            else
                            {
                                txt_msg.Text = "Bairro Incompleto!";
                                txt_bairro.Focus();
                            }
                        }
                        else
                        {
                            txt_msg.Text = "Endereço Incompleto!";
                            txt_endereco.Focus();
                        }
                    }
                    else
                    {
                        txt_msg.Text = "Fiado Incompleto!";
                        mask_fiado.Focus();
                    }
                }
                else
                {
                    txt_msg.Text = "Limite Incompleto!";
                    mask_limite.Focus();
                }
            }
            else
            {
                txt_msg.Text = "Nome Incompleto!";
                txt_nomeCliente.Focus();
            }
            return false;
        }

        private void btn_pesqCidade_Click(object sender, EventArgs e)
        {
            var a = new PesquisaCidade(CidadeRepository);
            if (a.ShowDialog() == DialogResult.OK)
                txt_cidade.Text = a.Cidades.Cid_nome;
        }

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btn_pesqCliente_Click(object sender, EventArgs e)
        {
            var a = new PesquisaCliente(ClienteRepository);
            if (a.ShowDialog() == DialogResult.OK)
            {
                txt_id.Text = a.cli.Cli_cod.ToString();
                txt_nomeCliente.Text = a.cli.Cli_nome;
                dateTimePicker1.Value = a.cli.Cli_dataliberacao;
                mask_limite.Text = a.cli.Cli_limite.ToString().PadLeft(11, ' ');
                mask_fiado.Text = a.cli.Cli_saldofiado.ToString().PadLeft(11, ' ');
                txt_endereco.Text = a.cli.Cli_endereco;
                txt_bairro.Text = a.cli.Cli_bairro;
                mask_cep.Text = a.cli.Cli_cep;
                mask_numero.Text = a.cli.Cli_numero.ToString();
                txt_complemento.Text = a.cli.Cli_complemento;
                txt_cidade.Text = a.cli.Cidade.Cid_nome;
                txt_rg.Text = a.cli.Cli_rg;
                mask_cpf.Text = a.cli.Cli_cpf;
                mask_telefone.Text = a.cli.Cli_telefone;


            }

        }

        private void mask_fiado_Enter(object sender, EventArgs e)
        {

        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            int cod;
            int.TryParse(txt_id.Text, out cod);
            cli = ClienteRepository.Get(cod);
            if (cli != null)
            {
                ClienteRepository.Excluir(cli);
                MessageBox.Show("Excluído com sucesso!");
            }
            else
            {
                MessageBox.Show("Não foi possível Excluir o Cliente");
            }
            LimparCampos();
        }
    }
}
