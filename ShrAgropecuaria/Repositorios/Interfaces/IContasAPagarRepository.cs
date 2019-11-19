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
        void Gravar(List<ContasAPagar> lcap);
        void Excluir(List<ContasAPagar> lcap);

        int conta(int id);
    }
}
