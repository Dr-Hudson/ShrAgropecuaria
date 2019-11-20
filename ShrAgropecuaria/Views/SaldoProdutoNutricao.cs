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
    public partial class SaldoProdutoNutricao : Form
    {
        public ISaldoProdutoNutricao SaldoProdutoNutricaoRepository { get; }
        public SaldoClientePedidoLoja SaldoClientePedidoLoja;
        public SaldoProdutoNutricao()
        {
            InitializeComponent();
            lbInstrucao.Text = "Utilize o botão selecionar cliente para pesquisar\no cliente que está retirando o saldo de produto nutrição.";

        }

        private void btSelecionar_Click(object sender, EventArgs e)
        {
            var a = new PesquisaSaldoClienteLoja(SaldoProdutoNutricaoRepository);

            if (a.ShowDialog() == DialogResult.OK)
            {
                SaldoClientePedidoLoja = new SaldoClientePedidoLoja();
                lbNome.Text = "Produto: " + a.SaldoProduto.ProdutoNutricao.Prodn_nomeprod;
                lbRg.Text = "saldo: " + a.SaldoProduto.Scpl_saldo;
                SaldoClientePedidoLoja.Scpl_saldo = a.SaldoProduto.Scpl_saldo;
                SaldoClientePedidoLoja.Scpl_cod = a.SaldoProduto.Scpl_cod;
                if (a.SaldoProduto.Scpl_saldo > 0)
                    pnPagar.Visible = true;
                else
                {
                    MessageBox.Show("Cliente não possui saldo na loja!");
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
            if (txtValor.Text.Replace("R$", "").Replace("-", "").Replace("_", "").Replace(".", ",").Replace(" ", "").Replace(",", "").Length > 0)
            {
                Boolean flag = false;
                string msg = "";
                string a = txtValor.Text.Replace("R$", "").Replace("-", "").Replace("_", "").Replace(".", ",").Replace(" ", "");
                int n = Convert.ToInt32(a);
                if (n > 0)
                {
                    if (n == SaldoClientePedidoLoja.Scpl_saldo)
                    {
                        SaldoClientePedidoLoja.Scpl_saldo = 0;
                        flag = true;
                        msg = "Saldo em loja zerado!";
                    }
                    else
                    {
                        if (n > SaldoClientePedidoLoja.Scpl_saldo)
                        {
                            if (MessageBox.Show("O valor que está sendo retirado é maior do que o saldo do cliente, selecione SIM para retirar todo o saldo disponivel ou NÃO para inserir um novo valor!", "Valor sendo retirado maior que o em saldo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                SaldoClientePedidoLoja.Scpl_saldo = 0;
                                flag = true;
                                msg = "Saldo em loja zerado!";
                            }
                        }
                        else
                        {

                            SaldoClientePedidoLoja.Scpl_saldo = SaldoClientePedidoLoja.Scpl_saldo - n;
                            msg = "Produto retirado, o cliente ainda possui " + SaldoClientePedidoLoja.Scpl_saldo.ToString() + "!";
                            flag = true;
                            
                        }
                    }
                    if (flag)
                    {
                        try
                        {
                            SaldoProdutoNutricaoRepository.Grava(SaldoClientePedidoLoja);
                            MessageBox.Show(msg);
                            txtValor.Text = "";
                            pnPagar.Visible = false;
                            lbCpf.Text = "";
                            lbRg.Text = "";
                            lbNome.Text = "";
                            lbFiado.Text = "";
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
                    MessageBox.Show("Valor de retirada não pode ser negativo");
            }
            else
                MessageBox.Show("Valor de retirada invalido");
        }
    }
}
