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
    public partial class view_Parametrização : Form
    {
        public IParametrizacaoRepository ParametrizacaoRepository { get; }

        public Boolean flag { get; } 
        public view_Parametrização(IParametrizacaoRepository parametrizacaoRepository)
        {
            InitializeComponent();
            ParametrizacaoRepository = parametrizacaoRepository;
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
    }
}
