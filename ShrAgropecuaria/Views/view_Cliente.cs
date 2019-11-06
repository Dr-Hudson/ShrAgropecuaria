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
                ClienteRepository.Gravar(cli);

        }

        public bool VerificaCampos()
        {
            txt_msg.Text = "";
            cli = null;
            if (txt_nomeCliente.Text.Length > 2)
            {
                cli.Cli_nome = txt_nomeCliente.Text;
                if (mask_limite.Text.Length > 0)
                {
                    cli.Cli_limite = Convert.ToDecimal(mask_limite.Text);
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
                                    cli.Cli_cep = mask_cep.Text;
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
                                                    cli.Cli_cpf = mask_cpf.Text;
                                                    if (mask_telefone.Text.Length == 15)
                                                    {
                                                        cli.Cli_telefone = mask_telefone.Text;
                                                        cli.Cli_complemento = txt_complemento.Text;
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
    }
}
