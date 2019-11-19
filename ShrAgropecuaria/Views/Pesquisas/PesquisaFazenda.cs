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
    public partial class PesquisaFazenda : Form
    {
        public Fazenda faz = new Fazenda();
        public IFazendaRepository FazendaRepository { get; }
        public PesquisaFazenda(IFazendaRepository fazendaRepository)
        {
            InitializeComponent();
            FazendaRepository = fazendaRepository;
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            if (txt_nome.Text == "" && txt_ie.Text == "")
            {
                List<Fazenda> faz = FazendaRepository.GetAll("").ToList();
                DgvForn.DataSource = faz;
            }
            else
            if (txt_nome.Text != "" && txt_ie.Text == "")
            {
                List<Fazenda> faz = FazendaRepository.GetByNome(txt_nome.Text).ToList();
                DgvForn.DataSource = faz;
            }
            else if (txt_nome.Text == "" && txt_ie.Text != "")
            {
                List<Fazenda> faz = FazendaRepository.GetByIE(txt_ie.Text).ToList();
                DgvForn.DataSource = faz;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSelecionarCid_Click(object sender, EventArgs e)
        {
            try
            {
                faz = DgvForn.CurrentRow?.DataBoundItem as Fazenda;
                if (DgvForn.CurrentRow != null)
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
    }
}
