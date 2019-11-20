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
        void Excluir(DateTime a);

        IEnumerable<ContasAPagar> GetData(DateTime data);

        IEnumerable<ContasAPagar> GetAbertas();

        IEnumerable<ContasAPagar> GetFechadas();

        void Quitar(ContasAPagar cap, bool flag);

        int conta(int id);
    }
}
