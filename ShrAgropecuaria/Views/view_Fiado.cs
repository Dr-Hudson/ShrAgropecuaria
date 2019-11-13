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
    public partial class view_Fiado : Form
    {
        public IFiadoRepository FiadoRepository { get; }

        public Cliente cliente;
        public view_Fiado(IFiadoRepository fiadoRepository)
        {
            InitializeComponent();
            lbInstrucao.Text = "Utilize o botão selecionar cliente para pesquisar\no cliente que está efetuando o pagamento do fiado";
            FiadoRepository = fiadoRepository;
            pnPagar.Visible = false;
        }

        private void btSelecionar_Click(object sender, EventArgs e)
        {
            var a = new PesquisaFiado(FiadoRepository);

            if (a.ShowDialog() == DialogResult.OK)
            {
                cliente = new Cliente();
                lbNome.Text = "Nome: " + a.cliente.Cli_nome;
                lbRg.Text = "CPF: " + a.cliente.Cli_rg;
                lbCpf.Text = "RG: " +  a.cliente.Cli_cpf;
                lbFiado.Text = "Valor devido de fiado: " + a.cliente.Cli_saldofiado.ToString();
                cliente.Cli_cod = a.cliente.Cli_cod;
                cliente.Cli_saldofiado = a.cliente.Cli_saldofiado;
                if(a.cliente.Cli_saldofiado > 0)
                    pnPagar.Visible = true;
                else
                {
                    MessageBox.Show("Cliente não possui fiado em aberto!");
                    pnPagar.Visible = false;
                }
            }
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            string buff = "";
            int i;
            if (txtValor.MaskCompleted)
            {
                e.Handled = true;
                return;
            }
            else
            {
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
                {
                    e.Handled = true;

                }
                else
                {
                    char[] chars = txtValor.Text.ToCharArray();

                    for (i = 0; i < chars.Length - 1; i++)
                        chars[i] = chars[i + 1];

                    chars[i] = e.KeyChar;

                    for (i = 0; i < chars.Length; i++)
                        buff += chars[i];

                    buff = buff.Replace("R$", "").Replace("-", "").Replace("_", "").Replace(".", "").Replace(",", "").Replace(" ", "");

                    txtValor.Text = buff.PadLeft(11);
                }

            }
        }

        private void btPagar_Click(object sender, EventArgs e)
        {
            if (txtValor.Text != "")
            {
                Boolean flag = false;
                string msg = "";
                string a = txtValor.Text.Replace("R$", "").Replace("-", "").Replace("_", "").Replace(".", ",").Replace(" ", "");
                decimal n = Math.Round(Convert.ToDecimal(a), 2);
                if(n > 0)
                {
                    if (n == cliente.Cli_saldofiado)
                    {
                        cliente.Cli_saldofiado = 0;
                        flag = true;
                        msg = "Divida zerada!";
                    }
                    else
                    {
                        if (n > cliente.Cli_saldofiado)
                        {
                            if (MessageBox.Show("O valor que está sendo pago é maior do que o devido pelo cliente, selecione SIM para deixar em credito ou NÃO para devolver em troco!", "Valor sendo pago maior que o devido", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                cliente.Cli_saldofiado = cliente.Cli_saldofiado - n;
                                flag = true;
                                msg = "Divida zerada e adicionado crédito!";
                            }
                            else
                            {
                                decimal troco = n - cliente.Cli_saldofiado;
                                cliente.Cli_saldofiado = 0;
                                flag = true;
                                
                                msg = "Divida zerada e devolver o troco de R$ "+troco.ToString()+"!";
                            }
                        }
                        else
                        {
                            if (MessageBox.Show("O valor que está sendo pago é menor do que o devido pelo cliente, selecione SIM para quitar apenas uma parte do que é devido ou NÃO para digitar um novo valor!", "Valor sendo pago menor que o devido", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                cliente.Cli_saldofiado = cliente.Cli_saldofiado - n;
                                msg = "Dividia parcialmente quitada, ainda é devido R$ " + cliente.Cli_saldofiado.ToString() + "!";
                                flag = true;
                            }
                        }
                    }
                    if (flag)
                    {
                        try
                        {
                            FiadoRepository.Grava(cliente);
                            MessageBox.Show(msg);
                        }
                        catch (Exception erro)
                        {
                            MessageBox.Show(erro.Message);
                        }
                    }
                    else
                        txtValor.Focus();
                }
                else
                    MessageBox.Show("Valor de pagamento não pode ser negativo");
            }
            else
                MessageBox.Show("Valor de pagamento do fiado invalido");
           
        }
    }
}
