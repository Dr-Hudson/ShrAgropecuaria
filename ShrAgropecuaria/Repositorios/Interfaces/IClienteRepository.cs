using ShrAgropecuaria.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Repositorios.Interfaces
{
    public interface IClienteRepository
    {
        Cliente Get(int? id);
        IEnumerable<Cliente> GetAll(string nome);
        IEnumerable<Cliente> GetByNome(string Nome);
        IEnumerable<Cliente> GetById(int id);
        Cliente PegaId(string nome);
        void Gravar(Cliente cli);
        void Excluir(Cliente cli);
    }
}
