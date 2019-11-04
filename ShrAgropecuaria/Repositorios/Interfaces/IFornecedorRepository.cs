using ShrAgropecuaria.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Repositorios.Interfaces
{
    public interface IFornecedorRepository
    {
        Fornecedor Get(int? id);
        IEnumerable<Fornecedor> GetAll(string nome);
        IEnumerable<Fornecedor> GetByNome(string Nome);
        IEnumerable<Fornecedor> GetById(int id);
        Fornecedor PegaId(string nome);
        void Gravar(Fornecedor forn);
        void Excluir(Fornecedor forn);
    }
}
