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

        public Usuario Usuario = new Usuario();
        public PesquisaUsuario(IUsuarioRepository usuarioRepository)
        {
            InitializeComponent();
            UsuarioRepository = usuarioRepository;
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            string user = txtUsuario.Text;
            try
            {
                List<Usuario> usuarios = UsuarioRepository.GetByNome(user).ToList();
                dgvDados.DataSource = usuarios;
            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void BtnSelecionar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario = dgvDados.CurrentRow?.DataBoundItem as Usuario;
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
