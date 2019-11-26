using ShrAgropecuaria.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Repositorios.Interfaces
{
    public interface IProdutoNutricao
    {
        IEnumerable<ProdutoNutricao> GetByNome(string Nome);
        IEnumerable<ProdutoNutricao> GetCat(int? id);
        IEnumerable<ProdutoNutricao> GetCatNome(string nome, int? id);
        void Gravar(ProdutoNutricao user);
        void Excluir(ProdutoNutricao user);
        ProdutoNutricao PegaId(string nome);

        IEnumerable<TipoProdutoNutricao> Carrega();
    }
}
