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
            txtUsuario.BackColor = Color.White;
            txtSenha.BackColor = Color.White;
            if (usuario.Replace(" ","").Length == 0)
            {
                lbR.Text = "Usuario não informado!";
                txtUsuario.Text = "";
                txtUsuario.BackColor = Color.Red;
            }
            else
                if(senha.Replace(" ", "").Length == 0)
                {
                    lbR.Text = "Senha não informada!";
                    txtSenha.Text = "";
                    txtSenha.BackColor = Color.Red;
                }
                else
                {
                    Usuario user = UsuarioRepository.PegaUsuario(usuario, senha);
                    if (user != null)
                    {
                        Session.Instance.ID = (int)user.User_cod;
                        Session.Instance.Nome = user.User_login;
                        if (user.User_nivel == "admin")
                        {
                            this.Hide();
                            Form f = new view_Menu();
                            f.Closed += (s, args) => this.Close();
                            f.Show();

                        }
                        else
                        {
                            this.Hide();
                            Form f = new view_MenuPublico();
                            f.Closed += (s, args) => this.Close();
                            f.Show();
                        }
                    }
                    else
                    {
                        lbR.Text = "Usuario e/ou Senha invalidos!";
                    }
                }

        }
    }
}
