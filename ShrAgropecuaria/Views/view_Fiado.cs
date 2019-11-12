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
    public partial class view_Fiado : Form
    {
        public view_Fiado()
        {
            InitializeComponent();
            lbInstrucao.Text = "Utilize o botão selecionar cliente para pesquisar\no cliente que está efetuando o pagamento do fiado";
        }
    }
}
