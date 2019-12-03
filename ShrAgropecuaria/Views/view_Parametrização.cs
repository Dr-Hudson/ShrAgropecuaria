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
    public partial class view_Parametrização : Form
    {
        public IParametrizacaoRepository ParametrizacaoRepository { get; }
        public ICidadeRepository CidadeRepository { get; }

        public Boolean flag { get; } 
        public view_Parametrização(IParametrizacaoRepository parametrizacaoRepository, ICidadeRepository cidadeRepository)
        {
            InitializeComponent();
            ParametrizacaoRepository = parametrizacaoRepository;
            CidadeRepository = cidadeRepository;

            Parametrizacao p = parametrizacaoRepository.Get();
            flag = true;
            if(p != null)
            {
                txtLogo.Text = p.Par_logo;
                txtNome.Text = p.Par_nomeemp;
                flag = false;
            }

        }

        private void BtAlterar_Click(object sender, EventArgs e)
        {
            if (txtNome.TextLength > 0)
            {
                if (txtLogo.Text.Length > 0)
                {
                    Parametrizacao p = new Parametrizacao();
                    p.Par_logo = txtLogo.Text;
                    p.Par_nomeemp = txtNome.Text;
                    ParametrizacaoRepository.Gravar(p, flag);
                    if (flag == true)
                        Close();
                }
                MessageBox.Show("Link da logo não pode estar vazio");
            }
            else
                MessageBox.Show("Nome não pode ser vazio");

        }

        private void View_Parametrização_Load(object sender, EventArgs e)
        {
            
        }

        private void mask_cep_Click(object sender, EventArgs e)
        {
            string cep = mask_cep.Text.Replace("-", "").Replace(" ", "");
            if (cep.Length > 0)
                mask_cep.Select(cep.Length, 0);
            else
                mask_cep.Select(0, 0);
        }

        private void mask_numero_Click(object sender, EventArgs e)
        {
            if (mask_numero.Text.Replace(" ", "").Length > 0)
                mask_numero.Select(mask_numero.Text.Length, 0);
            else
                mask_numero.Select(0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var a = new PesquisaCidade(CidadeRepository);
            if (a.ShowDialog() == DialogResult.OK)
                txt_cidade.Text = a.Cidades.Cid_nome;
        }

        private void mask_cnpj_Click(object sender, EventArgs e)
        {
            string cnpj = mask_cnpj.Text.Replace(",", "").Replace("-", "").Replace("/", "").Replace(" ", "");
            if (cnpj.Length > 0 && cnpj.Length < 2)
                mask_cnpj.Select(cnpj.Length, 0);
            else
                if (cnpj.Length >= 2 && cnpj.Length < 5)
                mask_cnpj.Select(cnpj.Length + 1, 0);
            else
                if (cnpj.Length >= 5 && cnpj.Length < 8)
                mask_cnpj.Select(cnpj.Length + 2, 0);
            else
                if (cnpj.Length >= 8 && cnpj.Length < 12)
                mask_cnpj.Select(cnpj.Length + 3, 0);
            else
                if (cnpj.Length >= 12)
                mask_cnpj.Select(cnpj.Length + 4, 0);
            else
                mask_cnpj.Select(0, 0);
        }
    }
}
