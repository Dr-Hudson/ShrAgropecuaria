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
    public partial class View_Cliente : Form
    {
        Cliente cli = new Cliente();
        public ICidadeRepository CidadeRepository { get; }
        public IClienteRepository ClienteRepository { get; }
        public View_Cliente()
        {
            InitializeComponent();
           
        }

        private void mask_limite_Click(object sender, EventArgs e)
        {
            mask_limite.Select(0, 0);
        }

        private void mask_fiado_Click(object sender, EventArgs e)
        {
            mask_fiado.Select(3, 0);
        }

        private void mask_cep_Click(object sender, EventArgs e)
        {
            mask_cep.Select(0, 0);
        }

        private void mask_numero_Click(object sender, EventArgs e)
        {
            mask_numero.Select(0, 0);
        }

        private void mask_cpf_Click(object sender, EventArgs e)
        {
            mask_cpf.Select(0, 0);
        }

        private void mask_telefone_Click(object sender, EventArgs e)
        {
            mask_telefone.Select(0, 0);
        }
    }
}
