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

namespace ShrAgropecuaria.Views.Pesquisas
{
    public partial class PesquisaProdutoNutricao : Form
    {
        public IProdutoNutricao ProdutoRepository { get; }

        

        public ProdutoNutricao Produto = new ProdutoNutricao();
        public PesquisaProdutoNutricao(IProdutoNutricao produtoNutricao)
        {
            InitializeComponent();
            ProdutoRepository = produtoNutricao;
            List<TipoProdutoNutricao> a = ProdutoRepository.Carrega().ToList();
            foreach (var b in a)
            {
                cbbCat.Items.Add(b);
            }
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            string user = txtUsuario.Text;
            try
            {
                if(cbbCat.Text == "")
                {
                    List<ProdutoNutricao> produtos = ProdutoRepository.GetByNome(user).ToList();
                    dgvDados.DataSource = produtos;
                }
                else if(user == "" && cbbCat.Text != "")
                {
                    TipoProdutoNutricao tpn = new TipoProdutoNutricao();
                    tpn = (TipoProdutoNutricao)cbbCat.SelectedItem;
                    List<ProdutoNutricao> produtos = ProdutoRepository.GetCat(tpn.Tpn_cod).ToList();
                    dgvDados.DataSource = produtos;
                }
                else if(user != "" && cbbCat.Text != "")
                {
                    TipoProdutoNutricao tpn = new TipoProdutoNutricao();
                    tpn = (TipoProdutoNutricao)cbbCat.SelectedItem;
                    List<ProdutoNutricao> produtos = ProdutoRepository.GetCatNome(user,tpn.Tpn_cod).ToList();
                    dgvDados.DataSource = produtos;
                }
                RenomeiaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        public void RenomeiaCampos()
        {
            dgvDados.Columns.Remove("Prodn_cod");
            dgvDados.Columns.Remove("Prodn_Ativo");
            dgvDados.Columns.Remove("TipoProdutoNutricaoid");
            dgvDados.Columns["Prodn_obs"].HeaderText = "Observação";
            dgvDados.Columns["Prodn_nomeprod"].HeaderText = "Nome do produto";
            dgvDados.Columns["Prod_valorunitario"].HeaderText = "Valor Unitário";
            dgvDados.Columns["Prodn_previsaoentrega"].HeaderText = "Previsão de Entrega(Dias)";
        }

        private void BtnSelecionar_Click(object sender, EventArgs e)
        {
            try
            {
                Produto = dgvDados.CurrentRow?.DataBoundItem as ProdutoNutricao;
                if (dgvDados.CurrentRow != null)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
