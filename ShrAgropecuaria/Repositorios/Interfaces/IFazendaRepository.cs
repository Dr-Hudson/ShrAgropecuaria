using ShrAgropecuaria.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Repositorios.Interfaces
{
    public interface IFazendaRepository
    {
        IEnumerable<Fazenda> GetAll(string nome);
        IEnumerable<Fazenda> GetByNome(string Nome);
        IEnumerable<Fazenda> GetByIE(string ie);
        IEnumerable<Fazenda> GetByCliente(string id);
        Fazenda Get(int? id);
    }
}
