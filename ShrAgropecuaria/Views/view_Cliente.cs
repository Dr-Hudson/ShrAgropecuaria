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

        private void Mask_limite_Click(object sender, EventArgs e)
        {
            mask_limite.Select(14, 0);
        }

        private void Mask_fiado_Click(object sender, EventArgs e)
        {
            mask_fiado.Select(14, 0);
        }

        private void Mask_cep_Click(object sender, EventArgs e)
        {
            string cep = mask_cep.Text.Replace("-", "").Replace(" ", "");
            if (cep.Length > 0)
                mask_cep.Select(cep.Length, 0);
            else
                mask_cep.Select(0, 0);
        }

        private void Mask_numero_Click(object sender, EventArgs e)
        {
            if (mask_numero.Text.Replace(" ", "").Length > 0)
                mask_numero.Select(mask_numero.Text.Length, 0);
            else
                mask_numero.Select(0, 0);
        }

        private void Mask_cpf_Click(object sender, EventArgs e)
        {
            string cpf = mask_cpf.Text.Replace(",", "").Replace("-", "").Replace(" ", "");
            if (cpf.Length > 0 && cpf.Length < 3)
                mask_cpf.Select(cpf.Length, 0);
            else
                if (cpf.Length >= 3 && cpf.Length < 6)
                mask_cpf.Select(cpf.Length + 1, 0);
            else
                if (cpf.Length >= 6 && cpf.Length < 9)
                mask_cpf.Select(cpf.Length + 2, 0);
            else
                if (cpf.Length >= 9)
                mask_cpf.Select(cpf.Length + 3, 0);
            else
                mask_cpf.Select(0, 0);
        }

        private void Mask_telefone_Click(object sender, EventArgs e)
        {
            string telefone = mask_telefone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            if (telefone.Length > 0 && telefone.Length < 2)
                mask_telefone.Select(telefone.Length + 1, 0);
            else
                if (telefone.Length >= 2 && telefone.Length < 7)
                mask_telefone.Select(telefone.Length + 3, 0);
            else
                if (telefone.Length >= 7)
                mask_telefone.Select(telefone.Length + 4, 0);
            else
                mask_telefone.Select(1, 0);
        }

        private void Btn_gravar_Click(object sender, EventArgs e)
        {
            if (VerificaCampos())
            {
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
                LimparCampos();
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

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf += digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto.ToString();

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
                    cli.Cli_limite = Convert.ToDecimal(mask_limite.Text.Replace("_", "").Replace("R$", "").Replace(".", ","));
                    string fiado = mask_fiado.Text.Replace("R$", "").Replace(" ", "").Replace(".", ",");
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

        private void Btn_pesqCidade_Click(object sender, EventArgs e)
        {
            var a = new PesquisaCidade(CidadeRepository);
            if (a.ShowDialog() == DialogResult.OK)
                txt_cidade.Text = a.Cidades.Cid_nome;
        }

        private void Btn_limpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void Btn_pesqCliente_Click(object sender, EventArgs e)
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

        private void Btn_excluir_Click(object sender, EventArgs e)
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

        private void Mask_fiado_KeyPress(object sender, KeyPressEventArgs e)
        {
            string buff = "";
            int i;
            if (mask_fiado.MaskCompleted)
            {
                e.Handled = true;
                return;
            }
            else
            {
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
                    e.Handled = true;
                else
                {
                    char[] chars = mask_fiado.Text.ToCharArray();

                    for (i = 0; i < chars.Length - 1; i++)
                        chars[i] = chars[i + 1];

                    chars[i] = e.KeyChar;

                    for (i = 0; i < chars.Length; i++)
                        buff += chars[i];

                    buff = buff.Replace("R$", "").Replace("-", "").Replace("_", "").Replace(".", "").Replace(",", "").Replace(" ", "");

                    mask_fiado.Text = buff.PadLeft(11);
                }
            }
        }

        private void Mask_limite_KeyPress(object sender, KeyPressEventArgs e)
        {
            string buff = "";
            int i;
            if (mask_limite.MaskCompleted)
            {
                e.Handled = true;
                return;
            }
            else
            {
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
                    e.Handled = true;
                else
                {
                    char[] chars = mask_limite.Text.ToCharArray();

                    for (i = 0; i < chars.Length - 1; i++)
                        chars[i] = chars[i + 1];

                    chars[i] = e.KeyChar;

                    for (i = 0; i < chars.Length; i++)
                        buff += chars[i];

                    buff = buff.Replace("R$", "").Replace("-", "").Replace("_", "").Replace(".", "").Replace(",", "").Replace(" ", "");

                    mask_limite.Text = buff.PadLeft(11);
                }
            }
        }
    }
}
