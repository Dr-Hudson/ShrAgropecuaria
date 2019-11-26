using ShrAgropecuaria.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Repositorios.Interfaces
{
    public interface IVendaPETRepository
    {
        void gravar(VendaPET venda);
        void GravarProds(ProdutoVenda pv);
        void atualizarproduto(int cod, int n);

        IEnumerable<VendaPET> getALL(string nome);

        IEnumerable<ProdutoVenda> GetPVenda(int? cod);
    }
}
