using ShrAgropecuaria.Classes;
using ShrAgropecuaria.Repositorios.Interfaces;
using ShrAgropecuaria.Repositorios.MySqlRepository;
using ShrAgropecuaria.Views.Pesquisas;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShrAgropecuaria.Views
{
    public partial class view_Usuario : Form
    {
        public IUsuarioRepository UsuarioRepository { get; }
        int conta;
        public view_Usuario(IUsuarioRepository usuarioRepository)
        {
            InitializeComponent();
            
                
            txtID.Enabled = false;
            UsuarioRepository = usuarioRepository;
            conta = UsuarioRepository.Conta();
            if (conta == 0)
            {
                rbUser.Enabled = false;
                btPesquisar.Enabled = false;
                btExcluir.Enabled = false;

            }
        }

        private void Limpar()
        {
            txtID.Text = "";
            txtSenha.Text = "";
            txtUsuario.Text = "";
            lbR.Text = "";
            txtUsuario.BackColor = Color.White;
            txtSenha.BackColor = Color.White;
        }

        private void BtLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void BtGravar_Click(object sender, EventArgs e)
        {
            txtUsuario.BackColor = Color.White;
            txtSenha.BackColor = Color.White;
            lbR.Text = "";
            if (txtUsuario.Text.Replace(" ", "").Length < 5)
            {
                lbR.Text = "Usuario precisa ter mais de\n5 caracteres!";
                txtUsuario.BackColor = Color.Red;
            }
            else
                if (txtSenha.Text.Length < 5)
            {
                lbR.Text = "Senha precisa ter mais de\n5 caracteres!";
                txtSenha.BackColor = Color.Red;
            }
            else
            {
                Usuario user = new Usuario();
                user.User_login = txtUsuario.Text;
                user.User_senha = txtSenha.Text;
                if (rbAdmin.Checked == true)
                    user.User_nivel = "admin";
                else
                    user.User_nivel = "user";
                user.User_status = 'A';
                if (txtID.Text == "")
                    user.User_cod = null;
                else
                    user.User_cod = Convert.ToInt32(txtID.Text);
                try
                {                          
                        if (txtID.Text == "")
                        {
                            Usuario aux = new Usuario();
                            aux = UsuarioRepository.PegaUsuario(user.User_login, user.User_senha);
                            if (aux == null)
                            {
                                UsuarioRepository.Gravar(user);
                                MessageBox.Show("Usuario cadastrado!");
                                Limpar();
                            }
                            else
                            {
                                MessageBox.Show("Usuário duplicado");
                                Limpar();
                            }
                            
                        }
                        else
                        {
                            bool flag = true;
                                try
                                {
                                    int n = UsuarioRepository.Conta();
                                    if (n == 1)
                                    {
                                        if(user.User_nivel != "admin")
                                        {
                                            flag = false;
                                            lbR.Text = "Não é possivel Alterar!\nEsse é o unico\nusuario adiminstrador";
                                        }
                                        
                                    }

                                }
                                catch (Exception erro)
                                {
                                    MessageBox.Show(erro.Message);
                                }
                            
                            if (flag == true)
                            {
                                try
                                {
                                    UsuarioRepository.Gravar(user);
                                    MessageBox.Show("Usuario Alterado!");
                                    Limpar();
                                }
                                catch (Exception erro)
                                {
                                    MessageBox.Show(erro.Message);
                                }
                            }

                        }
    
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }

            }
        }

        private void BtExcluir_Click(object sender, EventArgs e)
        {
            txtUsuario.BackColor = Color.White;
            txtSenha.BackColor = Color.White;
            lbR.Text = "";

            if (txtID.Text == "")
            {
                lbR.Text = "Use o botão de pesquisa e\nselecione um usuario";
            }
            else
            {
                Usuario user = new Usuario();
                user.User_login = txtUsuario.Text;
                user.User_senha = txtSenha.Text;
                if (rbAdmin.Checked == true)
                    user.User_nivel = "admin";
                else
                    user.User_nivel = "user";
                user.User_cod = Convert.ToInt32(txtID.Text);
                Boolean flag = true;
                if (rbAdmin.Checked == true)
                {
                    try
                    {
                        int n = UsuarioRepository.Conta();
                        if (n == 1)
                        {
                            flag = false;
                            lbR.Text = "Não é possivel excluir!\nEsse é o unico\nusuario adiminstrador";
                        }

                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message);
                    }
                }
                if (flag == true)
                {
                    try
                    {
                        UsuarioRepository.Excluir(user);
                        MessageBox.Show("Excluido!");
                        Limpar();
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message);
                    }
                }

            }


        }

        private void BtPesquisar_Click(object sender, EventArgs e)
        {
            var a = new PesquisaUsuario(UsuarioRepository);

            if (a.ShowDialog() == DialogResult.OK)
            {

                txtID.Text = a.Usuario.User_cod.ToString();
                txtUsuario.Text = a.Usuario.User_login;
                txtSenha.Text = a.Usuario.User_senha;
                if (a.Usuario.User_nivel == "admin")
                    rbAdmin.Checked = true;
                else
                    rbUser.Checked = true;
            }
        }
    }
}
