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
    public partial class PesquisaUsuario : Form
    {
        public IUsuarioRepository UsuarioRepository { get; }

        public Usuario Usuarios { get; set; }
        public PesquisaUsuario(IUsuarioRepository usuarioRepository)
        {
            InitializeComponent();
            UsuarioRepository = usuarioRepository;
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            string user = txtUsuario.Text;
            List<Usuario> usuarios = UsuarioRepository.GetByNome(user).ToList();
            DgvDados.DataSource = usuarios;
        }

        private void BtnSelecionar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuarios = DgvDados.CurrentRow?.DataBoundItem as Usuario;
                if (DgvDados.CurrentRow != null)
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

        private void BtnCancelar_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
