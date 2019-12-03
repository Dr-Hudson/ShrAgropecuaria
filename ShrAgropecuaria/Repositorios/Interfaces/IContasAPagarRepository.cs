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
        IEnumerable<ContasAPagar> GetAllFiltro(DateTime data, DateTime data2);

        void Gravar(List<ContasAPagar> lcap);
        void Excluir(DateTime a);

        IEnumerable<ContasAPagar> GetData(DateTime data);

        IEnumerable<ContasAPagar> Filtro(DateTime data, DateTime data2);

        IEnumerable<ContasAPagar> GetAbertas();
        IEnumerable<ContasAPagar> GetAbertarFiltro(DateTime data, DateTime data2);

        IEnumerable<ContasAPagar> GetFechadas();
        IEnumerable<ContasAPagar> GetFechadasFiltro(DateTime data, DateTime data2);
        void Estornar(ContasAPagar update, ContasAPagar excluir);
        

        void Quitar(ContasAPagar cap, bool flag);

        int conta(int id);
    }
}
