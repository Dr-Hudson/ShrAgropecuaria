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
            dtpData2.Enabled = false;
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

        public bool DatasIguaisFiltro()
        {
            int a = DateTime.Compare(dtpData.Value.Date, dtpData2.Value.Date);
            if (a == 0)
                return true;
            return false;
        }

        public int Convertpara23h(int hora)
        {
            int dif = 23 - hora;
            return dif;
        }

        public int Convertpara59m(int min)
        {
            int dif = 59 - min;
            return dif;
        }

        private void rbAberto_CheckedChanged(object sender, EventArgs e)
        {
            DgvQuitar.DataSource = "";
            List<ContasAPagar> lcap = new List<ContasAPagar>();
            if (!cbFiltro.Checked)
            {
                
                lcap = IContasapagar.GetAbertas().ToList();
                DgvQuitar.DataSource = lcap;
                
            }
            else
            {
                
                if (DatasIguaisFiltro())
                    lcap = IContasapagar.GetAbertarFiltro(dtpData.Value.Date, dtpData2.Value.AddHours(Convertpara23h(dtpData2.Value.Hour)).AddMinutes(Convertpara59m(dtpData2.Value.Minute)).AddSeconds(dtpData2.Value.Second)).ToList();
                else if (dtpData.Value < dtpData2.Value)
                    lcap = IContasapagar.GetAbertarFiltro(dtpData.Value, dtpData2.Value.AddHours(Convertpara23h(dtpData2.Value.Hour)).AddMinutes(Convertpara59m(dtpData2.Value.Minute)).AddSeconds(dtpData2.Value.Second)).ToList();
                else
                    MessageBox.Show("Você não pode filtrar uma despesa onde o período que deseja seja menor que a data atual, altere a primeira data e mantenha o segundo filtro no dia atual");

                DgvQuitar.DataSource = lcap;

            }
            DgvQuitar_SelectionChanged(sender, e);
            NomeiaCampos();

        }

        private void rbFechado_CheckedChanged(object sender, EventArgs e)
        {
            DgvQuitar.DataSource = "";
            List<ContasAPagar> lcap = new List<ContasAPagar>();
            if (!cbFiltro.Checked)
            {
                lcap = IContasapagar.GetFechadas().ToList();
                DgvQuitar.DataSource = lcap;
            }
            else
            {
                if (DatasIguaisFiltro())
                    lcap = IContasapagar.GetFechadasFiltro(dtpData.Value.Date, dtpData2.Value.AddHours(Convertpara23h(dtpData2.Value.Hour)).AddMinutes(Convertpara59m(dtpData2.Value.Minute)).AddSeconds(dtpData2.Value.Second)).ToList();
                else if (dtpData.Value < dtpData2.Value)
                    lcap = IContasapagar.GetFechadasFiltro(dtpData.Value, dtpData2.Value.AddHours(Convertpara23h(dtpData2.Value.Hour)).AddMinutes(Convertpara59m(dtpData2.Value.Minute)).AddSeconds(dtpData2.Value.Second)).ToList();
                else
                    MessageBox.Show("Você não pode filtrar uma despesa onde o período que deseja seja menor que a data atual, altere a primeira data e mantenha o segundo filtro no dia atual");

                DgvQuitar.DataSource = lcap;
            }

            DgvQuitar_SelectionChanged(sender, e);
            NomeiaCampos();
        }

        private void rbGeral_CheckedChanged(object sender, EventArgs e)
        {
            DgvQuitar.DataSource = "";
            List<ContasAPagar> lcap = new List<ContasAPagar>();
            if(!cbFiltro.Checked)
            {
                lcap = IContasapagar.GetAll("").ToList();
                DgvQuitar.DataSource = lcap;
            }
            else
            {
                if (DatasIguaisFiltro())
                    lcap = IContasapagar.GetAllFiltro(dtpData.Value.Date, dtpData2.Value.AddHours(Convertpara23h(dtpData2.Value.Hour)).AddMinutes(Convertpara59m(dtpData2.Value.Minute)).AddSeconds(dtpData2.Value.Second)).ToList();
                else if (dtpData.Value < dtpData2.Value)
                    lcap = IContasapagar.GetAllFiltro(dtpData.Value, dtpData2.Value.AddHours(Convertpara23h(dtpData2.Value.Hour)).AddMinutes(Convertpara59m(dtpData2.Value.Minute)).AddSeconds(dtpData2.Value.Second)).ToList();
                else
                    MessageBox.Show("Você não pode filtrar uma despesa onde o período que deseja seja menor que a data atual, altere a primeira data e mantenha o segundo filtro no dia atual");

                DgvQuitar.DataSource = lcap;
            }
            DgvQuitar_SelectionChanged(sender, e);
            NomeiaCampos();
        }

        public bool VerificaParcela(ContasAPagar cap)
        {
            List<ContasAPagar> lcap = new List<ContasAPagar>();
            lcap = (List<ContasAPagar>)IContasapagar.GetData(cap.Cap_datageracao);
            foreach(var a in lcap)
            {
                if (a.Cap_cod < cap.Cap_cod)
                {
                    if (a.Cap_valorpago.Equals(0))
                        return false;
                }
                else if (a.Cap_cod == cap.Cap_cod)
                    break;

            }


            return true;
        }

        private void DgvQuitar_SelectionChanged(object sender, EventArgs e)
        {
            
            
                if (DgvQuitar.CurrentRow != null)
                {

                    List<ContasAPagar> lcap = (List<ContasAPagar>)DgvQuitar.DataSource;

                    label1.Text = lcap[DgvQuitar.CurrentRow.Index].Cap_descricao;
                    txtID.Text = lcap[DgvQuitar.CurrentRow.Index].Cap_cod.ToString();
                    txtVP.Text = lcap[DgvQuitar.CurrentRow.Index].Cap_valordespesa.ToString().PadLeft(11, ' ');
                    if (!lcap[DgvQuitar.CurrentRow.Index].Cap_valorpago.Equals(0))
                    {
                        txtValorPago.Enabled = false;
                        dtpDataPagamento.Enabled = false;
                        btnQuitar.Enabled = false;
                        btnEstornar.Enabled = true;

                    }
                    else
                    {
                        btnQuitar.Enabled = true;
                        txtValorPago.Enabled = true;
                        dtpDataPagamento.Enabled = true;
                        btnEstornar.Enabled = false;
                    }


                }
                else
                {
                    label1.Text = "Despesa";
                    txtID.Text = "";
                    txtValorPago.Text = "";
                    txtVP.Text = "";
                    txtValorPago.Enabled = false;
                    dtpDataPagamento.Enabled = false;
                    btnQuitar.Enabled = false;
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
            if(VerificaParcela(cap) || MessageBox.Show("Você selecionou uma parcela porém tem outra anterior em aberta, ainda deseja quitar essa parcela","Existe parcela(s) anterior(es)",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (lcap[DgvQuitar.CurrentRow.Index].Cap_valorpago.Equals(0))
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
                        if (MessageBox.Show("Foi inserido um valor de pagamento acima do preço da despesa, deseja confirmar o pagamento mesmo assim?", "Valor do pagamento acima do valor da despesa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            cap.Cap_valorpago = cap.Cap_valordespesa;
                            IContasapagar.Quitar(cap, flag);
                            MessageBox.Show("Sua despesa foi quitada com um valor remanescente de R$" + (b - d));
                        }
                        else
                            MessageBox.Show("Usuario não concordou em continuar a quitação da despesa, logo, a operação foi cancelada!");
                        
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
            
            
            
        }

        private void cbFiltro_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFiltro.Checked == true)
            {
                dtpData.Enabled = true;
                dtpData2.Enabled = true;
            }
                
            else
            {
                dtpData.Enabled = false;
                dtpData2.Enabled = false;
            }
                
        }

        private void rbAberto_Click(object sender, EventArgs e)
        {
            rbAberto_CheckedChanged(sender, e);
        }

        private void rbFechado_Click(object sender, EventArgs e)
        {
            rbFechado_CheckedChanged(sender, e);
        }

        private void rbGeral_Click(object sender, EventArgs e)
        {
            rbGeral_CheckedChanged(sender, e);
        }

        private void DgvQuitar_Click(object sender, EventArgs e)
        {
            DgvQuitar_SelectionChanged(sender, e);
        }

        public bool VerificaUltimaParcelaFechada(ContasAPagar cap)
        {
            List<ContasAPagar> lcap = IContasapagar.GetData(cap.Cap_datageracao).ToList();
            foreach(var a in lcap)
            {
                if (a.Cap_cod >= cap.Cap_cod)
                    if (a.Cap_valorpago.Equals(0) || a.Cap_valordespesa == cap.Cap_valorpago)
                    {
                        return true;
                    }
                    else
                        break;
                
            }
            return false;
        }

        private void btnEstornar_Click(object sender, EventArgs e)
        {
            ContasAPagar cap = new ContasAPagar();
            ContasAPagar aux = new ContasAPagar();
            bool flag = false;
            List<ContasAPagar> lcap = (List<ContasAPagar>)DgvQuitar.DataSource;
            cap = lcap[DgvQuitar.CurrentRow.Index];
            if (VerificaUltimaParcelaFechada(cap))
            {
                lcap = IContasapagar.GetData(cap.Cap_datageracao).ToList();
                foreach(var a in lcap)
                    if(a.Cap_datavencimento == cap.Cap_datavencimento)
                        if(a.Cap_cod > cap.Cap_cod || a.Cap_valordespesa == cap.Cap_valorpago)
                        {
                            aux = a;
                            flag=true;
                            break;
                        }
                cap.Cap_valorpago = 0;
                cap.Cap_datapagamento = DateTime.MinValue;
                IContasapagar.Estornar(cap, aux, flag);
                MessageBox.Show("O valor da parcela foi estornado!!");
                rbFechado_Click(sender, e);
                

            }
            else
                MessageBox.Show("Você não pode estornar essa parcela, pois tem uma parcela posterior paga!");

        }
    }
}
