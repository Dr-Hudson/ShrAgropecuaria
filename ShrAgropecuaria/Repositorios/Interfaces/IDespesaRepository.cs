using ShrAgropecuaria.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Repositorios.Interfaces
{
    public interface IDespesaRepository
    {
        Despesa Get(int? id);
        IEnumerable<Despesa> GetAll();

        Despesa GetNome(string nome);
    }
}
