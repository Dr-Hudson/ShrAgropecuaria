using ShrAgropecuaria.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Repositorios.Interfaces
{
    public interface ICidadeRepository
    {
        Cidade Get(int? id);
        IEnumerable<Cidade> GetAll();
        IEnumerable<Cidade> GetByNome(string Nome);
        IEnumerable<Cidade> GetById(int id);
        Cidade PegaId(string nome);
    }
}
