using ShrAgropecuaria.Repositorios.MySqlRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Control
{
    class UsuarioControle
    {
        public Boolean ValidaUsuario(string usuario, string senha)
        {
            MySqlUsuarioRepository rep = new MySqlUsuarioRepository(Connection.GetConnection());
            return rep.PegaUsuario(usuario, senha) != null;
        }
    }
}
