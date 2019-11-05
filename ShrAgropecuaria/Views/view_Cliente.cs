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
    }
}
