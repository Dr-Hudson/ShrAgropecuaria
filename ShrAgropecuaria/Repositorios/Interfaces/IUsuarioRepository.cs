using ShrAgropecuaria.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Repositorios.Interfaces
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> GetByNome(string Nome);
        void Gravar(Usuario user);
        void Excluir(Usuario user);
        Usuario PegaId(string nome);
        Usuario PegaUsuario(string usuario, string senha);

        Usuario getNome(string nome);

        int Conta();
    }
}
