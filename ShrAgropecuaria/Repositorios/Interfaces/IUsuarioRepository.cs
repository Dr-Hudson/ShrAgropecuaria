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
        Usuario Get(int? id);
        IEnumerable<Usuario> GetAll(string nome);
        IEnumerable<Usuario> GetByNome(string Nome);
        Usuario PegaId(string nome);
        void Gravar(Usuario u);
        void Excluir(Usuario u);
    }
}

