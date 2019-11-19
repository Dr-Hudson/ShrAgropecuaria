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
            btnEnviar.Enabled = false;
            List<Despesa> ldespesa = IDespesa.GetAll().ToList();
            foreach (var b in ldespesa)
            {
                cbbDespesa.Items.Add(b);
            }
        }

        public void CamposPreenchido()
        {
            if (txtDescricao.Text != "")
                if (txtParcelas.Text != "")
                    if (rbAVista.Checked || rbParcelado.Checked)
                        if (cbbDespesa.Text != "")
                            if (txtValorDespesa.Text.Replace("R$", "").Replace("-", "").Replace("_", "").Replace(".", "").Replace(" ", "").Replace(",", "") != "")
                                btnEnviar.Enabled = true;
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

        public bool ValidaPreco(List<ContasAPagar> lcap)
        {
            
            string a = txtValorDespesa.Text.Replace("R$", "").Replace("-", "").Replace("_", "").Replace(".", ",").Replace(" ", "");
            decimal b = Math.Round(Convert.ToDecimal(a), 2);
            decimal d=0;
            foreach (var c in lcap)
                d += c.Cap_valordespesa;

            if (d == b)
                return true;
            else if(d < b)
            {
                MessageBox.Show("O valor alterado na grid é menor que o valor total da despesa, favor, arrumar os preços!!");
                return false;
            }
            else
                MessageBox.Show("O valor alterado na grid é maior que o valor total da despesa, favor, arrumar os preços!!");
            return false;
            
        }

        private void btnLancar_Click(object sender, EventArgs e)
        {

            List<ContasAPagar> lcap = (List<ContasAPagar>)DgvDespesa.DataSource;
            if(ValidaPreco(lcap))
            {
                IContasapagar.Gravar(lcap);
                MessageBox.Show("Gravado com sucesso!!");
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
            txtParcelas.Text = "1";
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
            {
                txtDescricao.BackColor = Color.White;
                CamposPreenchido();

            }


        }

        private void txtParcelas_Leave(object sender, EventArgs e)
        {
            if (txtParcelas.Text == "")
            {
                MessageBox.Show("O campo do parcelas está em branco!!, deve-se ser preenchido para fazer a gravação!!", "Campo em branco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtParcelas.BackColor = Color.Red;
            }
            else if (Convert.ToInt32(txtParcelas.Text) > 10)
            {
                MessageBox.Show("O campo do parcelas passou do limite, deve ser 10 ou menos parcelas!!", "Valor excedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtParcelas.BackColor = Color.Red;
            }
            else
            {
                txtDescricao.BackColor = Color.White;
                CamposPreenchido();
            }
               
        }

        private void cbbDespesa_Leave(object sender, EventArgs e)
        {
            if(cbbDespesa.SelectedItem == null)
            {
                
                
                    MessageBox.Show("O campo do despesa está em branco!!, deve-se ser preenchido para fazer a gravação!!", "Campo em branco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbbDespesa.BackColor = Color.Red;
                
                
            }
            else
            {
                cbbDespesa.BackColor = Color.White;
                CamposPreenchido();
            }
                
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
            List<ContasAPagar> lcap = (List<ContasAPagar>)DgvDespesa.DataSource;
            IContasapagar.Excluir(lcap);
            Limpar();
        }

        private void dtpData_Leave(object sender, EventArgs e)
        {
            
            CamposPreenchido();
        }

        private void rbAVista_Leave(object sender, EventArgs e)
        {
            
            CamposPreenchido();
        }

        private void rbParcelado_Leave(object sender, EventArgs e)
        {
            
            CamposPreenchido();
        }

        private void txtValorDespesa_Leave(object sender, EventArgs e)
        {
            
            CamposPreenchido();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            DateTime w;
            ContasAPagar capp = new ContasAPagar();
            capp.Cap_datageracao = dtpData.Value;
            user = IUsuario.getNome(txtUser.Text);
            string aux;



            desp = IDespesa.GetNome(cbbDespesa.SelectedItem.ToString());
            aux = desp.Desp_dia + "/" + capp.Cap_datageracao.Month + "/" + capp.Cap_datageracao.Year + " " + capp.Cap_datageracao.Hour + ":" + capp.Cap_datageracao.Minute + ":" + capp.Cap_datageracao.Second;
            w = Convert.ToDateTime(aux);
            //w = cap.Cap_datageracao;
            List<ContasAPagar> lcap = new List<ContasAPagar>();
            for(int i = 0; i<Convert.ToInt32(txtParcelas.Text); i++)
            {
                ContasAPagar cappp = new ContasAPagar();
                w =w.AddMonths(1);
                cappp.Cap_descricao = txtDescricao.Text;
                cappp.Cap_datageracao = dtpData.Value;

                string a = txtValorDespesa.Text.Replace("R$", "").Replace("-", "").Replace("_", "").Replace(".", ",").Replace(" ", "");

                
                
                cappp.Despesa = desp;
                cappp.User = user;
                cappp.Cap_valordespesa = Math.Round(Convert.ToDecimal(a), 2)/ Convert.ToInt32(txtParcelas.Text);
                cappp.Cap_datavencimento = w;
                lcap.Add(cappp);
            }

            DgvDespesa.DataSource = lcap;

            DgvDespesa.Columns.Remove("Cap_cod");
            DgvDespesa.Columns.Remove("Cap_datapagamento");
            DgvDespesa.Columns.Remove("Cap_valorpago");
            DgvDespesa.Columns.Remove("User");
            DgvDespesa.Columns.Remove("Despesaid");
            DgvDespesa.Columns.Remove("Usuarioid");
            DgvDespesa.Columns.Remove("PedidoPetid");

            
        }
    }
}
