using ShrAgropecuaria.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Repositorios.Interfaces
{
    public interface IContasAPagarRepository
    {
        ContasAPagar Get(int? id);
        IEnumerable<ContasAPagar> GetAll(string nome);
        void Gravar(ContasAPagar cap, int parcela);
        void Excluir(ContasAPagar cap);
    }
}
