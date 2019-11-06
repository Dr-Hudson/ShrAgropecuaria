using Dapper;
using ShrAgropecuaria.Classes;
using ShrAgropecuaria.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Repositorios.MySqlRepository
{
    class MySqlUsuarioRepository : MySqlRepository, IUsuarioRepository
    {

        public MySqlUsuarioRepository(IDbConnection connection) : base(connection)
        {

        }
        public void Excluir(Usuario user)
        {
            Connection.Execute("update usuario set user_nivel = 'I' where user_cod = @user_cod", user);
        }

        public IEnumerable<Usuario> GetByNome(string user)
        {
            string sql = @"select *
                    from usuario
                    where user_usuario like @nome";
            return Connection.Query<Usuario>(sql, new { user = "%" + user + "%" });
        }

        public void Gravar(Usuario user)
        {
            if (user.User_cod == null)
            {
                Connection.Execute("insert into usuario" +
                    "(user_nivel,user_status,user_login, user_senha)" +
                    " values(@user_nivel, @user_status, @user_login, @user_senha)", user);
            }
            else
            {
                Connection.Execute("update usuario set user_nivel = @user_nivel, user_status = @user_status, user_login = @user_login, "
                    + "user_senha = @user_senha where user_cod = @user_cod", user);
            }
        }

        public Usuario PegaId(string nome)
        {
            throw new NotImplementedException();
        }

        public Usuario PegaUsuario(string usuario, string senha)
        {
            string sql = @"select *
                    from usuario
                    where user_login = @usuario and user_senha = @senha and user_status = 'A'";
            return Connection.Query<Usuario>(sql, new { usuario, senha }).FirstOrDefault();
        }
    }
}
