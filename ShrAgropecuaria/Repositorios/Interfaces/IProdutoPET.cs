using ShrAgropecuaria.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Repositorios.Interfaces
{
    public interface IProdutoPET
    {

        ProdutoPET Get(int? id);
        IEnumerable<ProdutoPET> GetAll();
        IEnumerable<ProdutoPET> GetByNome(string Nome);
        IEnumerable<ProdutoPET> GetById(int id);
        IEnumerable<ProdutoPET> GetByCat(string nome);
        ProdutoPET PegaId(string nome);
        void Gravar(ProdutoPET pet);
        void Excluir(ProdutoPET pet);
    }
}
