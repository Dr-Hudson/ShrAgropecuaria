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
    public partial class view_QuitarContasAPagar : Form
    {

        

        ContasAPagar cap = new ContasAPagar();

        Despesa desp = new Despesa();

        Usuario user = new Usuario();
        IContasAPagarRepository IContasapagar { get; }

        IDespesaRepository IDespesa { get; }

        IUsuarioRepository IUsuario { get; }

        public view_QuitarContasAPagar(IContasAPagarRepository contasaapagar, IDespesaRepository despesa, IUsuarioRepository usuario)
        {
            
            InitializeComponent();
            
            IContasapagar = contasaapagar;
            IDespesa = despesa;
            IUsuario = usuario;
            txtUser.Enabled = false;
            txtID.Enabled = false;
            dtpData.Enabled = false;
            txtVP.Enabled = false;
            txtUser.Text = Session.Instance.Nome;
            


        }

        public void CarregaGRID()
        {
            List<ContasAPagar> lcap = IContasapagar.GetAbertas().ToList();
            DgvQuitar.DataSource = lcap;
            NomeiaCampos();
            

            
        }

        private void view_QuitarContasAPagar_Load(object sender, EventArgs e)
        {
            CarregaGRID();
        }

        public void LimparTela()
        {
            txtID.Text = "";
            txtValorPago.Text = "";
            txtVP.Text = "";
            rbAberto.Checked = true;
            rbFechado.Checked = false;
            rbGeral.Checked = false;
            CarregaGRID();
        }

        public void NomeiaCampos()
        {
            DgvQuitar.Columns["Cap_descricao"].HeaderText = "Descrição da despesa";
            DgvQuitar.Columns["Cap_datageracao"].HeaderText = "Data de lançamento";
            DgvQuitar.Columns["Cap_datavencimento"].HeaderText = "Data do vencimento";
            DgvQuitar.Columns["Cap_valordespesa"].HeaderText = "Valor da despesa";
            DgvQuitar.Columns["Cap_datapagamento"].HeaderText = "Data de pagamento";
            DgvQuitar.Columns["Cap_valorpago"].HeaderText = "Valor Pago";
            DgvQuitar.Columns["DespesaDescricao"].HeaderText = "Categoria da despesa";
            DgvQuitar.Columns["NomeUsuario"].HeaderText = "Nome do Usuario";

            DgvQuitar.Columns.Remove("User");
            DgvQuitar.Columns.Remove("Despesaid");
            DgvQuitar.Columns.Remove("Usuarioid");
            DgvQuitar.Columns.Remove("PedidoPetid");
            DgvQuitar.Columns.Remove("Cap_cod");
        }

        private void rbAberto_CheckedChanged(object sender, EventArgs e)
        {
            DgvQuitar.DataSource = "";
            List<ContasAPagar> lcap = IContasapagar.GetAbertas().ToList();
            DgvQuitar.DataSource = lcap;
            NomeiaCampos();
        }

        private void rbFechado_CheckedChanged(object sender, EventArgs e)
        {
            DgvQuitar.DataSource = "";
            List<ContasAPagar> lcap = IContasapagar.GetFechadas().ToList();
            DgvQuitar.DataSource = lcap;
            NomeiaCampos();
        }

        private void rbGeral_CheckedChanged(object sender, EventArgs e)
        {
            DgvQuitar.DataSource = "";
            List<ContasAPagar> lcap = IContasapagar.GetAll("").ToList();
            DgvQuitar.DataSource = lcap;
            NomeiaCampos();
        }

        private void DgvQuitar_SelectionChanged(object sender, EventArgs e)
        {
            
            if (DgvQuitar.CurrentRow != null)
            {

                List<ContasAPagar> lcap = (List<ContasAPagar>)DgvQuitar.DataSource;

                label1.Text = lcap[DgvQuitar.CurrentRow.Index].Cap_descricao;
                txtID.Text = lcap[DgvQuitar.CurrentRow.Index].Cap_cod.ToString();
                txtVP.Text = lcap[DgvQuitar.CurrentRow.Index].Cap_valordespesa.ToString().PadLeft(11,' ');
                if(!lcap[DgvQuitar.CurrentRow.Index].Cap_valorpago.Equals(0))
                {
                    txtValorPago.Enabled = false;
                    dtpDataPagamento.Enabled = false;
                }
                else
                {
                    txtValorPago.Enabled = true;
                    dtpDataPagamento.Enabled = true;
                }
                    

            }
            
        }

        private void SomenteNumeroDPE(object sender, KeyPressEventArgs e)
        {
            string buff = "";
            int i;
            if (txtValorPago.MaskCompleted)
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
                    char[] chars = txtValorPago.Text.ToCharArray();

                    for (i = 0; i < chars.Length - 1; i++)
                        chars[i] = chars[i + 1];

                    chars[i] = e.KeyChar;

                    for (i = 0; i < chars.Length; i++)
                        buff += chars[i];

                    buff = buff.Replace("R$", "").Replace("-", "").Replace("_", "").Replace(".", "").Replace(",", "").Replace(" ", "");

                    txtValorPago.Text = buff.PadLeft(11);


                }

            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            List<ContasAPagar> lcap = (List<ContasAPagar>)DgvQuitar.DataSource;
            cap = lcap[DgvQuitar.CurrentRow.Index];
            
            if(lcap[DgvQuitar.CurrentRow.Index].Cap_valorpago.Equals(0))
            {
                decimal b, d;
                string a = txtValorPago.Text.Replace("R$", "").Replace("-", "").Replace("_", "").Replace(".", ",").Replace(" ", "");
                string c = txtVP.Text.Replace("R$", "").Replace("-", "").Replace("_", "").Replace(".", ",").Replace(" ", "");
                cap.Cap_datapagamento = dtpDataPagamento.Value;
                b = cap.Cap_valorpago = Math.Round(Convert.ToDecimal(a), 2);
                d = Math.Round(Convert.ToDecimal(c), 2);
                bool flag = true;
                if (Math.Round(Convert.ToDecimal(a), 2) > Math.Round(Convert.ToDecimal(c), 2))
                {

                    cap.Cap_valorpago = cap.Cap_valordespesa;
                    IContasapagar.Quitar(cap, flag);
                    MessageBox.Show("Sua despesa foi quitada com um valor remanescente de R$" + (b - d));
                }
                else if (Math.Round(Convert.ToDecimal(a), 2) < Math.Round(Convert.ToDecimal(c), 2))
                {
                    flag = false;
                    IContasapagar.Quitar(cap, flag);
                    MessageBox.Show("Sua despesa foi parcialmente quitada, foi gerado uma nova parcela com o valor restante!!");
                }
                else if (Math.Round(Convert.ToDecimal(a), 2) == Math.Round(Convert.ToDecimal(c), 2))
                {
                    IContasapagar.Quitar(cap, flag);
                    MessageBox.Show("Sua despesa foi quitada!!");
                }
                LimparTela();
            }
            
        }

        private void cbFiltro_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFiltro.Checked == true)
                dtpData.Enabled = true;
            else
                dtpData.Enabled = false;
        }
    }
}
