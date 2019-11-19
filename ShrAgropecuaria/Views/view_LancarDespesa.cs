using ShrAgropecuaria.Classes;
using ShrAgropecuaria.Repositorios.Interfaces;
using ShrAgropecuaria.Views.Pesquisas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShrAgropecuaria.Views
{
    public partial class view_LancarDespesa : Form
    {
        ContasAPagar cap = new ContasAPagar();

        Despesa desp = new Despesa();

        Usuario user = new Usuario();
        IContasAPagarRepository IContasapagar { get; }

        IDespesaRepository IDespesa { get; }

        IUsuarioRepository IUsuario { get; }

        public view_LancarDespesa(IContasAPagarRepository contasaapagar, IDespesaRepository despesa, IUsuarioRepository usuario)
        {
            

            InitializeComponent();
            IContasapagar = contasaapagar;
            IDespesa = despesa;
            IUsuario = usuario;
            txtUser.Text = Session.Instance.Nome;
            txtUser.Enabled = false;
            txtID.Enabled = false;
            btnPesquisar.Focus();
            List<Despesa> ldespesa = IDespesa.GetAll().ToList();
            foreach (var b in ldespesa)
            {
                cbbDespesa.Items.Add(b);
            }
        }

        public void Limpar() 
        {
            txtDescricao.Text = "";
            txtParcelas.Text = "";
            txtID.Text = "";
            txtValorDespesa.Text = "";
            rbAVista.Checked = false;
            rbParcelado.Checked = false;
            dtpData.Value = DateTime.Now;
            cbbDespesa.SelectedItem = null;

        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
            txtDescricao.Focus();
        }

        private void btnLancar_Click(object sender, EventArgs e)
        {
            int parcela = 1;
            if(txtDescricao.Text != "")
            {
                cap.Cap_descricao = txtDescricao.Text;
                if(txtUser.Text != "")
                {
                    user = IUsuario.getNome(txtUser.Text);
                    if(txtValorDespesa.Text != "")
                    {
                        string a = txtValorDespesa.Text.Replace("R$", "").Replace("-", "").Replace("_", "").Replace(".", ",").Replace(" ", "");
                        cap.Cap_valordespesa = Math.Round(Convert.ToDecimal(a), 2);
                        if(dtpData.Value != null)
                        {
                            cap.Cap_datageracao = dtpData.Value;
                            if(cbbDespesa.SelectedItem != null)
                            {
                                desp = IDespesa.GetNome(cbbDespesa.SelectedItem.ToString());
                                if (rbAVista.Checked)
                                    parcela = 1;
                                else if (rbParcelado.Checked)
                                    parcela = Convert.ToInt32(txtParcelas.Text);
                                cap.Despesa = desp;
                                cap.User = user;
                                if (cap != null)
                                {
                                    if(txtID.Text != "")
                                    {
                                        
                                        desp.Desp_cod = Convert.ToInt32(txtID.Text);
                                        IContasapagar.Gravar(cap, parcela);
                                        MessageBox.Show("Gravou Com Sucesso!!");
                                    }
                                    else
                                    {
                                        
                                        IContasapagar.Gravar(cap, parcela);
                                        MessageBox.Show("Gravou Com Sucesso!!");
                                    }
                                    
                                }

                            }
                        }
                    }
                }
            }
        }

        private void SomenteNumeroDPE(object sender, KeyPressEventArgs e)
        {
            string buff = "";
            int i;
            if (txtValorDespesa.MaskCompleted)
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
                    char[] chars = txtValorDespesa.Text.ToCharArray();

                    for (i = 0; i < chars.Length - 1; i++)
                        chars[i] = chars[i + 1];

                    chars[i] = e.KeyChar;

                    for (i = 0; i < chars.Length; i++)
                        buff += chars[i];

                    buff = buff.Replace("R$", "").Replace("-", "").Replace("_", "").Replace(".", "").Replace(",", "").Replace(" ", "");

                    txtValorDespesa.Text = buff.PadLeft(11);


                }

            }
        }

        private void rbAVista_CheckedChanged(object sender, EventArgs e)
        {
            txtParcelas.Enabled = false;
        }

        private void rbParcelado_CheckedChanged(object sender, EventArgs e)
        {
            txtParcelas.Enabled = true;
        }

        private void txtDescricao_Leave(object sender, EventArgs e)
        {
            if (txtDescricao.Text == "")
            {
                MessageBox.Show("O campo do descrição está em branco!!, deve-se ser preenchido para fazer a gravação!!", "Campo em branco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescricao.BackColor = Color.Red;
            }
            else
                txtDescricao.BackColor = Color.White;
        
        }

        private void txtParcelas_Leave(object sender, EventArgs e)
        {
            if (txtParcelas.Text == "")
            {
                MessageBox.Show("O campo do parcelas está em branco!!, deve-se ser preenchido para fazer a gravação!!", "Campo em branco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescricao.BackColor = Color.Red;
            }
            else if (Convert.ToInt32(txtParcelas.Text) > 10)
            {
                MessageBox.Show("O campo do parcelas passou do limite, deve ser 10 ou menos parcelas!!", "Valor excedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescricao.BackColor = Color.Red;
            }
            else
                txtDescricao.BackColor = Color.White;
        }

        private void cbbDespesa_Leave(object sender, EventArgs e)
        {
            if(cbbDespesa.SelectedItem == null)
            {
                MessageBox.Show("O campo do despesa está em branco!!, deve-se ser preenchido para fazer a gravação!!", "Campo em branco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescricao.BackColor = Color.Red;
            }
            else
                txtDescricao.BackColor = Color.Red;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            var a = new PesquisaLancarDespesa(IContasapagar);

            if (a.ShowDialog() == DialogResult.OK)
            {

                txtID.Text = a.CAP.Cap_cod.ToString();
                txtDescricao.Text = a.CAP.Cap_descricao;
                txtUser.Text = a.CAP.User.User_login;
                txtValorDespesa.Text = a.CAP.Cap_valordespesa.ToString().PadLeft(11, ' ');
                txtParcelas.Text = IContasapagar.conta(Convert.ToInt32(txtID.Text)).ToString();
                if (Convert.ToInt32(txtParcelas.Text) > 1)
                    rbParcelado.Checked = true;
                else
                    rbAVista.Checked = true;
                dtpData.Value = a.CAP.Cap_datageracao;
                cbbDespesa.Text = a.CAP.Despesa.Desp_descricao;


            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int cod;
            int.TryParse(txtID.Text, out cod);
            cap = IContasapagar.Get(cod);
            if (cap != null)
            {
                IContasapagar.Excluir(cap);
                MessageBox.Show("Excluído com sucesso!");
            }
            else
            {
                MessageBox.Show("Não foi possível Excluir esse fornecedor");
            }
            Limpar();
        }
    }
}
