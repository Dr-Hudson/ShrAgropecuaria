using ShrAgropecuaria.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrAgropecuaria.Repositorios.Interfaces
{
    public interface ICategoriaProdutoPET
    {
        CategoriaProdutoPET Get(int? id);
        IEnumerable<CategoriaProdutoPET> GetAll();
        IEnumerable<CategoriaProdutoPET> GetByNome(string Nome);
        
        CategoriaProdutoPET PegaId(string nome);

    }
}
