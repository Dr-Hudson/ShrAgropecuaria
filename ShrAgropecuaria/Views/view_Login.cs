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
    public partial class view_Login : Form
    {
        public IUsuarioRepository UsuarioRepository { get; }
        public view_Login(IUsuarioRepository usuarioRepository)
        {
            InitializeComponent();
            UsuarioRepository = usuarioRepository;
        }

        private void BtEntrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;

            if(usuario.Replace(" ","").Length == 0)
            {
                lbR.Text = "Usuario não informado!";
            }
            else
                if(senha.Replace(" ", "").Length == 0)
                {
                    lbR.Text = "Senha não informada!";
                }
                else
                {
                    if(UsuarioRepository.PegaUsuario(usuario, senha) != null)
                    {
                        var a = new view_Menu();
                        a.ShowDialog();
                    }
                    else
                    {
                        lbR.Text = "Usuario e/ou Senha invalidos!";
                    }
                }

        }
    }
}
